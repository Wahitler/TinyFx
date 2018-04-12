using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TinyFx.Windows.Components.SNTP;
using TinyFx.Windows.Win32;

namespace TinyFx.Windows.Components
{
    /// <summary>
    /// 从NTP/SNTP服务器检索数据的类，从 http://www.faqs.org/rfcs/rfc2030.html 查看协议详细信息。
    /// </summary>
    [DefaultEvent("QueryServerCompleted"), DefaultProperty("RemoteSNTPServer")]
    public class SNTPClient : Component
    {
        #region Fields

        private int _timeout;
        private AsyncOperation _asyncOperation = null;
        /// <summary>
        /// 默认服务器
        /// </summary>
        public static readonly RemoteSNTPServer DefaultServer = RemoteSNTPServer.Default;
        
        /// <summary>
        /// 默认的发送和接收使用的毫秒数。
        /// </summary>
        public const int DefaultTimeout = 500;

        /// <summary>
        /// 默认 NTP/SNTP 版本号。
        /// </summary>
        public const VersionNumber DefaultVersionNumber = VersionNumber.Version3;

        private readonly SendOrPostCallback _operationCompleted;
        private readonly WorkerThreadStartDelegate _threadStart;

		#endregion Fields 

		#region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public SNTPClient()
        {
            Initialize();
            _threadStart = new WorkerThreadStartDelegate(WorkerThreadStart);
            _operationCompleted = new SendOrPostCallback(AsyncOperationCompleted);
            Timeout = DefaultTimeout;
            VersionNumber = DefaultVersionNumber;
            UpdateLocalDateTime = true;
        }

		#endregion Constructors 

		#region Properties 

        /// <summary>
        /// 获取SNTPClient 是否繁忙。
        /// </summary>
        [Browsable(false)]
        public bool IsBusy
        {
            get;
            private set;
        }

        /// <summary>
        /// 使用默认服务器获取本地DateTime
        /// 如果有错误或异常，返回DateTime.MinValue
        /// </summary>
        public static DateTime Now
        {
            get { return GetNow(); }
        }

