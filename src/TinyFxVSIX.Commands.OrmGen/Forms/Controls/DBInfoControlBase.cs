using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyFx.Windows.EnvDTE;
using TinyFxVSIX.Commands.OrmGen;

namespace TinyFxVSIX.Commands.OrmGen.Forms.Controls
{
    public class DBInfoControlBase : UserControl
    {
        protected DBOChangeEventArgs _args;
        protected EnvDTEWraper _dte { get { return MainForm.CurrentDTE; } }
        public void SetInfoData(DBOChangeEventArgs args)
        {
            _args = args;
        }
    }
}
