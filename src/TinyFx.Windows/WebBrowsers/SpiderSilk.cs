using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TinyFx.Windows.WebBrowsers
{
    /// <summary>
    /// 
    /// </summary>
    public class SpiderSilk:IDisposable
    {
        private SpiderBrowser _browser;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="visible"></param>
        public SpiderSilk(bool visible = false)
        {
            _browser = new SpiderBrowser(visible);
            int curr = 0;
            while (!_browser.Inited)
            {
                if (curr > 10)
                {
                    break;
                    throw new Exception("SpiderBrowser初始化出现异常。");
                }
                curr++;
                Thread.Sleep(200);
            }
        }
        #region Methods
        /// <summary>
        /// 页面导航
        /// </summary>
        /// <param name="url"></param>
        public void Navigate(string url)
        {
            _browser.Navigate(url);
        }

        /// <summary>
        /// 执行页面控件命令
        /// </summary>
        /// <param name="controlId"></param>
        /// <param name="methodName"></param>
        /// <param name="parameters"></param>
        public void InvokeMember(string controlId, string methodName, params object[] parameters)
        {
            _browser.InvokeMember(controlId, methodName, parameters);
        }

        /// <summary>
        /// 指定控件获取焦点
        /// </summary>
        /// <param name="controlId"></param>
        public void Focus(string controlId)
        {
            _browser.Focus(controlId);
        }

        /// <summary>
        /// 指定控件输入文本
        /// </summary>
        /// <param name="controlId"></param>
        /// <param name="value"></param>
        public void InputInnerText(string controlId, string value)
        {
            _browser.InputInnerText(controlId, value);
        }

        /// <summary>
        /// 指定控件触发点击事件
        /// </summary>
        /// <param name="controlId"></param>
        public void ClickControl(string controlId)
        {
            _browser.InvokeMember(controlId, "click");
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="checkData"></param>
        /// <param name="waitMilliseconds"></param>
        /// <returns></returns>
        public string GetHTML(IEnumerable<HtmlCheckData> checkData, int waitMilliseconds)
        {
            if (waitMilliseconds > 0) Thread.Sleep(waitMilliseconds);
            string ret = null;
            int curr = 0;
            while (curr < 10)
            {
                _browser.GetHTML(checkData, (o) => { ret = o; });
                if (!string.IsNullOrEmpty(ret)) break;
                Thread.Sleep(3000);
                curr++;
            }
            if (curr == 10)
            {
                throw new Exception("访问页面超时。");
            }
            return ret;
        }
        /// <summary>
        /// 获取HTML 
        /// </summary>
        /// <param name="waitMilliseconds"></param>
        /// <returns></returns>
        public string GetHTML(int waitMilliseconds)
        {
            return GetHTML(null, waitMilliseconds);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="checkData"></param>
        /// <returns></returns>
        public string GetHTML(IEnumerable<HtmlCheckData> checkData)
        {
            return GetHTML(checkData, 0);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="checkData"></param>
        /// <returns></returns>
        public string GetHTML(params HtmlCheckData[] checkData)
        {
            return GetHTML((IEnumerable<HtmlCheckData>)checkData, 0);
        }
        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="waitMilliseconds"></param>
        /// <param name="checkData"></param>
        /// <returns></returns>
        public string GetHTML(int waitMilliseconds, params HtmlCheckData[] checkData)
        {
            return GetHTML((IEnumerable<HtmlCheckData>)checkData, 0);
        }
        #endregion
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _browser.Dispose();
            _browser = null;
        }
    }
}
