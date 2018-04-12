using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Templates.MySqlClient
{
    public partial class MySqlViewMOT
    {
        public ViewSchema CurrentView { get; internal set; }
        public MySqlViewMOT(ViewSchema view)
        {
            CurrentView = view;
        }
        public string MOName { get { return GetMOName(CurrentView); } }
        public string EOName { get { return GetEOName(CurrentView); } }
    }
}
