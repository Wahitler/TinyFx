using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKFinder.Settings;
using System.Collections;
using System.IO;
using System.Web;

namespace TinyFx.AspNet.WebForm.Controls.CKFinder
{
    public class DefaultConfigFile: ConfigFile
    {
        public override bool CheckAuthentication()
        {
            // WARNING : DO NOT simply return "true". By doing so, you are allowing
            // "anyone" to upload and list the files in your server. You must implement
            // some kind of session validation here. Even something very simple as...
            //
            //		return ( Session[ "IsAuthorized" ] != null && (bool)Session[ "IsAuthorized" ] == true );
            //
            // ... where Session[ "IsAuthorized" ] is set to "true" as soon as the
            // user logs on your system.

            //return HttpContext.Current.User.Identity.IsAuthenticated;
            return true;
        }
        public override void SetConfig()
        {
            #region 一般性设置
            // Paste your license name and key here. If left blank, CKFinder will
            // be fully functional, in Demo Mode.
            LicenseName = "";
            LicenseKey = "";

            // 图片限制
            Images.MaxWidth = 0;
            Images.MaxHeight = 0;
            Images.Quality = 0;

            // true: 缩放后检查大小 false: 上传后检查
            CheckSizeAfterScaling = true;
            // true: 禁止创建文件夹并上传名称中包含字符的文件
            DisallowUnsafeCharacters = true;
            // 建议true
            ForceSingleExtension = true;
            // true: 检查foo.php.rar中.php验证，仅当ForceSingleExtension=false有效
            CheckDoubleExtension = true;
            // HTML 文件类型
            HtmlExtensions = new string[] { "html", "htm", "xml", "js" };
            // 图片文件额外检查
            SecureImageUploads = true;
            // CSRF保护机制
            // https://www.owasp.org/index.php/Cross-Site_Request_Forgery_%28CSRF%29_Prevention_Cheat_Sheet#Double_Submit_Cookies
            EnableCsrfProtection = true;
            #endregion

            #region Plugins
            // Optional: enable extra plugins (remember to copy .dll files first).
            Plugins = new string[] {
			// "CKFinder.Plugins.FileEditor, CKFinder_FileEditor",
			// "CKFinder.Plugins.ImageResize, CKFinder_ImageResize",
			// "CKFinder.Plugins.Watermark, CKFinder_Watermark"
		    };
            // Settings for extra plugins.
            PluginSettings = new Hashtable();
            PluginSettings.Add("ImageResize_smallThumb", "90x90");
            PluginSettings.Add("ImageResize_mediumThumb", "120x120");
            PluginSettings.Add("ImageResize_largeThumb", "180x180");
            // Name of the watermark image in plugins/watermark folder
            PluginSettings.Add("Watermark_source", "logo.gif");
            PluginSettings.Add("Watermark_marginRight", "5");
            PluginSettings.Add("Watermark_marginBottom", "5");
            PluginSettings.Add("Watermark_quality", "90");
            PluginSettings.Add("Watermark_transparency", "80");
            #endregion

            #region Thumbnail
            // Thumbnail settings.
            // "Url" is used to reach the thumbnails with the browser, while "Dir"
            // points to the physical location of the thumbnail files in the server.
            Thumbnails.Url = BaseUrl + "_thumbs/";
            if (BaseDir != "")
            {
                Thumbnails.Dir = BaseDir + "_thumbs/";
            }
            Thumbnails.Enabled = true;
            Thumbnails.DirectAccess = false;
            Thumbnails.MaxWidth = 100;
            Thumbnails.MaxHeight = 100;
            Thumbnails.Quality = 80;
            #endregion

            #region AccessControl
            // 当前用户角色的session名，AccessControl中设置
            RoleSessionVar = "CKFinder_UserRole";
            // 访问控制设置
            AccessControl acl = AccessControl.Add();
            acl.Role = "*"; // * 代表任何人
            acl.ResourceType = "*"; // * 代表所有资源类型
            acl.Folder = "/";

            acl.FolderView = true;
            acl.FolderCreate = true;
            acl.FolderRename = true;
            acl.FolderDelete = true;

            acl.FileView = true;
            acl.FileUpload = true;
            acl.FileRename = true;
            acl.FileDelete = true;
            #endregion

            // 浏览器访问CKFinder中的文件基路径
            //BaseUrl = "/ckfinder/userfiles/";
            // 文件最终会在服务器上的物理目录。 如果空白，CKFinder将尝试解析BaseUrl
            BaseDir = "";
            // 隐藏的文件夹名称,支持 * 和 ?
            //HideFolders = new string[] { ".*", "CVS" };
            // 隐藏的文件名称,支持 * 和 ?
            HideFiles = new string[] { ".*" };

            #region ResourceType
            // Resource Type settings.
            // A resource type is nothing more than a way to group files under
            // different paths, each one having different configuration settings.
            // Each resource type name must be unique.
            // When loading CKFinder, the "type" querystring parameter can be used
            // to display a specific type only. If "type" is omitted in the URL,
            // the "DefaultResourceTypes" settings is used (may contain the
            // resource type names separated by a comma). If left empty, all types
            // are loaded.
            // 如果url不包含类型，则使用DefaultResourceTypes设置，资源类型名称用逗号分隔。
            DefaultResourceTypes = ""; // 所有类型被加载

            ResourceType type;
            var paths = Directory.GetDirectories(Request.MapPath(BaseUrl));
            foreach (var path in paths)
            {
                var dirName = new DirectoryInfo(path).Name;
                if (dirName == "_thumbs" || dirName == "Bin") continue;
                type = ResourceType.Add(dirName);
                type.Url = $"{BaseUrl}{dirName}/";
                type.Dir = BaseDir == "" ? "" : $"{BaseDir}{dirName}/";
                type.MaxSize = 0;
                if (AllowedExtensions != null)
                    type.AllowedExtensions = AllowedExtensions;
            }
            SubSetConfig();
            /*
            type = ResourceType.Add("Files");
            type.Url = BaseUrl + "files/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "files/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "7z", "aiff", "asf", "avi", "bmp", "csv", "doc", "docx", "fla", "flv", "gif", "gz", "gzip", "jpeg", "jpg", "mid", "mov", "mp3", "mp4", "mpc", "mpeg", "mpg", "ods", "odt", "pdf", "png", "ppt", "pptx", "pxd", "qt", "ram", "rar", "rm", "rmi", "rmvb", "rtf", "sdc", "sitd", "swf", "sxc", "sxw", "tar", "tgz", "tif", "tiff", "txt", "vsd", "wav", "wma", "wmv", "xls", "xlsx", "zip" };
            type.DeniedExtensions = new string[] { };

            type = ResourceType.Add("Images");
            type.Url = BaseUrl + "images/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "images/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "bmp", "gif", "jpeg", "jpg", "png" };
            type.DeniedExtensions = new string[] { };

            type = ResourceType.Add("Flash");
            type.Url = BaseUrl + "flash/";
            type.Dir = BaseDir == "" ? "" : BaseDir + "flash/";
            type.MaxSize = 0;
            type.AllowedExtensions = new string[] { "swf", "flv" };
            type.DeniedExtensions = new string[] { };
            */
            #endregion
        }

        // 用于子类自定义属性
        public virtual void SubSetConfig()
        { }
    }
}
