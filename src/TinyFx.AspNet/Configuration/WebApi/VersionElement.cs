using System;
using System.Collections.Generic;
using System.Text;
using TinyFx.Web;

namespace TinyFx.Configuration.AspNet.WebApi
{
    /// <summary>
    /// 版本控制
    /// </summary>
    public class VersionElement
    {
        public string Mode { get; set; }
        public VersionControlMode VersionMode { get { return ParseMode(Mode); } }
        private VersionControlMode ParseMode(string mode)
        {
            if (string.IsNullOrEmpty(mode))
                return VersionControlMode.None;
            var ret = VersionControlMode.None;
            mode = mode.ToLower();
            switch (mode)
            {
                case "url":
                case "urlparameter":
                    ret = VersionControlMode.UrlParameter;
                    break;
                case "header":
                case "requestheader":
                    ret = VersionControlMode.RequestHeader;
                    break;
                case "contenttype":
                    ret = VersionControlMode.ContentType;
                    break;
            }
            return ret;
        }
    }
}