        /// <summary>
        /// 获取或设置服务器。
        /// </summary>
        [Description("使用的服务器"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Category("Connection")]
        public RemoteSNTPServer RemoteSNTPServer
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置发送和接受的Timeout时间（毫秒）。
        /// </summary>
        [Description("发送和接受的Timeout时间（毫秒）。")]
        [DefaultValue(DefaultTimeout),
        Category("Connection")]
        public int Timeout
        {
            get{return _timeout;}
            set
            {
                if (value < -1)
                    value = DefaultTimeout;
                _timeout = value;
            }
        }

        /// <summary>
        /// 获取或设置是否通过查询服务器时间更新本地时间。
        /// </summary>
        [Description("是否通过查询服务器时间更新本地时间。"),
        DefaultValue(true),
        Category("Actions")]
        public bool UpdateLocalDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置使用的 NTP/SNTP 版本。
        /// </summary>
        [Description("使用的 NTP/SNTP 版本。")]
        [DefaultValue(DefaultVersionNumber),
        Category("Connection")]
        public VersionNumber VersionNumber
        {
            get;
            set;
        }

		#endregion Properties 

		#region Delegates and Events 

        private delegate void WorkerThreadStartDelegate();
		
        /// <summary>
        /// 查询服务器成功完成时引发。
        /// </summary>
        [Description("查询服务器成功完成时引发。"), Category("Success")]
        public event EventHandler<QueryServerCompletedEventArgs> QueryServerCompleted;

		#endregion Delegates and Events 

		#region Methods 

        /// <summary>
        /// 获取当前本地时区相对于UTC的偏移量。
        /// </summary>
        public static TimeSpan GetCurrentLocalTimeZoneOffset()
        {
            return TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
        }

        /// <summary>
        /// 使用默认服务器获取本地DateTime
        /// 如果有错误或异常，返回DateTime.MinValue
        /// </summary>
        public static DateTime GetNow()
        {
            return GetNow(RemoteSNTPServer.Default, DefaultTimeout);
        }

        /// <summary>
        /// 使用指定服务器获取本地DateTime
        /// 如果有错误或异常，返回DateTime.MinValue
        /// </summary>
        /// <param name="remoteSNTPServer">使用的服务器</param>
        public static DateTime GetNow(RemoteSNTPServer remoteSNTPServer)
        {
            return GetNow(remoteSNTPServer, DefaultTimeout);
        }

        /// <summary>
        /// 使用默认服务器获取本地DateTime
        /// 如果有错误或异常，返回DateTime.MinValue
        /// </summary>
        /// <param name="timeout">用于发送和接收的超时毫秒。</param>
        /// <returns>本地真实日期时间</returns>
        public static DateTime GetNow(int timeout)
        {
            return GetNow(RemoteSNTPServer.Default, timeout);
        }

        /// <summary>
        /// 使用指定服务器获取本地DateTime
        /// 如果有错误或异常，返回DateTime.MinValue
        /// </summary>
        /// <param name="remoteSNTPServer">使用的服务器</param>
        /// <param name="timeout">用于发送和接收的超时毫秒。</param>
        /// <returns>本地真实日期时间</returns>
        public static DateTime GetNow(RemoteSNTPServer remoteSNTPServer, int timeout)
        {
            SNTPClient sntpClient = new SNTPClient();
            sntpClient.UpdateLocalDateTime = false;
            sntpClient.RemoteSNTPServer = remoteSNTPServer;
            sntpClient.Timeout = timeout;
            QueryServerCompletedEventArgs args = sntpClient.QueryServer();
            if (args.Succeeded)
                return DateTime.Now.AddSeconds(args.Data.LocalClockOffset);
            else
                return DateTime.MinValue;
        }

        /// <summary>
        /// 异步查询制定服务器。
        /// </summary>
        /// <returns>如果 SNTPClient不繁忙则返回True，否则false。</returns>
        public bool QueryServerAsync()
        {
            bool result = false;
            if (!IsBusy)
            {
                IsBusy = true;
                _asyncOperation = AsyncOperationManager.CreateOperation(null);
                _threadStart.BeginInvoke(null, null);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 引发的QueryServerCompleted事件。
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnQueryServerCompleted(QueryServerCompletedEventArgs e)
        {
            QueryServerCompleted?.Invoke(this, e);
        }

        private void AsyncOperationCompleted(object arg)
        {
            IsBusy = false;
            OnQueryServerCompleted((QueryServerCompletedEventArgs)arg);
        }

        private void Initialize()
        {
            if (RemoteSNTPServer == null)
                RemoteSNTPServer = DefaultServer;
        }
        
        private QueryServerCompletedEventArgs QueryServer()
        {
            QueryServerCompletedEventArgs result = new QueryServerCompletedEventArgs();
            Initialize();
            UdpClient client = null;
            try
            {
                // Configure and connect the socket.
                client = new UdpClient();
                IPEndPoint ipEndPoint = RemoteSNTPServer.GetIPEndPoint();
                client.Client.SendTimeout = Timeout;
                client.Client.ReceiveTimeout = Timeout;
                client.Connect(ipEndPoint);

                // Send and receive the data, and save the completion DateTime.
                SNTPData request = SNTPData.GetClientRequestPacket(VersionNumber);
                client.Send(request, request.Length);
                result.Data = client.Receive(ref ipEndPoint);
                result.Data.DestinationDateTime = DateTime.Now.ToUniversalTime();

                // Check the data
                if (result.Data.Mode == Mode.Server)
                {
                    result.Succeeded = true;

                    // Call other method(s) if needed
                    if (UpdateLocalDateTime)
                    {
                        UpdateTime(result.Data.LocalClockOffset);
                        result.LocalDateTimeUpdated = true;
                    }
                }
                else
                {
                    result.ErrorData = new ErrorData("The response from the server was invalid.");
                }
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorData = new ErrorData(ex);
                return result;
            }
            finally
            {
                // Close the socket
                if (client != null)
                    client.Close();
            }
        }

        private void UpdateTime(double localClockOffset)
        {
            SYSTEMTIME systemTime;
            DateTime newDateTime = DateTime.Now.AddSeconds(localClockOffset);
            systemTime.wYear = (Int16)newDateTime.Year;
            systemTime.wMonth = (Int16)newDateTime.Month;
            systemTime.wDayOfWeek = (Int16)newDateTime.DayOfWeek;
            systemTime.wDay = (Int16)newDateTime.Day;
            systemTime.wHour = (Int16)newDateTime.Hour;
            systemTime.wMinute = (Int16)newDateTime.Minute;
            systemTime.wSecond = (Int16)newDateTime.Second;
            systemTime.wMilliseconds = (Int16)newDateTime.Millisecond;
            if (!Win32API.SetLocalTime(ref systemTime))
                throw new Win32Exception();
        }

        private void WorkerThreadStart()
        {
            lock (this)
            {
                QueryServerCompletedEventArgs e = null;
                try
                {
                    e = QueryServer();
                }
                catch
                {
                    throw;
                }
                _asyncOperation.PostOperationCompleted(_operationCompleted, e);
            }
        }

		#endregion Methods 
    }
}
