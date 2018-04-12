using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace TinyFx.AspNet.WebApi.Results
{
    public class FileUploadResult : IHttpActionResult
    {
        private readonly ApiController _controller;
        public HttpRequestMessage Request { get { return _controller.Request; } }
        public string ServerUploadFolder { get; private set; }
        public FileUploadResult(ApiController controller, string serverUploadFolder)
        {
            _controller = controller;
            ServerUploadFolder = serverUploadFolder;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }
            MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);

            // Read the MIME multipart asynchronously content using the stream provider we just created.
            Request.Content.ReadAsMultipartAsync(streamProvider);

            // Create response
            //var result = new UploadFileDto
            //{
            //    FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
            //    Submitter = streamProvider.FormData["submitter"]
            //};
            var result = "上传成功";
            var response = Request.CreateResponse(HttpStatusCode.OK, result, new JsonMediaTypeFormatter());
            return Task.FromResult(response);
        }
    }

    /// <summary>
    /// 上传文件返回
    /// </summary>
    public class UploadFileDto
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 保存到服务器的文件
        /// </summary>
        public List<UploadFileItemDto> Files { get; set; }
    }
    /// <summary>
    /// 上传文件返回项
    /// </summary>
    public class UploadFileItemDto
    {
        /// <summary>
        /// 原始文件名
        /// </summary>
        public string OriginalFileName { get; set; }
        /// <summary>
        /// 服务器保存路径（含文件名）
        /// </summary>
        public string ServerFilePath { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
    }

}
