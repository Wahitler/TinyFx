using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    public class DBOChangeEventArgs : EventArgs
    {
        public DBOTreeNode CurrentNode { get; set; }
        public DBOChangeEventArgs(DBOTreeNode node)
        {
            CurrentNode = node;
        }

    }
}
