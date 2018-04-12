using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Templates.MySqlClient
{
    public partial class MySqlProcMOT
    {
        public ProcSchema CurrentProc { get; internal set; }
        public MySqlProcMOT(ProcSchema proc)
        {
            CurrentProc = proc;
        }
        public string MOName { get { return GetMOName(CurrentProc); } }
    }
}
