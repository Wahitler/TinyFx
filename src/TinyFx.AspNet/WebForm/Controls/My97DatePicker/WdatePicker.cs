using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections;
using System.Drawing;

namespace TinyFx.AspNet.WebForm.Controls.My97DatePicker
{
    /// <summary>
    /// 日期选择控件
    /// </summary>
    [DefaultProperty("DateFormat")]
    [ToolboxData("<{0}:WdatePicker runat=server></{0}:WdatePicker>")]
    //[Designer(typeof(WdatePickerDesigner))]
    [ToolboxBitmap(typeof(WdatePicker), "SwfObject.bmp")]
    public class WdatePicker : CompositeControl
    {
        private const string WDATEPICKER_SETTINGS = "WdatePicker Settings";
        private const string WdatePicker_Path = "~/TinyFx/AspNet/WebForm/Controls/My97DatePicker";
        private TextBox _txtDate;
        //private HiddenField _hidValue;
        private HtmlImage _imgButton;

        #region Properties

        /// <summary>
        /// 获取或设置时间格式
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("时间格式"), DefaultValue("yyyy-MM-dd"), Bindable(true)]
        public string DateFormat
        {
            get
            {
                object o = ViewState["DateFormat"];
                return (o == null) ? "yyyy-MM-dd" : (string)o;
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }

        /// <summary>
        /// 获取或设置默认的起始日期
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("默认的起始日期"), Bindable(true)]
        public DateTime? StartDate
        {
            get
            {
                DateTime? ret = null;
                object o = ViewState["StartDate"];
                if (o != null) ret = DateTime.Parse(o.ToString());
                return ret;
            }
            set
            {
                ViewState["StartDate"] = value;
            }
        }

