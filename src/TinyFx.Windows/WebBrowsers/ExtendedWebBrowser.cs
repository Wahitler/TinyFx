using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TinyFx.Windows.WebBrowsers
{
    /// <summary>
    /// WebBrowser扩展
    /// </summary>
    public class ExtendedWebBrowser : System.Windows.Forms.WebBrowser
    {
        #region Init
        private IWebBrowser2 axIWebBrowser2;

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code. 
        /// Called by the control when the underlying ActiveX control is created. 
        /// </summary>
        /// <param name="nativeActiveXObject"></param>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void AttachInterfaces(object nativeActiveXObject)
        {
            this.axIWebBrowser2 = (IWebBrowser2)nativeActiveXObject;
            this.axIWebBrowser2.Silent = true;//解决javascript错误弹出框
            base.AttachInterfaces(nativeActiveXObject);
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code. 
        /// Called by the control when the underlying ActiveX control is discarded. 
        /// </summary>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void DetachInterfaces()
        {
            this.axIWebBrowser2 = null;
            base.DetachInterfaces();
        }

        /// <summary>
        /// Returns the automation object for the web browser
        /// </summary>
        public object Application
        {
            get { return axIWebBrowser2.Application; }
        }

        System.Windows.Forms.AxHost.ConnectionPointCookie cookie;
        WebBrowserExtendedEvents events;

        /// <summary>
        /// This method will be called to give you a chance to create your own event sink
        /// </summary>
        protected override void CreateSink()
        {
            //MAKE SURE TO CALL THE BASE or the normal events won't fire
            base.CreateSink();
            events = new WebBrowserExtendedEvents(this);
            cookie = new System.Windows.Forms.AxHost.ConnectionPointCookie(this.ActiveXInstance, events, typeof(DWebBrowserEvents2));
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void DetachSink()
        {
            if (null != cookie)
            {
                cookie.Disconnect();
                cookie = null;
            }
            base.DetachSink();
        }

        #endregion

        #region Events
        /// <summary>
        /// Fires when downloading of a document begins
        /// </summary>
        public event EventHandler Downloading;
        /// <summary>
        /// Raises the <see cref="Downloading"/> event
        /// </summary>
        /// <param name="e">Empty <see cref="EventArgs"/></param>
        /// <remarks>
        /// You could start an animation or a notification that downloading is starting
        /// </remarks>
        protected void OnDownloading(EventArgs e)
        {
            if (Downloading != null)
                Downloading(this, e);
        }

        /// <summary>
        /// Fires when downloading is completed
        /// </summary>
        /// <remarks>
        /// Here you could start monitoring for script errors. 
        /// </remarks>
        public event EventHandler DownloadComplete;
        /// <summary>
        /// Raises the <see cref="DownloadComplete"/> event
        /// </summary>
        /// <param name="e">Empty <see cref="EventArgs"/></param>
        protected virtual void OnDownloadComplete(EventArgs e)
        {
            if (DownloadComplete != null)
                DownloadComplete(this, e);
        }


        /// <summary>
        /// Raised when a new window is to be created. Extends DWebBrowserEvents2::NewWindow2 with additional information about the new window.
        /// </summary>
        public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNewWindow;

        /// <summary>
        /// Raises the <see cref="StartNewWindow"/> event
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
        protected void OnStartNewWindow(BrowserExtendedNavigatingEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            if (this.StartNewWindow != null)
                this.StartNewWindow(this, e);

        }

        /// <summary>
        /// Fires before navigation occurs in the given object (on either a window or frameset element).
        /// </summary>
        public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNavigate;
        /// <summary>
        /// Raises the <see cref="StartNavigate"/> event
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
        protected void OnStartNavigate(BrowserExtendedNavigatingEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            if (this.StartNavigate != null)
                this.StartNavigate(this, e);
        }
        #endregion

        #region WebBrowserExtendedEvents
        class WebBrowserExtendedEvents : DWebBrowserEvents2
        {
            public WebBrowserExtendedEvents() { }

            ExtendedWebBrowser _Browser;
            public WebBrowserExtendedEvents(ExtendedWebBrowser browser) { _Browser = browser; }

            #region DWebBrowserEvents2 Members

            //Implement whichever events you wish
            public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
            {
                Uri urlUri = new Uri(URL.ToString());

                string tFrame = null;
                if (targetFrameName != null)
                    tFrame = targetFrameName.ToString();

                BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(pDisp, urlUri, tFrame, UrlContext.None);
                _Browser.OnStartNavigate(args);

                cancel = args.Cancel;
                pDisp = args.AutomationObject;
            }

            //The NewWindow2 event, used on Windows XP SP1 and below
            public void NewWindow2(ref object pDisp, ref bool cancel)
            {
                BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(pDisp, null, null, UrlContext.None);
                _Browser.OnStartNewWindow(args);
                cancel = args.Cancel;
                pDisp = args.AutomationObject;
            }

            // NewWindow3 event, used on Windows XP SP2 and higher
            public void NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
            {
                BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(ppDisp, new Uri(bstrUrl), null, (UrlContext)dwFlags);
                _Browser.OnStartNewWindow(args);
                Cancel = args.Cancel;
                ppDisp = args.AutomationObject;
            }

            // Fired when downloading begins
            public void DownloadBegin()
            {
                _Browser.OnDownloading(EventArgs.Empty);
            }

            // Fired when downloading is completed
            public void DownloadComplete()
            {
                _Browser.OnDownloadComplete(EventArgs.Empty);
            }

            #region Unused events

            // This event doesn't fire. 
            [DispId(0x00000107)]
            public void WindowClosing(bool isChildWindow, ref bool cancel)
            {
            }

            public void OnQuit()
            {

            }

            public void StatusTextChange(string text)
            {
            }

            public void ProgressChange(int progress, int progressMax)
            {
            }

            public void TitleChange(string text)
            {
            }

            public void PropertyChange(string szProperty)
            {
            }

            public void NavigateComplete2(object pDisp, ref object URL)
            {
            }

            public void DocumentComplete(object pDisp, ref object URL)
            {
            }

            public void OnVisible(bool visible)
            {
            }

            public void OnToolBar(bool toolBar)
            {
            }

            public void OnMenuBar(bool menuBar)
            {
            }

            public void OnStatusBar(bool statusBar)
            {
            }

            public void OnFullScreen(bool fullScreen)
            {
            }

            public void OnTheaterMode(bool theaterMode)
            {
            }

            public void WindowSetResizable(bool resizable)
            {
            }

            public void WindowSetLeft(int left)
            {
            }

            public void WindowSetTop(int top)
            {
            }

            public void WindowSetWidth(int width)
            {
            }

            public void WindowSetHeight(int height)
            {
            }

            public void SetSecureLockIcon(int secureLockIcon)
            {
            }

            public void FileDownload(ref bool cancel)
            {
            }

            public void NavigateError(object pDisp, ref object URL, ref object frame, ref object statusCode, ref bool cancel)
            {
            }

            public void PrintTemplateInstantiation(object pDisp)
            {
            }

            public void PrintTemplateTeardown(object pDisp)
            {
            }

            public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
            {
            }

            public void PrivacyImpactedStateChange(bool bImpacted)
            {
            }

            public void CommandStateChange(int Command, bool Enable)
            {
            }

            public void ClientToHostWindow(ref int CX, ref int CY)
            {
            }
            #endregion

            #endregion
        }
        #endregion
    }

    #region IWebBrowser2
    /// <summary>
    /// IWebBrowser2
    /// </summary>
    [ComImport, SuppressUnmanagedCodeSecurity, TypeLibType(TypeLibTypeFlags.FOleAutomation | (TypeLibTypeFlags.FDual | TypeLibTypeFlags.FHidden)), Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E")]
    public interface IWebBrowser2
    {
        /// <summary>
        /// 
        /// </summary>
        [DispId(100)]
        void GoBack();
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x65)]
        void GoForward();
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x66)]
        void GoHome();
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x67)]
        void GoSearch();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="flags"></param>
        /// <param name="targetFrameName"></param>
        /// <param name="postData"></param>
        /// <param name="headers"></param>
        [DispId(0x68)]
        void Navigate([In] string Url, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);
        /// <summary>
        /// 
        /// </summary>
        [DispId(-550)]
        void Refresh();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        [DispId(0x69)]
        void Refresh2([In] ref object level);
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x6a)]
        void Stop();
        /// <summary>
        /// 
        /// </summary>
        [DispId(200)]
        object Application { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xc9)]
        object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xca)]
        object Container { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xcb)]
        object Document { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xcc)]
        bool TopLevelContainer { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xcd)]
        string Type { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xce)]
        int Left { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xcf)]
        int Top { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xd0)]
        int Width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xd1)]
        int Height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(210)]
        string LocationName { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xd3)]
        string LocationURL { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0xd4)]
        bool Busy { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(300)]
        void Quit();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcx"></param>
        /// <param name="pcy"></param>
        [DispId(0x12d)]
        void ClientToWindow(out int pcx, out int pcy);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <param name="vtValue"></param>
        [DispId(0x12e)]
        void PutProperty([In] string property, [In] object vtValue);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        [DispId(0x12f)]
        object GetProperty([In] string property);
        /// <summary>
        /// 
        /// </summary>
        [DispId(0)]
        string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(-515)]
        int HWND { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(400)]
        string FullName { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x191)]
        string Path { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x192)]
        bool Visible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x193)]
        bool StatusBar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x194)]
        string StatusText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x195)]
        int ToolBar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x196)]
        bool MenuBar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x197)]
        bool FullScreen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="flags"></param>
        /// <param name="targetFrameName"></param>
        /// <param name="postData"></param>
        /// <param name="headers"></param>
        [DispId(500)]
        void Navigate2([In] ref object URL, [In] ref object flags, [In] ref object targetFrameName, [In] ref object postData, [In] ref object headers);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdID"></param>
        /// <returns></returns>
        [DispId(0x1f5)]
        NativeMethods.OLECMDF QueryStatusWB([In] NativeMethods.OLECMDID cmdID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdID"></param>
        /// <param name="cmdexecopt"></param>
        /// <param name="pvaIn"></param>
        /// <param name="pvaOut"></param>
        [DispId(0x1f6)]
        void ExecWB([In] NativeMethods.OLECMDID cmdID, [In] NativeMethods.OLECMDEXECOPT cmdexecopt, ref object pvaIn, IntPtr pvaOut);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pvaClsid"></param>
        /// <param name="pvarShow"></param>
        /// <param name="pvarSize"></param>
        [DispId(0x1f7)]
        void ShowBrowserBar([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);
        /// <summary>
        /// 
        /// </summary>
        [DispId(-525)]
        WebBrowserReadyState ReadyState { get; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(550)]
        bool Offline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x227)]
        bool Silent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x228)]
        bool RegisterAsBrowser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x229)]
        bool RegisterAsDropTarget { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x22a)]
        bool TheaterMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x22b)]
        bool AddressBar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DispId(0x22c)]
        bool Resizable { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public partial class NativeMethods
    {
        /// <summary>
        /// 
        /// </summary>
        public enum OLECMDF
        {
            /// <summary>
            /// 
            /// </summary>
            // Fields
            OLECMDF_DEFHIDEONCTXTMENU = 0x20,
            /// <summary>
            /// 
            /// </summary>
            OLECMDF_ENABLED = 2,
            /// <summary>
            /// 
            /// </summary>
            OLECMDF_INVISIBLE = 0x10,
            /// <summary>
            /// 
            /// </summary>
            OLECMDF_LATCHED = 4,
            /// <summary>
            /// 
            /// </summary>
            OLECMDF_NINCHED = 8,
            /// <summary>
            /// 
            /// </summary>
            OLECMDF_SUPPORTED = 1
        }
        /// <summary>
        /// 
        /// </summary>
        public enum OLECMDID
        {
            /// <summary>
            /// 
            /// </summary>
            OLECMDID_PAGESETUP = 8,
            /// <summary>
            /// 
            /// </summary>
            OLECMDID_PRINT = 6,
            /// <summary>
            /// 
            /// </summary>
            OLECMDID_PRINTPREVIEW = 7,
            /// <summary>
            /// 
            /// </summary>
            OLECMDID_PROPERTIES = 10,
            /// <summary>
            /// 
            /// </summary>
            OLECMDID_SAVEAS = 4,
            // OLECMDID_SHOWSCRIPTERROR = 40
        }
        /// <summary>
        /// 
        /// </summary>
        public enum OLECMDEXECOPT
        {
            /// <summary>
            /// 
            /// </summary>
            OLECMDEXECOPT_DODEFAULT = 0,
            /// <summary>
            /// 
            /// </summary>
            OLECMDEXECOPT_DONTPROMPTUSER = 2,
            /// <summary>
            /// 
            /// </summary>
            OLECMDEXECOPT_PROMPTUSER = 1,
            /// <summary>
            /// 
            /// </summary>
            OLECMDEXECOPT_SHOWHELP = 3
        }

        //[StructLayout(LayoutKind.Sequential)]
        //public class POINT
        //{
        //  public int x;
        //  public int y;
        //  public POINT() { }
        //  public POINT(int x, int y)
        //  {
        //    this.x = x;
        //    this.y = y;
        //  }
        //}

        //[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"), ComVisible(true)]
        //public interface IOleCommandTarget
        //{
        //  [return: MarshalAs(UnmanagedType.I4)]
        //  [PreserveSig]
        //  int QueryStatus(ref Guid pguidCmdGroup, int cCmds, [In, Out] NativeMethods.OLECMD prgCmds, [In, Out] IntPtr pCmdText);
        //  [return: MarshalAs(UnmanagedType.I4)]
        //  [PreserveSig]
        //  int Exec(ref Guid pguidCmdGroup, int nCmdID, int nCmdexecopt, [In, MarshalAs(UnmanagedType.LPArray)] object[] pvaIn, ref int pvaOut);
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //public class OLECMD
        //{
        //  [MarshalAs(UnmanagedType.U4)]
        //  public int cmdID;
        //  [MarshalAs(UnmanagedType.U4)]
        //  public int cmdf;
        //  public OLECMD()
        //  {
        //  }
        //}

        //public const int S_FALSE = 1;
        //public const int S_OK = 0;


    }

    #endregion

    #region DWebBrowserEvents2
    [ComImport, TypeLibType((short)0x1010), InterfaceType((short)2), Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
    public interface DWebBrowserEvents2
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x66)]
        void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6c)]
        void ProgressChange([In] int Progress, [In] int ProgressMax);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x69)]
        void CommandStateChange([In] int Command, [In] bool Enable);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x6a)]
        void DownloadBegin();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x68)]
        void DownloadComplete();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x71)]
        void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x70)]
        void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string szProperty);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(250)]
        void BeforeNavigate2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers, [In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xfb)]
        void NewWindow2([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xfc)]
        void NavigateComplete2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x103)]
        void DocumentComplete([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xfd)]
        void OnQuit();
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xfe)]
        void OnVisible([In] bool Visible);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xff)]
        void OnToolBar([In] bool ToolBar);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x100)]
        void OnMenuBar([In] bool MenuBar);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x101)]
        void OnStatusBar([In] bool StatusBar);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x102)]
        void OnFullScreen([In] bool FullScreen);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(260)]
        void OnTheaterMode([In] bool TheaterMode);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x106)]
        void WindowSetResizable([In] bool Resizable);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x108)]
        void WindowSetLeft([In] int Left);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x109)]
        void WindowSetTop([In] int Top);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10a)]
        void WindowSetWidth([In] int Width);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10b)]
        void WindowSetHeight([In] int Height);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x107)]
        void WindowClosing([In] bool IsChildWindow, [In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10c)]
        void ClientToHostWindow([In, Out] ref int CX, [In, Out] ref int CY);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10d)]
        void SetSecureLockIcon([In] int SecureLockIcon);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(270)]
        void FileDownload([In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x10f)]
        void NavigateError([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Frame, [In, MarshalAs(UnmanagedType.Struct)] ref object StatusCode, [In, Out] ref bool Cancel);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xe1)]
        void PrintTemplateInstantiation([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xe2)]
        void PrintTemplateTeardown([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0xe3)]
        void UpdatePageStatus([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object nPage, [In, MarshalAs(UnmanagedType.Struct)] ref object fDone);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x110)]
        void PrivacyImpactedStateChange([In] bool bImpacted);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x111)]
        void NewWindow3([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out] ref bool Cancel, [In] uint dwFlags, [In, MarshalAs(UnmanagedType.BStr)] string bstrUrlContext, [In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);
    }
    #endregion

    #region WebBrowserExtendedNavigatingEventArgs
    public class WebBrowserExtendedNavigatingEventArgs : System.ComponentModel.CancelEventArgs
    {
        private string _Url;
        public string Url
        {
            get { return _Url; }
        }

        private string _Frame;
        public string Frame
        {
            get { return _Frame; }
        }

        public WebBrowserExtendedNavigatingEventArgs(string url, string frame)
            : base()
        {
            _Url = url;
            _Frame = frame;
        }
    }
    #endregion

    #region BrowserExtendedNavigatingEventArgs
    public class BrowserExtendedNavigatingEventArgs : CancelEventArgs
    {
        private Uri _Url;
        /// <summary>
        /// The URL to navigate to
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public Uri Url
        {
            get { return _Url; }
        }

        private string _Frame;
        /// <summary>
        /// The name of the frame to navigate to
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public string Frame
        {
            get { return _Frame; }
        }

        private UrlContext navigationContext;
        /// <summary>
        /// The flags when opening a new window
        /// </summary>
        public UrlContext NavigationContext
        {
            get { return this.navigationContext; }
        }

        private object _pDisp;
        /// <summary>
        /// The pointer to ppDisp
        /// </summary>
        public object AutomationObject
        {
            get { return this._pDisp; }
            set { this._pDisp = value; }
        }

        /// <summary>
        /// Creates a new instance of WebBrowserExtendedNavigatingEventArgs
        /// </summary>
        /// <param name="automation">Pointer to the automation object of the browser</param>
        /// <param name="url">The URL to go to</param>
        /// <param name="frame">The name of the frame</param>
        /// <param name="navigationContext">The new window flags</param>
        public BrowserExtendedNavigatingEventArgs(object automation, Uri url, string frame, UrlContext navigationContext)
            : base()
        {
            _Url = url;
            _Frame = frame;
            this.navigationContext = navigationContext;
            this._pDisp = automation;
        }
    }
    #endregion

    #region UrlContext
    /// <summary>
    /// Flags used by INewWindowManager::EvaluateNewWindow. 
    /// These values are taken into account in the decision of whether to display a pop-up window.
    /// </summary>
    [Flags]
    public enum UrlContext
    {
        /// <summary>
        /// No information Present
        /// </summary>
        None = 0x0,
        /// <summary>
        /// The page is unloading. This flag is set in response to the onbeforeunload and onunload events. 
        /// Some pages load pop-up windows when you leave them rather than when you enter. This flag is used to identify those situations.
        /// </summary>
        Unloading = 0x1,
        /// <summary>
        /// The call to INewWindowManager::EvaluateNewWindow is the result of a user-initiated action 
        /// (a mouse click or key press). Use this flag in conjunction with the NWMF_FIRST_USERINITED flag 
        /// to determine whether the call is a direct or indirect result of the user-initiated action.
        /// </summary>
        UserInited = 0x2,
        /// <summary>
        /// When NWMF_USERINITED is present, this flag indicates that the call to 
        /// INewWindowManager::EvaluateNewWindow is the first query that results from this user-initiated action. 
        /// Always use this flag in conjunction with NWMF_USERINITED.
        /// </summary>
        UserFirstInited = 0x4,
        /// <summary>
        /// The override key (ALT) was pressed. The override key is used to bypass the pop-up manager梐llowing 
        /// all pop-up windows to display梐nd must be held down at the time that INewWindowManager::EvaluateNewWindow is called. 
        /// </summary>
        OverrideKey = 0x8,
        /// <summary>
        /// The new window attempting to load is the result of a call to the showHelp method. Help is sometimes displayed in a separate window, 
        /// and this flag is valuable in those cases.
        /// </summary>
        ShowHelp = 0x10,
        /// <summary>
        /// The new window is a dialog box that displays HTML content.
        /// </summary>
        HtmlDialog = 0x20,
        /// <summary>
        /// Indicates that the EvaluateNewWindow method is being called through a marshalled Component Object Model (COM) proxy 
        /// from another thread. In this situation, the method should make a decision and return immediately without performing 
        /// blocking operations such as showing modal user interface (UI). Lengthy operations will cause the calling thread to 
        /// appear unresponsive.
        /// </summary>
        FromProxy = 0x40
    }
    #endregion
}
