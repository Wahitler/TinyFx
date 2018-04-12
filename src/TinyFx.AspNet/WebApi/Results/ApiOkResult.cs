using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;


namespace TinyFx.AspNet.WebApi.Results
{
    /// <summary>
    /// Api统一结构
    /// </summary>
    [DataContract]
    [JsonObject]
    public class ApiOkResult
    {
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        [JsonProperty(PropertyName = "code", Required = Required.Always)]
        public string Code => ApiErrorCode.OK;

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }
        public ApiOkResult() { }
        public ApiOkResult(object data)
        {
            Data = data;
        }
    }

}