        /// <summary>
        /// 获取或设置最小日期
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("最小日期"), Bindable(true)]
        public DateTime? MinDate
        {
            get
            {
                DateTime? ret = null;
                object o = ViewState["MinDate"];
                if (o != null) ret = DateTime.Parse(o.ToString());
                return ret;
            }
            set
            {
                ViewState["MinDate"] = value;
            }
        }

        /// <summary>
        /// 获取或设置最大日期
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("最大日期"), Bindable(true)]
        public DateTime? MaxDate
        {
            get
            {
                DateTime? ret = null;
                object o = ViewState["MaxDate"];
                if (o != null) ret = DateTime.Parse(o.ToString());
                return ret;
            }
            set
            {
                ViewState["MaxDate"] = value;
            }
        }

        /// <summary>
        /// 获取或设置显示样式
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("显示样式"), DefaultValue(typeof(WdatePickerShowMode), "InnerButton")]
        public WdatePickerShowMode ShowMode
        {
            get
            {
                EnsureChildControls();
                object o = ViewState["ShowMode"];
                return (o == null) ? WdatePickerShowMode.InnerButton : (WdatePickerShowMode)o;
            }
            set
            {
                EnsureChildControls();
                ViewState["ShowMode"] = value;
                CreateChildControls();
            }
        }

        /// <summary>
        /// 获取或设置按钮ID，如果ShowMode属性为CustomButton则需要设定此属性
        /// </summary>
        [Description("按钮ID，如果ShowMode属性为CustomButton则需要设定此属性"), DefaultValue("")]
        [Category(WDATEPICKER_SETTINGS)]
        public string ImageButtonID
        {
            get
            {
                object o = ViewState["ImageButtonID"];
                return (o == null) ? string.Empty : (string)o;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    ShowMode = WdatePickerShowMode.CustomButton;
                ViewState["ImageButtonID"] = value;
            }
        }

        /// <summary>
        /// 获取或设置每周的第一天
        /// </summary>
        [Description("获取或设置每周的第一天"), DefaultValue(typeof(DayOfWeek), "Sunday")]
        [Category(WDATEPICKER_SETTINGS)]
        public DayOfWeek FirstDayOfWeek
        {
            get
            {
                object o = ViewState["FirstDayOfWeek"];
                return (o == null) ? DayOfWeek.Sunday : (DayOfWeek)o;
            }
            set
            {
                ViewState["FirstDayOfWeek"] = value;
            }
        }

        /// <summary>
        /// 获取或设置是否只能通过控件选择日期
        /// </summary>
        [Description("获取或设置是否只能通过控件选择日期"), DefaultValue(false)]
        [Category(WDATEPICKER_SETTINGS)]
        public bool ReadOnly
        {
            get
            {
                object o = ViewState["TextBoxReadOnly"];
                return (o == null) ? false : (bool)o;
            }
            set
            {
                ViewState["TextBoxReadOnly"] = value;
            }
        }

        /// <summary>
        /// 获取或设置选定的日期
        /// </summary>
        [Description("选定的日期"), Bindable(true)]
        [Category(WDATEPICKER_SETTINGS)]
        public DateTime? SelectedDate
        {
            get
            {
                EnsureChildControls();
                DateTime? ret = null;
                if (!string.IsNullOrEmpty(_txtDate.Text))
                    ret = DateTime.ParseExact(_txtDate.Text, DateFormat, CultureInfo.InvariantCulture);
                return ret;
            }
            set
            {
                EnsureChildControls();
                _txtDate.Text = (value == null) ? string.Empty : value.Value.ToString(DateFormat);
            }
        }

        /// <summary>
        /// 输入框客户端ID，用户js客户端获取输入的值
        /// </summary>
        public override string ClientID
        {
            get
            {
                return _txtDate.ClientID;
            }
        }

        #endregion

        #region 内部控件属性
        /// <summary>
        /// 输入框宽度
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("输入框宽度")]
        public override Unit Width
        {
            get
            {
                EnsureChildControls();
                return _txtDate.Width;
            }
            set
            {
                EnsureChildControls();
                _txtDate.Width = value;
            }
        }

        /// <summary>
        /// 获取或设置文本框CSS类
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("获取或设置文本框CSS类")]
        public override string CssClass
        {
            get
            {
                EnsureChildControls();
                return _txtDate.CssClass;
            }
            set
            {
                EnsureChildControls();
                _txtDate.CssClass = value;
            }
        }

        /// <summary>
        /// 获取样式特性集合
        /// </summary>
        [Category(WDATEPICKER_SETTINGS)]
        [Description("获取样式特性集合")]
        public new CssStyleCollection Style
        {
            get
            {
                EnsureChildControls();
                return _txtDate.Style;
            }
        }
        #endregion

        //配置信息
        private Hashtable _configs
        {
            get
            {
                object o = ViewState["Configs"];
                if (o == null) ViewState["Configs"] = new Hashtable();
                return (Hashtable)ViewState["Configs"];
            }
        }

        /// <summary>
        /// 设置WdatePicker的配置
        /// </summary>
        /// <param name="name">配置名</param>
        /// <param name="value">配置值</param>
        /// <param name="isMark">是否需要添加单引号</param>
        public void SetConfig(string name, string value, bool isMark = true)
        {
            _configs[name] = new WdatePickerConfigItem(value, isMark);
        }

        private string GetScript()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append("WdatePicker({");
            ret.AppendFormat("el:'{0}',", this._txtDate.ClientID);
            //ret.AppendFormat("vel:'{0}',", this._hidValue.ClientID);
            //ret.Append("lang:'zh-cn',");
            //ret.Append("skin:'default',");
            if (StartDate.HasValue)
                ret.AppendFormat("startDate:'{0}',", StartDate.Value);
            if (MinDate.HasValue)
                ret.AppendFormat("minDate:'{0}',", MinDate.Value);
            if (MaxDate.HasValue)
                ret.AppendFormat("maxDate:'{0}',", MaxDate.Value);
            if (FirstDayOfWeek != DayOfWeek.Sunday)
                ret.AppendFormat("firstDayOfWeek:{0},", (int)FirstDayOfWeek);
            if (ReadOnly)
            {
                ret.Append("isShowClear:false,");
                ret.Append("readOnly:true,");
            }
            foreach (DictionaryEntry entry in _configs)
            {
                WdatePickerConfigItem item = (WdatePickerConfigItem)entry.Value;
                string format = item.IsMark ? "{0}:'{1}'," : "{0}:{1},";
                ret.AppendFormat(format, entry.Key, item.Value);
            }
            ret.AppendFormat("dateFmt:'{0}'", DateFormat);
            ret.Append("});");

            return ret.ToString();
        }

        #region Override Methods
        /// <summary>
        /// 
        /// </summary>
        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();

            _txtDate = new TextBox();
            _txtDate.ID = "txt";
            this.Controls.Add(_txtDate);

            //_hidValue = new HiddenField();
            //_hidValue.ID = "hid"; ;
            //this.Controls.Add(_hidValue);

            if (ShowMode == WdatePickerShowMode.Button)
            {
                _imgButton = new HtmlImage();
                _imgButton.ID = "img";
                this.Controls.Add(_imgButton);
            }
            else
                _imgButton = null;
        }

        /// <summary>
        /// 页面呈现前
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!Page.ClientScript.IsClientScriptIncludeRegistered(GetType(), "WdatePicker.js"))
            {
                Page.ClientScript.RegisterClientScriptInclude(GetType(), "WdatePicker.js",this.ResolveUrl($"{WdatePicker_Path}/WdatePicker.js"));
            }
            if (Context != null)
            {
                switch (ShowMode)
                {
                    case WdatePickerShowMode.None:
                        _txtDate.Attributes.Add("onfocus", GetScript());
                        break;
                    case WdatePickerShowMode.InnerButton:
                        _txtDate.Attributes.Add("onfocus", GetScript());
                        _txtDate.Attributes.Add("class", "Wdate");
                        break;
                    case WdatePickerShowMode.Button:
                        _imgButton.Src = $"{WdatePicker_Path}/WdatePicker.bmp";
                        _imgButton.Attributes.Add("style", "vertical-align: middle; cursor: pointer;");
                        _imgButton.Attributes.Add("onclick", GetScript());
                        break;
                    case WdatePickerShowMode.CustomButton:
                        if (!Page.ClientScript.IsStartupScriptRegistered(GetType(), _txtDate.ClientID))
                        {
                            string script = string.Format("document.getElementById(\"{0}\").onclick = function () {{ {1} }};", this.ImageButtonID, GetScript());
                            Page.ClientScript.RegisterStartupScript(GetType(), _txtDate.ClientID, script, true);
                        }
                        break;
                }
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// 页面呈现时
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (ReadOnly)
            {
                this._txtDate.Attributes["readonly"] = "true";
            }
            _txtDate.RenderControl(writer);
            //_hidValue.RenderControl(writer);
            if (_imgButton != null)
            {
                _imgButton.RenderControl(writer);
            }
        }
        #endregion

        /// <summary>
        /// WdatePicker配置值项
        /// </summary>
        [Serializable]
        internal class WdatePickerConfigItem
        {
            public WdatePickerConfigItem(string value, bool isMark)
            {
                Value = value;
                IsMark = isMark;
            }
            public string Value { get; set; }
            public bool IsMark { get; set; }
        }
    }

    /// <summary>
    /// WdatePicker显示模式
    /// </summary>
    public enum WdatePickerShowMode
    {
        /// <summary>
        /// 不显示按钮
        /// </summary>
        None,
        /// <summary>
        /// 内嵌显示按钮
        /// </summary>
        InnerButton,
        /// <summary>
        /// 后部显示按钮
        /// </summary>
        Button,
        /// <summary>
        /// 自定义按钮
        /// </summary>
        CustomButton
    }

}
