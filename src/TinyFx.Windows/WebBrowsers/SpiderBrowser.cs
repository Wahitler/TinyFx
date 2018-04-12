using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;


namespace TinyFx.Windows.WebBrowsers
{
    /// <summary>
    /// 网页蜘蛛抓取器
    /// </summary>
    public class SpiderBrowser : ApplicationContext
    {
        private Thread _thread;
        private ExtendedWebBrowser _ieBrowser;
        /// <summary>
        /// 是否初始化
        /// </summary>
        public bool Inited { get; set; } 
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        public void GetImage()
        {
            // TODO: WebBrowser 获取验证码图片
            mshtml.HTMLDocument html = (mshtml.HTMLDocument)_ieBrowser.Document.DomDocument;
            //下面代码中，获取图片的方式有很多，因为比较简单，我就不列举了，直接用ID来做为例子的  
            mshtml.IHTMLControlElement img = (mshtml.IHTMLControlElement)_ieBrowser.Document.Images["MzImgExpPwd"].DomElement;
            mshtml.IHTMLControlRange range = (mshtml.IHTMLControlRange)((mshtml.HTMLBody)html.body).createControlRange();
            range.add(img);
            range.execCommand("Copy", false, null);
            img = null;  range = null;  html = null;
            if (Clipboard.ContainsImage())
            {
                var ret = Clipboard.GetImage();
            }
            else
            {
                MessageBox.Show("执行不成功");
            }
            Clipboard.Clear();
        }
        /// <summary>
        /// 容器窗体
        /// </summary>
        public SpiderContainerForm ContainerForm { get; internal set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="visible"></param>
        public SpiderBrowser(bool visible = false)
        {
            _thread = new Thread(new ThreadStart(
                delegate{
                    Init(visible);
                    Application.Run(this); 
                }));
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        private int _counter = 0;
        private Uri _lastUrl;
        private void Init(bool visible)
        {
            _ieBrowser = new ExtendedWebBrowser();
            //_ieBrowser.ScriptErrorsSuppressed = false;
            //_ieBrowser.ObjectForScripting = this;
            _ieBrowser.Navigating += new WebBrowserNavigatingEventHandler(IEBrowser_Navigating);
            //_ieBrowser.Navigated += new WebBrowserNavigatedEventHandler(IEBrowser_Navigated);
            _ieBrowser.DocumentTitleChanged += new EventHandler(IEBrowser_DocumentTitleChanged);
            _ieBrowser.StatusTextChanged += new EventHandler(IEBrowser_StatusTextChanged);
            _ieBrowser.StartNewWindow += new EventHandler<BrowserExtendedNavigatingEventArgs>(IEBrowser_StartNewWindow);
            _ieBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(IEBrowser_DocumentCompleted);

            //if (visible)
            //{
            ContainerForm = new SpiderContainerForm();
            _ieBrowser.Dock = DockStyle.Fill;
            ContainerForm.AddWebBrowser(_ieBrowser);
            ContainerForm.Visible = visible;
            //}

            Inited = true;
        }

        void IEBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            System.Threading.Interlocked.Increment(ref _counter);
            if (ContainerForm != null && _ieBrowser.Document != null)
                ContainerForm.SetAddressText(this._ieBrowser.Document.Url.ToString());
        }
        //void IEBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        //{
        //    System.Threading.Interlocked.Increment(ref _counter);
        //    if(ContainerForm != null)
        //        ContainerForm.SetAddressText(this._ieBrowser.Document.Url.ToString());
        //}
        void IEBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            if (ContainerForm != null)
                ContainerForm.SetText(_ieBrowser.DocumentTitle);
        }
        void IEBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            if(ContainerForm != null)
                ContainerForm.SetStatusText(_ieBrowser.StatusText);
        }
        void IEBrowser_StartNewWindow(object sender, BrowserExtendedNavigatingEventArgs e)
        {
            e.Cancel = true;
            if ((int)e.NavigationContext != 262148)
            {
                ((ExtendedWebBrowser)sender).Navigate(e.Url);
            }
        }
        void IEBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            System.Threading.Interlocked.Decrement(ref _counter);
            if (_ieBrowser.ReadyState == WebBrowserReadyState.Complete)
                _lastUrl = e.Url;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="visible"></param>
        public void Show(bool visible = true) 
        {
            if (ContainerForm != null)
                ContainerForm.Visible = visible;
        }
    
