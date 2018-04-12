using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;

namespace TinyFx.AspNet.WebApi.Results
{
    /// <summary>
    /// WebApi统一返回结构，客户端总是获取次结构
    /// code必须有，0为正确，其他为自定义业务逻辑错误
    /// ActionFilter中封装不包含异常信息
    /// ExceptionFilter中封装处理TinyApiException（业务逻辑错误），不处理未处理异常。根据配置确定是否返回异常信息
    /// </summary>
    [JsonObject]
    public class ApiErrResult
    {
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
        private string _code;
        /// <summary>
        /// Code
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public string Code
        {
            get { return _code; }
            set
            {
                if (value == null || value == ApiErrorCode.OK)
                    throw new Exception("错误返回结果Code不能等于null或0(OK)!");
                _code = value;
            }
        }
        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }
        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "expType", NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionType { get; set; }
        [JsonProperty(PropertyName = "expMsg", NullValueHandling = NullValueHandling.Ignore)]
        public string ExceptionMessage { get; set; }
        [JsonProperty(PropertyName = "expTrace", NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { get; set; }

        private Exception _exception;
        [JsonIgnore]
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
                if (_exception != null)
                {
                    ExceptionMessage = _exception.Message;
                    ExceptionType = _exception.GetType().FullName;
                    StackTrace = _exception.StackTrace;
                }
            }
        }
        public ApiErrResult(string code = ApiErrorCode.Error, string message = null, Exception exp = null)
        {
            Code = code;
            Message = message;
            Exception = exp;
        }
        public void ThrowError()
            => throw new ApiErrorException(this);
        public void ClearException()
        {
            Exception = null;
            ExceptionMessage = null;
            StackTrace = null;
            ExceptionType = null;
        }
        //public HttpError GetHttpError()
        //{
        //    var ret = new HttpError();
        //    ret.Add("status", StatusCode);
        //    ret.Add("code", Code);
        //    ret.Add("data", Data);
        //    ret.Add("msg", Message);
        //    if (ExceptionType != null)
        //        ret.Add("expType", ExceptionType);
        //    if (ExceptionMessage != null)
        //        ret.Add("expMsg", ExceptionMessage);
        //    if (StackTrace != null)
        //        ret.Add("expTrace", StackTrace);
        //    return ret;
        //}
    }
}
