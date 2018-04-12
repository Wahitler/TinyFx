using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TinyFx;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Web;
using TinyFx.AspNet.WebApi;
using TinyFx.AspNet.WebApi.Authentication;

namespace WebDemo.Apis
{
    /// <summary>
    /// 样例API
    /// </summary>
    public class DemoController : TinyApiController
    {
        #region Get
        /// <summary>
        /// AllowAnonymous 不进行安全验证
        /// 返回jwt
        /// Get开头，HttpGet可省略
        /// </summary>
        //[Route("get1")]
        [HttpGet]
        [AllowAnonymous]
        public string Get1(int uid, string pwd)
            => JwtUtil.EncodeToken(uid.ToString(), pwd);
        /// <summary>
        /// 接收返回JSON字符串
        /// 前端需要使用 JSON.stringify 转成json字符串
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public string Get2(string strJson)
        {
            var user = SerializerUtil.DeserializeJson<UserIpo>(strJson);
            user.Birthday = DateTime.Now;
            //return SerializerUtil.SerializeJson(user);
            return JsonConvert.SerializeObject(user);
        }
        /// <summary>
        /// GET时参数复杂类型[FromUri]不能省略
        /// 返回IHttpActionResult，不指定jsonsetting则使用系统默认而不是全局设置
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IHttpActionResult Get3([FromUri]UserIpo user)
            => Json<dynamic>(new { UserId = 1, Token = user.UserName, DefValue = default(string), DtValue = DateTime.Now });
        /// <summary>
        /// 数组参数，返回JSON对象
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public object Get4([FromUri]List<int> users)
            => new { UserID = users[1], UserName = "ccc", DefValue = default(string), DtValue = DateTime.Now };
        /// <summary>
        /// 将请求重定向
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get5(string baseUrl)
            => Redirect($"{baseUrl}/Demo/get3?UserID=123&UserName=abc&Birthday=2000-01-01");

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get6(int id)
        {
            if (id == 1)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent($"id={id}"),
                    ReasonPhrase = "原因。。。。"
                };
                throw new HttpResponseException(resp);
            }
            else if (id == 2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"id={id}");
            }
            else if (id == 3)
            {
                var err = new HttpError
                {
                    { "key1", id },
                    { "key2", "bbb" }
                };
                //err.StackTrace = "StackTrace....";
                //err.ExceptionType = "MyException";
                //err.ExceptionMessage = "错了错了";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, err);
            }
            else if (id == 4)
            {
                throw new Exception("未处理。。。");
            }
            else if (id == 5)
            {
                WebApiUtil.ThrowApiErrorMessage("业务逻辑错误。.");
            }
            else if (id == 6)
                return Request.CreateResponse(new
                {
                    CurrentDirectory = Environment.CurrentDirectory,
                    BaseDirectory = AppContext.BaseDirectory,
                    BinDirectory = HttpRuntime.BinDirectory,
                    GetAssemblyDirectory = TinyFxUtil.GetAssemblyDirectory(),
                    GetAppDirectory = TinyFxUtil.GetAppDirectory()
                });
            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }
        #endregion

        #region Post

        /// <summary>
        /// FromBody不能用于基本数据类型，并且只能用一次
        /// </summary>
        /// <param name="user1"></param>
        /// <param name="user2"></param>
        /// <returns></returns>
        [HttpPost]
        public UserIpo Post1([FromUri]UserIpo user1, [FromBody]UserIpo user2)
        {
            return new UserIpo
            {
                UserID = user2.UserID,
                UserName = user1.UserName,
                Birthday = DateTime.Now
            };
        }
        /// <summary>
        /// contentType: 'application/json'
        /// 客户端传输json字符串对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public dynamic Post2([FromBody]JObject obj)
            => Content(HttpStatusCode.BadRequest, new { name = obj["name"].ToObject<string>() });
        /// <summary>
        /// dynamic 只能使用在POST且只能有一个
        /// 必须使用 contentType: 'application/json',
        /// 前端如果直接传json对象，则data类型为 Newtonsoft.Json.Linq.JObject
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Post3(dynamic data)
        {
            return BadRequest("操作错误~~~" + data.name);
        }
        /// <summary>
        /// 复合参数
        /// contentType: 'application/json',
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual string Post4(dynamic input)
        {
            //var user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserIpo>(Convert.ToString(input.PostData));
            return input.ID + ":" + input.PostData.userName;
        }

        /// <summary>
        /// 简单类型默认从url获取
        /// data: { "": "test" },
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post5([FromBody]string name)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("return " + name),
                RequestMessage = Request,
            };
        }
        /// <summary>
        /// 数组参数
        /// contentType: 'application/json',
        /// data: JSON.stringify(["1", "2", "3", "4"]),
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public HttpResponseMessage Post6(int[] ids)
            => Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ids[0].ToString());
        #endregion
    }
    public class UserIpo
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
    }
}