using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TinyFx.AspNet.WebApi
{
    /// <summary>
    /// 将上传的文件数据存放在MemoryStream中,便于后续自定义操作.
    /// 官方提供的MultipartFormDataStreamProvider默认直接存放成文件。
    /// 样例：
    /// var provider = new MultipartFormDataMemoryStreamProvider();
    /// await Request.Content.ReadAsMultipartAsync(provider);
    /// foreach(var file in provider.FileData){
    ///     Trace.WriteLine(file.Headers.ContentDisposition.FileName);//获取上传文件实际的文件名
    ///     Trace.WriteLine("Server file path: " + file.LocalFileName);//获取上传文件在服务上默认的文件名
    ///     var stream = ((MultipartFileDataStream)file).Stream; // 上传文件流
    /// }
    /// </summary>
    public class MultipartFormDataMemoryStreamProvider:MultipartFormDataStreamProvider
    {
        public MultipartFormDataMemoryStreamProvider() : base("/") { }
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (headers == null)
                throw new ArgumentNullException("headers");
            var ret = new MemoryStream();
            if (IsFileContent(parent, headers))
            {
                var item = new MultipartFileDataStream(headers, string.Empty, ret);
                this.FileData.Add(item);
            }
            return ret;
        }
        private bool IsFileContent(HttpContent parent, HttpContentHeaders headers)
        {
            var content = headers.ContentDisposition;
            if (content == null)
                throw new InvalidOperationException("Content-Disposition error");
            return !string.IsNullOrEmpty(content.FileName);
        }
    }

    public class MultipartFileDataStream : MultipartFileData, IDisposable
    {
        public Stream Stream { get; private set; }
        public MultipartFileDataStream(HttpContentHeaders header, string localFileName, Stream stream)
            :base(header, localFileName)
        {
            this.Stream = stream ?? throw new ArgumentNullException("stream");
        }
        public void  Dispose()
        {
            this.Stream.Dispose();
        }
    }

    /// <summary>
    /// 上传文件的信息
    /// </summary>
    public class UploadFileInfo
    {
        /// <summary>
        /// 客户端上传文件的实际文件名
        /// </summary>
        public string ClientFileName { get; set; }
        
        /// <summary>
        /// 上传文件在服务器上的默认文件名
        /// </summary>
        public string ServerFileName { get; set; }
        
        /// <summary>
        /// 上传的文件流
        /// </summary>
        public Stream Stream { get; set; }

        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="path">保存路径</param>
        /// <param name="isDispose">是否同时关闭Stream</param>
        public void SaveToFile(string path, bool isDispose = true)
        {
            TinyFx.IO.IOUtil.WriteStreamToFile(Stream, path);
            if (isDispose) Stream.Dispose();
        }
    }

    /// <summary>
    /// 客户端提交的MultipartFormData数据
    /// </summary>
    public class MultipartFormDataInfo
    {
        /// <summary>
        /// FormData数据
        /// </summary>
        public Dictionary<string, string> FormData = new Dictionary<string, string>();
        /// <summary>
        /// 上传文件信息
        /// </summary>
        public List<UploadFileInfo> FileData = new List<UploadFileInfo>();
    }
}
