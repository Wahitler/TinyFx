using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.Windows.EnvDTE
{
    /// <summary>
    /// 源代码管理提供程序
    /// </summary>
    public enum SccProvider
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// TFS
        /// </summary>
        TFS,
        /// <summary>
        /// SVN
        /// </summary>
        SVN,
        /// <summary>
        /// GIT
        /// </summary>
        GIT
    }
}