        #region Operation
        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="url"></param>
        public void Navigate(string url)
        {
            if (_ieBrowser.InvokeRequired)
            {
                _ieBrowser.BeginInvoke(new Action<string>(Navigate), url);
            }
            else
            {
                if (String.IsNullOrEmpty(url)) return;
                if (url.Equals("about:blank")) return;
                if (!url.StartsWith("http://")) url = "http://" + url;
                _ieBrowser.Navigate(new Uri(url));
            }
        }
        /// <summary>
        /// 执行对象方法
        /// </summary>
        /// <param name="controlId"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        public void InvokeMember(string controlId, string methodName, params object[] parameters)
        {
            if (_ieBrowser.InvokeRequired)
            {
                _ieBrowser.Invoke(new Action<string, string, object[]>(InvokeMember), controlId, methodName, parameters);
            }
            else
            {
                this._ieBrowser.Document.GetElementById(controlId).InvokeMember(methodName, parameters);
            }
        }
        /// <summary>
        /// 获取焦点
        /// </summary>
        /// <param name="controlId"></param>
        public void Focus(string controlId)
        {
            if (_ieBrowser.InvokeRequired)
            {
                _ieBrowser.Invoke(new Action<string>(Focus), controlId);
            }
            else
            {
                _ieBrowser.Document.GetElementById(controlId).Focus();
            }
        }
        /// <summary>
        /// 输入文本
        /// </summary>
        /// <param name="controlId"></param>
        /// <param name="value"></param>
        public void InputInnerText(string controlId, string value)
        {
            if (_ieBrowser.InvokeRequired)
            {
                _ieBrowser.Invoke(new Action<string, string>(InputInnerText), controlId, value);
            }
            else
            {
                _ieBrowser.Document.GetElementById(controlId).InnerText = value;
            }
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="checkData"></param>
        /// <param name="callback"></param>
        public void GetHTML(IEnumerable<HtmlCheckData> checkData, Action<string> callback)
        {
            if (this._ieBrowser.InvokeRequired)
            {
                var action = new Action<IEnumerable<HtmlCheckData>, Action<string>>(GetHTML);
                _ieBrowser.Invoke(action, checkData, callback);
            }
            else
            {
                bool success = true;
                string html = null;

                while (_ieBrowser != null && _ieBrowser.IsBusy)
                {
                    Application.DoEvents();
                }
                if (_ieBrowser == null)
                {
                    callback(null);
                    return;
                }
                if (_ieBrowser.ReadyState == WebBrowserReadyState.Complete)
                {
                    //mshtml.HTMLDocumentClass doc = (mshtml.HTMLDocumentClass)this._ieBrowser.Document.DomDocument;
                    mshtml.HTMLDocument doc = (mshtml.HTMLDocument)this._ieBrowser.Document.DomDocument;
                    html = doc.documentElement.outerHTML;
                    if (!string.IsNullOrEmpty(html))
                    {
                        if (checkData != null)
                        {
                            foreach (HtmlCheckData data in checkData)
                            {
                                switch (data.Option)
                                {
                                    case HtmlCheckOption.ContainsString:
                                        string checkStr = data.Data == null ? null : data.Data.ToString();
                                        success = string.IsNullOrEmpty(checkStr) ? true : html.Contains(checkStr);
                                        break;
                                }
                                if (!success) break;
                            }
                        }
                    }
                    else
                    {
                        Trace.WriteLine("------------------");
                        Trace.WriteLine("html为空");
                        success = false;
                    }
                }
                else
                {
                    Trace.WriteLine("------------------");
                    Trace.WriteLine(_ieBrowser.ReadyState);
                    Trace.WriteLine(_ieBrowser.IsBusy);
                    success = false;
                }

                if (success)
                    callback(html);
                else
                    callback(null);
            }
        }
        #endregion
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
                ContainerForm = null;
                return;
            }
            base.Dispose(disposing);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class HtmlCheckData
    {
        /// <summary>
        /// 
        /// </summary>
        public HtmlCheckOption Option { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <param name="data"></param>
        public HtmlCheckData(HtmlCheckOption option, object data = null)
        {
            Option = option;
            Data = data;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum HtmlCheckOption
    {
        /// <summary>
        /// 包含标识字符串
        /// </summary>
        ContainsString
    }
    /*
     * 
     */
}
