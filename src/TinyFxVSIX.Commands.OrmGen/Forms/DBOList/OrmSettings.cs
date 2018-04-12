using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyFxVSIX.Commands.OrmGen.Forms
{
    [Serializable]
    public class OrmSettings
    {
        public string Namespaces { get; set; }
        public string OutputPath { get; set; }
    }
}
