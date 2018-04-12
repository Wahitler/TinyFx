using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyFx.Data;
using TinyFxVSIX.Commands.OrmGen.Forms.Controls;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    /// <summary>
    /// 数据库节点信息
    /// </summary>
    [Serializable]
    public class DBONodeInfo
    {
        public ConnectionStringInfo ConnStrInfo { get; set; }
        public OrmSettings OrmSettings = new OrmSettings();
        public DbInitSettings DbInitSettings = new DbInitSettings();
        public DBONodeInfo(ConnectionStringInfo info)
        {
            ConnStrInfo = info;
        }
        public DBONodeInfo() { }
    }
}
