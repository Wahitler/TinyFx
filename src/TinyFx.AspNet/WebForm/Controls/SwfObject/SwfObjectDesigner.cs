using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.Design;

namespace TinyFx.AspNet.WebForm.Controls
{
    /// <summary>
    /// SwfObject设计器类
    /// </summary>
    public class SwfObjectDesigner : ControlDesigner
    {
        /// <summary>
        /// 获取设计时样式
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            SwfObject control = (SwfObject)Component;
            return string.Format("<table width=\"{0}\" height=\"{1}\" bgcolor=\"#f5f5f5\" bordercolor=\"#c7c7c7\" cellpadding=\"0\" cellspacing=\"0\" border=\"1\"><tr><td valign=\"middle\" align=\"center\">SwfObject v1.0 - <b>{2}</b></td></tr></table>"
                , control.SwfWidth
                , control.SwfHeight
                , control.ID);
        }
    }
}
