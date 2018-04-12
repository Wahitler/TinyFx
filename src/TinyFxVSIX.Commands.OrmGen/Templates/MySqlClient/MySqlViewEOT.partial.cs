using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data.Schema;

namespace TinyFxVSIX.Commands.OrmGen.Templates.MySqlClient
{
    public partial class MySqlViewEOT
    {
        public ViewSchema CurrentView { get; internal set; }
        public MySqlViewEOT(ViewSchema view)
        {
            CurrentView = view;
        }
        public string EOName { get { return GetEOName(CurrentView); } }
    }
}
