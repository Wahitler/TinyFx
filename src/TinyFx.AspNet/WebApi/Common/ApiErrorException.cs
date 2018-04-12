using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet.WebApi.Results;

namespace TinyFx.AspNet.WebApi
{
    public class ApiErrorException : Exception
    {
        public ApiErrResult Result { get; set; }
        public ApiErrorException(string code = ApiErrorCode.Error, string message = null, Exception exp = null)
            => Result = new ApiErrResult(code, message, exp);
        public ApiErrorException(ApiErrResult result)
            => Result = result;
    }
}
