using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFxVSIX.Commands.OrmGen.Forms.Controls;
using WeifenLuo.WinFormsUI.Docking;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    public partial class DBOInfoWindow : DockContent
    {
        public DBOInfoWindow()
        {
            InitializeComponent();
        }
        private NoneDBOCtl _noneDBO = new NoneDBOCtl();
        private DBInfoCtl _ctlDBInfo = new DBInfoCtl();
        private TableListInfoCtl _ctlTableList = new TableListInfoCtl();
        private TableInfoCtl _ctlTableInfo = new TableInfoCtl();
        private ViewListInfoCtl _ctlViewList = new ViewListInfoCtl();
        private ViewInfoCtl _ctlViewInfo = new ViewInfoCtl();
        private ProcListInfoCtl _ctlProcList = new ProcListInfoCtl();
        private ProcInfoCtl _ctlProcInfo = new ProcInfoCtl();
        private void DBOInfoWindow_Load(object sender, EventArgs e)
        {

        }
        public void OnDBOChange(object sender, DBOChangeEventArgs args)
        {
            this.Controls.Clear();
            DBInfoControlBase ctl = null;
            if (args == null)
            {
                ctl = _noneDBO;
            }
            else
            {
                switch (args.CurrentNode.DBOListType)
                {
                    case DBOListType.Database:
                        ctl = _ctlDBInfo;
                        break;
                    case DBOListType.Tables:
                        ctl = _ctlTableList;
                        break;
                    case DBOListType.Table:
                        ctl = _ctlTableInfo;
                        break;
                    case DBOListType.Views:
                        ctl = _ctlViewList;
                        break;
                    case DBOListType.View:
                        ctl = _ctlViewInfo;
                        break;
                    case DBOListType.Procs:
                        ctl = _ctlProcList;
                        break;
                    case DBOListType.Proc:
                        ctl = _ctlProcInfo;
                        break;
                }
                ctl.SetInfoData(args);
                ((IDBInfoRefresh)ctl).RefreshData();
            }
            ctl.Dock = DockStyle.Fill;
            this.Controls.Add(ctl);
        }
    }
}
