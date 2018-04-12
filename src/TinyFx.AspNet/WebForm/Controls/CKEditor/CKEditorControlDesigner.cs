using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.AspNet.WebForm.Controls
{
    public class CKEditorControlDesigner : System.Web.UI.Design.ControlDesigner
    {
        public CKEditorControlDesigner()
        {
        }

        public override string GetDesignTimeHtml()
        {
            CKEditorControl control = (CKEditorControl)Component;
            return String.Format(CultureInfo.InvariantCulture,
                "<table width=\"{0}\" height=\"{1}\" bgcolor=\"#f5f5f5\" bordercolor=\"#c7c7c7\" cellpadding=\"0\" cellspacing=\"0\" border=\"1\"><tr><td valign=\"middle\" align=\"center\"><h3>CKEditor ASP.NET Control - <em>'{2}'</em></h3></td></tr></table>",
                control.Width.Value == 0 ? "100%" : control.Width.ToString(),
                control.Height,
                control.ID);
        }
    }

}
