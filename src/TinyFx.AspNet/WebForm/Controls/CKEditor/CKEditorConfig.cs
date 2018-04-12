using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFx.AspNet.WebForm.Controls
{
    /// <summary>
    /// CKEditor配置
    /// </summary>
    [Serializable]
    public class CKEditorConfig
    {
        /// <summary>
        /// 是否使用此配置
        /// </summary>
        public bool IsValid { get; set; } = true;
        public TinyFx.Collections.SerializableDictionary<string, string> CustomConfigs = new Collections.SerializableDictionary<string, string>();
        public void AddConfig(string key, string value)
        {
            CustomConfigs.Add(key, value);
        }

        #region 核心配置
        public string customConfig { get; set; }
        public bool? readOnly { get; set; }
        public string toolbar { get; set; }

        public string height { get; set; }

        public string width { get; set; }

        public short? tabIndex { get; set; }
        public string extraPlugins { get; set; } // 'colorbutton,font'
        public string contentsCss { get; set; }
        /// <summary>
        /// Editor UI Color
        /// </summary>
        public string uiColor { get; set; }
        public string language { get; set; } = "zh-cn";
        public bool? startupFocus { get; set; }
        #endregion

        #region resize
        public string resize_dir { get; set; } // both
        public string resize_minWidth { get; set; }
        public string resize_minHeight { get; set; }
        public string resize_maxWidth { get; set; }
        #endregion

        #region Plugins Configs
        public List<CKEditorPlugin> Plugins = new List<CKEditorPlugin>();

        public void AddPlugin(CKEditorPlugin plugin) => Plugins.Add(plugin);

        #region autoGrow
        public string autoGrow_minHeight { get; set; }
        public string autoGrow_maxHeight { get; set; }
        public string autoGrow_bottomSpace { get; set; }
        #endregion

        /// <summary>
        /// 代码高亮显示
        /// extraPlugins: 'codesnippet',
        /// codeSnippet_theme: 'monokai_sublime'
        /// </summary>
        public string codeSnippet_theme { get; set; }
        /// <summary>
        /// 数学公式
        /// extraPlugins: 'mathjax',
        /// mathJaxLib = 'https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.0/MathJax.js?config=TeX-AMS_HTML'
        /// </summary>
        public string mathJaxLib { get; set; }
        #endregion

        #region CKFinder
        public string filebrowserBrowseUrl { get; set; }
        public string filebrowserUploadUrl { get; set; }
        public string filebrowserImageBrowseUrl { get; set; }
        public string filebrowserImageUploadUrl { get; set; }
        public string filebrowserFlashBrowseUrl { get; set; }
        public string filebrowserFlashUploadUrl { get; set; }
        #endregion
    }
}
