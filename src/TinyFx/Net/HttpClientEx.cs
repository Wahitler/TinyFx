using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace TinyFx.Net
{
    /// <summary>
    /// HttpClient扩展
    /// </summary>
    public class HttpClientEx : HttpClient
    {
        public DecompressionMethods Decompression { get; set; } = DecompressionMethods.None;
        private HttpClient GetClient()
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = Decompression };
            return new HttpClient(handler);
        }
        private HttpResponseMessage GetResponse()
        {
            return null;
        }
        private T ConvertResult<T>(HttpResponseMessage response)
        {
            var result = response.Content.ReadAsStreamAsync();
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(result.Result);

        }
        public T Get<T>()
        {
            var response = GetResponse();
            return ConvertResult<T>(response);
        }

        public void Post() { }
        public void Put() { }
        public void Delete() { }
        public void Send() { }
    }
}
