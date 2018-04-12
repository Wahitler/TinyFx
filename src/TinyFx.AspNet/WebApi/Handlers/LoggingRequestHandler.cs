using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinyFx.Log4net;

namespace TinyFx.AspNet.WebApi.Handlers
{
    /// <summary>
    /// 记录请求和相应消息
    /// </summary>
    public class LoggingRequestHandler : DelegatingHandler
    {
        private bool _logRequest;
        private bool _logResponse;
        private static ITinyLog _logger = null;
        public LoggingRequestHandler(bool logRequest, bool logResponse, string logger)
        {
            _logRequest = logRequest;
            _logResponse = logResponse;
            if (_logger == null)
                _logger = LogUtil.GetLogger(logger);
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_logRequest && request.Content != null)
            {
                string requestContent = await request.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(requestContent))
                    _logger.Debug("Debug模式Request消息内容: " + requestContent);
            }
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (_logResponse && response.Content != null)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseContent))
                    _logger.Debug("Debug模式Response消息内容: " + responseContent);
            }
            return response;
        }
    }
}
