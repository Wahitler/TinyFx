using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TinyFx.Net
{
    /// <summary>
    /// HTTP POST 请求类
    /// </summary>
    public class HttpPostRequest : HttpRequestBase
    {
        /// <summary>
        /// Post Method模式
        /// </summary>
        public HttpPostMethod PostMethod { get; set; } = HttpPostMethod.Unknow;

        /// <summary>
        /// 上一个AspNet WebForm页面的HTML
        /// </summary>
        public string RefererAspNetWebFormHtml { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="encoding">字符集</param>
        /// <param name="cookies">Cookies</param>
        public HttpPostRequest(string url, Encoding encoding = null, CookieCollection cookies = null) 
            : base(url, encoding, cookies)
        {
            Method = "POST";
        }

        /// <summary>
        /// 表单数据
        /// </summary>
        public Dictionary<string, string> FormDatas = new Dictionary<string, string>();

        /// <summary>
        /// 上传文件列表
        /// </summary>
        public List<(string key, string fileName, Stream fileStream)> UploadFiles = new List<(string key, string fileName, Stream fileStream)>();

        /// <summary>
        /// 提交文本内容，包含：text, json, javascript, xml, html
        /// </summary>
        public string PostContent { get; set; }

        /// <summary>
        /// 添加上传文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="fileStream"></param>
        public void AddUploadFile(string filename, Stream fileStream = null)
        {
            var key = Path.GetFileName(filename);
            fileStream = fileStream ?? new FileStream(filename, FileMode.Open, FileAccess.Read);
            UploadFiles.Add((key, key, fileStream));
        }

        /// <summary>
        /// 添加上传文件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileName"></param>
        /// <param name="fileStream"></param>
        public void AddUploadFile(string key, string fileName, Stream fileStream = null)
            => UploadFiles.Add((key, fileName, fileStream));
        
        /*
        /// <summary>
        /// 加入上传文件
        /// </summary>
        /// <param name="file"></param>
        public void AddUploadFile(string file)
        {
            // TODO: HttpPostRequest 获取项目目录,判断项目类型
            //HttpContext.Current.Server.MapPath("~/App_Data");
            //System.Web.Hosting.HostingEnvironment.MapPath("~/SomePath");
        }
        */

        /// <summary>
        /// 添加表单数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddFormData(string name, string value)
            => FormDatas.Add(name, value);

        /// <summary>
        /// 获得Response对象
        /// </summary>
        /// <returns></returns>
        public override HttpWebResponse GetResponse()
        {
            var request = CreateRequest();
            if (!string.IsNullOrEmpty(RefererAspNetWebFormHtml))
            {
                AddFormData("__VIEWSTATE", GetViewStateFromHtml(RefererAspNetWebFormHtml));
                AddFormData("__EVENTVALIDATION", GetEventValidationFromHtml(RefererAspNetWebFormHtml));
            }
            switch (PostMethod)
            {
                case HttpPostMethod.FormData:
                    PostFormData(request);
                    break;
                case HttpPostMethod.FormUrlencoded:
                    PostFormUrlencoded(request);
                    break;
                case HttpPostMethod.Text:
                case HttpPostMethod.JSON:
                case HttpPostMethod.Javascript:
                case HttpPostMethod.Xml:
                case HttpPostMethod.HTML:
                    PostRaw(request);
                    break;
                case HttpPostMethod.Binary:
                    throw new Exception("暂不支持Binary");
            }
            return request.GetResponse() as HttpWebResponse;
        }

        protected override string GetContentType()
        {
            if (PostMethod == HttpPostMethod.Unknow)
            {
                PostMethod = HttpPostMethod.FormUrlencoded;
                if (UploadFiles.Count > 0)
                    PostMethod = HttpPostMethod.FormData;
            }
            string ret = null;
            switch (PostMethod)
            {
                case HttpPostMethod.FormData:
                    ret = $"{HttpPostContentType.FormData}; boundary=----{DateTime.Now.Ticks.ToString("x")}";
                    break;
                case HttpPostMethod.FormUrlencoded:
                    ret = HttpPostContentType.FormUrlencoded;
                    if (Encoding == Encoding.UTF8)
                        ret += ";charset:UTF-8";
                    break;
                case HttpPostMethod.Binary:
                    ret = HttpPostContentType.Binary;
                    break;
                case HttpPostMethod.Text:
                    ret = HttpPostContentType.Text;
                    break;
                case HttpPostMethod.JSON:
                    ret = HttpPostContentType.JSON;
                    break;
                case HttpPostMethod.Javascript:
                    ret = HttpPostContentType.Javascript;
                    break;
                case HttpPostMethod.Xml:
                    ret = HttpPostContentType.Xml;
                    break;
                case HttpPostMethod.HTML:
                    ret = HttpPostContentType.HTML;
                    break;
            }
            return ret;
        }

        #region PostMethods
        private void PostFormData(HttpWebRequest request)
        {
            var buffer = GetFormDataBytes();
            using (var stream = request.GetRequestStream())
            {
                stream.Write(buffer, 0, buffer.Length);
            }
        }
        private byte[] GetFormDataBytes()
        {
            var dataString = FormDatas.Select((item) => {
                return $"{item.Key}={item.Value}";
            });
            return Encoding.GetBytes(string.Join("&", dataString));
        }
        private void PostFormUrlencoded(HttpWebRequest request)
        {
            string boundary = "----" + DateTime.Now.Ticks.ToString("x");//分隔符
            //文本数据模板  
            string dataFormdataTemplate =
                "\r\n--" + boundary +
                "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                "\r\n\r\n{1}";
            //请求流  
            var postStream = new MemoryStream();
            foreach (var item in FormDatas)
            {
                string formdata = string.Format(dataFormdataTemplate, item.Key, item.Value);
                ////第一行不需要换行
                byte[] formdataBytes = (postStream.Length == 0)
                    ? Encoding.GetBytes(formdata.Substring(2, formdata.Length - 2))
                    : Encoding.GetBytes(formdata);
                postStream.Write(formdataBytes, 0, formdataBytes.Length);
            }

            //文件数据模板  
            string fileFormdataTemplate =
                "\r\n--" + boundary +
                "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                "\r\nContent-Type: application/octet-stream" +
                "\r\n\r\n";
            foreach (var item in UploadFiles)
            {
                string formdata = string.Format(fileFormdataTemplate, item.key, item.fileName);
                //第一行不需要换行
                byte[] formdataBytes = (postStream.Length == 0)
                    ? Encoding.GetBytes(formdata.Substring(2, formdata.Length - 2))
                    : Encoding.GetBytes(formdata);
                postStream.Write(formdataBytes, 0, formdataBytes.Length);

                if (item.fileStream != null && item.fileStream.Length > 0)
                {
                    using (var stream = item.fileStream)
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            postStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            // 结尾  
            var footer = Encoding.GetBytes("\r\n--" + boundary + "--\r\n");
            postStream.Write(footer, 0, footer.Length);
            request.ContentLength = postStream.Length;

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;
                //直接写入流  
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                ////debug  
                //postStream.Seek(0, SeekOrigin.Begin);  
                //StreamReader sr = new StreamReader(postStream);  
                //var postStr = sr.ReadToEnd();  
            }
            postStream.Close();//关闭文件访问  
            #endregion
        }

        private void PostRaw(HttpWebRequest request)
        {
            if (string.IsNullOrEmpty(PostContent))
                return;
            var buffer = Encoding.GetBytes(PostContent);
            using (var stream = request.GetRequestStream())
                stream.Write(buffer, 0, buffer.Length);
        }
        #endregion

        #region AspNet WebForm页面
        private const string _viewStateFlag = "id=\"__VIEWSTATE\" value=\"";
        private const string _eventValidationFlag = "id=\"__EVENTVALIDATION\" value=\"";

        // 获取AspNet页面中的ViewState
        private string GetViewStateFromHtml(string html)
            => GetStringFromAspNetHtml(html, _viewStateFlag);

        // 获取AspNet页面中的EventValidation
        private string GetEventValidationFromHtml(string html)
            => GetStringFromAspNetHtml(html, _eventValidationFlag);

        private string GetStringFromAspNetHtml(string html, string flag)
        {
            string ret = string.Empty;
            int start = html.IndexOf(flag);
            if (start >= 0)
            {
                start += flag.Length;
                int end = html.IndexOf("\"", start) - start;
                ret = html.Substring(start, end);
            }
            return ret;
        }
        #endregion
    }

}
