using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using TinyFx.Data.Instrumentation;
using System.Diagnostics;
using System.Reflection;
using TinyFx.Log4net;

namespace TinyFx.Data
{
    /// <summary>
    /// 数据库事务管理类
    /// 请显示调用Commit()或Rollback()释放资源
    /// </summary>
    public class TransactionManager
    {
        /// <summary>
        /// 事务级别
        /// </summary>
        public IsolationLevel IsolationLevel { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isolationLevel">事务级别，默认IsolationLevel.ReadCommitted</param>
        public TransactionManager(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            IsolationLevel = isolationLevel;
            _exception = new Exception("TransactionManager对象在析构函数中调用释放，请显示调用Commit()或Rollback()释放资源。");
            _exception.AddUserData("StackTrace", Environment.StackTrace);
        }

        // key : ConnectionString
        private Dictionary<string, DbTransaction> _trans = new Dictionary<string, DbTransaction>(3);
        private object _syncLock = new object();
        private bool _isOpened = false;

        private IDataInstProvider _instrumentationProvider = null;
        private Exception _exception = null;

        /// <summary>
        /// 根据连接字符串获取已存在或创建一个新的数据库事务
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public DbTransaction GetTransaction(Database database)
        {
            DbTransaction ret = null;
            string key = database.ConnectionString;
            if (!_trans.ContainsKey(key))
            {
                lock (_syncLock)
                {
                    if (!_trans.ContainsKey(key))
                    {
                        DbConnection conn = database.CreateConnection();
                        database.OpenConnection(conn);
                        ret = conn.BeginTransaction(IsolationLevel);
                        _trans.Add(key, ret);
                        _isOpened = true;
                    }
                }
                //只取一个检测程序
                if (_instrumentationProvider == null)
                {
                    _instrumentationProvider = database.InstProvider;
                }
            }
            else
            {
                ret = _trans[key];
            }
            return ret;
        }

        private void Process(bool isCommit)
        {
            if (_isOpened && _trans.Count > 0)
            {
                try
                {
                    foreach (DbTransaction tran in _trans.Values)
                    {
                        if (tran != null && tran.Connection != null)
                        {
                            if (isCommit) tran.Commit(); else tran.Rollback();
                        }
                    }
                }
                finally
                {
                    CloseConnections();
                    GC.SuppressFinalize(this);
                }
            }
            else
                throw new Exception("TransactionManager事物对象没有使用，不能Commit或Rollback。");
        }
        private void CloseConnections()
        {
            _isOpened = false;
            foreach (DbTransaction tran in _trans.Values)
            {
                if (tran != null && tran.Connection != null)
                    tran.Connection.Close();
            }
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit() => Process(true);

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback() => Process(false);

        /// <summary>
        /// 析构函数
        /// </summary>
        ~TransactionManager()
        {
            if (!_isOpened) return;
            try
            {
                CloseConnections();
            }
            catch { }

            // 记录没有手动释放资源的错误!!!
            try
            {
                _instrumentationProvider?.FireTransactionUndisposedEvent(_exception);
            }
            catch { }
        }
    }
}
