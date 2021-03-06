﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using TinyFx.Log4net;

namespace TinyFx.Data
{
    /// <summary>
    /// DbCommand对象包装类
    /// 无法使用构造函数，请通过Database.CreateCommand创建此对象
    /// </summary>
    public class CommandWrapper : IDisposable
    {
        private DbCommand _command;

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
            => _command.Connection?.ConnectionString;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="command">包装的DbCommand对象</param>
        public CommandWrapper(DbCommand command)
            => _command = command;

        /// <summary>
        /// 包装的DbCommand对象
        /// </summary>
        public DbCommand Command => _command;

        /// <summary>
        /// DbConnection对象
        /// </summary>
        public DbConnection Connection { get { return _command.Connection; } set { _command.Connection = value; } }
        
        /// <summary>
        /// 事务对象
        /// </summary>
        public DbTransaction Transaction { get { return _command.Transaction; } set { _command.Transaction = value; } }
        
        /// <summary>
        /// 是否存在事务处理
        /// </summary>
        public bool HasTransaction => _command.Transaction != null;
        
        /// <summary>
        /// 获取DbCommand对象的参数集合
        /// </summary>
        public DbParameterCollection Parameters => _command.Parameters;

        /// <summary>
        /// 获取或设置DbCommand对象的CommandText属性
        /// </summary>
        public string CommandText { get { return _command.CommandText; } set { _command.CommandText = value; } }

        /// <summary>
        /// 获取或设置在终止执行命令的尝试并生成错误之前的等待时间。默认30秒，0表示不限制时间
        /// </summary>
        public int CommandTimeout { get { return _command.CommandTimeout; } set { _command.CommandTimeout = value; } }

        /// <summary>
        /// 获取或设置DbCommand对象的CommandType属性
        /// </summary>
        public CommandType CommandType { get { return _command.CommandType; } set { _command.CommandType = value; } }

        /// <summary>
        /// 执行SQL语句并返回受影响的行数
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
            => _command.ExecuteNonQuery();

        /// <summary>
        /// 执行查询语句并返回首行首列数据
        /// 返回null表示数据库没有记录，返回DBNull表示此字段为空
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
            => _command.ExecuteScalar(); 

        /// <summary>
        /// 执行SQL语句并返回结果集
        /// </summary>
        /// <returns></returns>
        public DataReaderWrapper ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            var reader = _command.ExecuteReader(behavior);
            return new DataReaderWrapper(this, reader);
        }

        #region IDisposable
        private bool _isDisposed = false;
        
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed) return;
            if (!HasTransaction) //如果存在事务，交给事务释放资源，此处忽略
                _command.Connection.Close();
            GC.SuppressFinalize(this);
            _isDisposed = true;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~CommandWrapper()
        {
            string msg = "CommandWrapper不应进入析构函数，请检查并释放资源。";
            if (_command != null && _command.Connection != null)
            {
                // 不能让析构函数释放资源，错误!!!
                msg = string.Format("CommandWrapper对象在析构函数中调用Dispose。{0}，连接{1}。CommandText: {2}"
                    , _command.Transaction != null ? "Transaction对象未Commit或Rollback" : string.Empty
                    , _command.Connection.State == ConnectionState.Closed ? "已关闭" : "未关闭"
                    , _command.CommandText);
                if (_command.Connection.State != ConnectionState.Closed)
                    _command.Connection.Close();
            }
            LogUtil.Error(msg);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Close()
            => ((IDisposable)this).Dispose();
        #endregion
    }
}
