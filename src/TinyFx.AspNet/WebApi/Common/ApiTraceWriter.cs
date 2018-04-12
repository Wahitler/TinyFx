using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;

namespace TinyFx.AspNet.WebApi
{
    /// <summary>
    /// 跟踪编写器
    /// config.Services.Replace(typeof(ITraceWriter), new TinyTraceWriter());
    /// </summary>
    public class ApiTraceWriter: ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            TraceRecord rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }
        protected void WriteTrace(TraceRecord rec)
        {
            // 操作。。。。
            var message = string.Format("{0};{1};{2}",
                rec.Operator, rec.Operation, rec.Message);
            System.Diagnostics.Trace.WriteLine(message, rec.Category);
        }
    }
}
