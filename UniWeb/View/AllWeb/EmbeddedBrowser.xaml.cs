//using BaseLibs.EntityModel;
using CefSharp;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using BaseLibs.Logger;
using BaseUIUtility.ViewModel.WebTabViewModel;
using BaseLibs.GlobalsPack;
using BaseLibs.DBUtility.EntityModel;

namespace UniWeb.View.AllWeb
{
    /// <summary>
    /// Interaction logic for EmbeddedBrowser.xaml
    /// </summary>
    public partial class EmbeddedBrowser : UserControl
    {
        EmbeddeBrowserViewModel EmbeddeBrowserViewModel = new EmbeddeBrowserViewModel();
        private string DefaultPath = @"C:\UniWeb\EmbedBrowser";
        private string CachePath = @"C:\UniWeb\EmbedBrowser\DefaultPath";

       // WebEmbeddeBrowserViewModel.WebAccount WebEmbeddeBrowserViewModel.WebAccount = new WebEmbeddeBrowserViewModel.WebAccount();

        public EmbeddedBrowser()
        {
            InitializeComponent();
            DataContext = EmbeddeBrowserViewModel;
            InitializeValues();
            // EnterPage => (IsExecute, VisitUrl);
        }
        public EmbeddedBrowser(WebAccount webAccount)
        {
            InitializeComponent();
            DataContext = EmbeddeBrowserViewModel;
            EmbeddeBrowserViewModel.WebAccount = webAccount;
            InitializeValues();
            // EnterPage => (IsExecute, VisitUrl);
        }

        private void InitializeValues()
        {
            try
            {
                WebAddress.Command= new RelayCommand(VisitUrl, IsExecute);
               // EmbeddeBrowserViewModel.EnterPage = new RelayCommand(VisitUrl, IsExecute);

                if(EmbeddeBrowserViewModel.WebAccount?.Username != null)
                {
                    CachePath = $"{DefaultPath}\\{EmbeddeBrowserViewModel.WebAccount.Username}";
                }
               else if (EmbeddeBrowserViewModel.WebAccount?.Email != null)
                {
                    CachePath = $"{DefaultPath}\\{EmbeddeBrowserViewModel.WebAccount.Email}";
                }
                
                this.Browser.RequestContext = new RequestContext(new RequestContextSettings()
                {
                    CachePath = this.CachePath
                });

                this.Browser.Address = "http://www.google.com/";

                //this.Browser.Address = "https://get.google.com/apptips/apps/?utm_source=googlemobile&utm_campaign=redirect#!/all";
                this.Browser.IsBrowserInitializedChanged += new DependencyPropertyChangedEventHandler(this.LoadSettings);

                ICookieManager cookiesManager = this.Browser.RequestContext.GetDefaultCookieManager(new TaskCompletionCallback());
                List<Cookie> lstCookies = cookiesManager.VisitAllCookiesAsync().Result;
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        private static EmbeddedBrowser obj;

        public static EmbeddedBrowser GetObj()
            => obj ?? (obj = new EmbeddedBrowser());

        

        private bool IsExecute(object sender) => true;

        private void VisitUrl(object sender)
        {
            try
            {
                EmbeddeBrowserViewModel.FinalWebAddress = EmbeddeBrowserViewModel.WebAddress;
            }catch(Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                ex.ErrorLog("Error");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Browser.Address = EmbeddeBrowserViewModel.WebAddress;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Browser.Address = EmbeddeBrowserViewModel.WebAddress;
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void LoadSettings(object sender, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            try
            {
                if (!this.Browser.IsBrowserInitialized)
                    return;
                Cef.UIThreadTaskFactory.StartNew(delegate
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(EmbeddeBrowserViewModel.WebAccount.ProxyUsername) && !string.IsNullOrEmpty(EmbeddeBrowserViewModel.WebAccount.ProxyPassword))
                        {
                            //pass the proxy username and proxy password
                            Browser.RequestHandler = new ProxyRequestHandler(EmbeddeBrowserViewModel.WebAccount.ProxyUsername, EmbeddeBrowserViewModel.WebAccount.ProxyPassword);
                        }
                        string ProxyIp = EmbeddeBrowserViewModel.WebAccount.ProxyIP;
                        string ProxyPort = EmbeddeBrowserViewModel.WebAccount.ProxyPort.ToString();
                        IRequestContext requestContext = this.Browser.GetBrowser().GetHost().RequestContext;

                        if (!string.IsNullOrEmpty(ProxyIp) && !string.IsNullOrEmpty(ProxyPort))
                        {
                            var DictProxyIpPort = new Dictionary<string, object>();
                            DictProxyIpPort.Add("mode", "fixed_servers");
                            DictProxyIpPort.Add("server", "" + ProxyIp + ":" + ProxyPort + "");
                            string error;
                            bool success = requestContext.SetPreference("proxy", DictProxyIpPort, out error);
                        }
                        else
                        {
                            var DictProxyIpPort = new Dictionary<string, object>();

                            DictProxyIpPort.Add("mode", "direct");

                            string error;

                            bool success = requestContext.SetPreference("proxy", DictProxyIpPort, out error);
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ErrorLog();
                    }
                });
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
            try
            {
                this.Browser.Load("https://www.google.com");
                //this.Browser.Load("https://get.google.com/apptips/apps/?utm_source=googlemobile&utm_campaign=redirect#!/all");
                this.Browser.LoadingStateChanged += new EventHandler<LoadingStateChangedEventArgs>(this.BrowserOnLoaded);

                this.Browser.FrameLoadEnd += WebBrowserFrameLoadEnded;

            }
            catch(Exception ex) 
            {
                Logger.Log.Error(ex.ToString());
            }
        }
        private async void BrowserOnLoaded(object sender, LoadingStateChangedEventArgs loadingStateChangedEventArgs)
        {
            try
            {
                string html = await GetPageSource() ;
                try
                {

                    if (this.Dispatcher.Invoke<bool>((Func<bool>)(() => !this.Browser.IsLoaded)))
                        return;

                    // this.Browser.LoadingStateChanged -= new EventHandler<LoadingStateChangedEventArgs>(this.BrowserOnLoaded);
                    //  this.Browser.FrameLoadEnd += WebBrowserFrameLoadEnded;
                }
                catch (Exception Ex)
                {
                    Logger.Log.Error(Ex.ToString());
                }
            }
            catch (Exception) { }

        }

        private void WebBrowserFrameLoadEnded(object sender, FrameLoadEndEventArgs e)
        {
            try
            {
                try
                {
                    if (this.Dispatcher.Invoke<bool>((Func<bool>)(() => !this.Browser.IsLoaded)))
                        return;

                    if (!(string.IsNullOrEmpty(EmbeddeBrowserViewModel.WebAccount.Email) && string.IsNullOrEmpty(EmbeddeBrowserViewModel.WebAccount.Username)) && !string.IsNullOrEmpty(EmbeddeBrowserViewModel.WebAccount.Password))
                    {
                        while (true)
                        {
                            try
                            {
                                Browser.GetSourceAsync().ContinueWith(taskHtml =>
                                {
                                    var html = taskHtml.Result;

                                    Browser.ExecuteScriptAsync("document.getElementById('sign-in-btn').click()");
                                    Thread.Sleep(3000);
                                    if (html.Contains("identifierNext"))
                                    {
                                        Browser.ExecuteScriptAsync("document.getElementById('identifierId').value= '" + EmbeddeBrowserViewModel.WebAccount.Email + "'");
                                        Thread.Sleep(50);
                                        Browser.ExecuteScriptAsync("document.getElementById('identifierNext').click()");
                                        Thread.Sleep(1000);
                                    }
                                    if (html.Contains("passwordNext"))
                                    {
                                        Browser.ExecuteScriptAsync("document.getElementsByName('password')[0].value= '" + EmbeddeBrowserViewModel.WebAccount.Password + "'");
                                        Thread.Sleep(50);
                                        Browser.ExecuteScriptAsync("document.getElementById('passwordNext').click()");
                                        Thread.Sleep(1000);
                                    }
                                    try
                                    {
                                        Thread th = new Thread(() => RunDuringLoad(html)); th.SetApartmentState(ApartmentState.STA); th.IsBackground = true; th.Start();
                                    }
                                    catch (Exception ex) { ex.ErrorLog(); }
                                });
                                break;
                            }
                            catch (Exception ex)
                            {
                                ex.ErrorLog();
                            }
                        }
                    }
                    this.Browser.LoadingStateChanged -= new EventHandler<LoadingStateChangedEventArgs>(this.BrowserOnLoaded);
                    // this.Browser.LoadingStateChanged -= new EventHandler<LoadingStateChangedEventArgs>(this.BrowserOnLoaded);
                    //  this.Browser.FrameLoadEnd += WebBrowserFrameLoadEnded;
                }
                catch (Exception ex)
                {
                    ex.ErrorLog();
                }
                //Load_Page_Using_Thread();
                //new Thread(() => Load_Page_Using_Thread()).Start();
            }
            catch (Exception) { }
        }

        public void RunDuringLoad(string html)
        {
            try
            {
                lock (this)
                {
                    //if (html.Contains("<link rel=\"canonical\" href=\"https://myaccount.google.com/\">"))
                    //{
                    //    GplusHits++;
                    //    if (RedirectionInfo == 0)
                    //    {
                    //        RedirectionInfo = 1;
                    //        LoadUrl("https://plus.google.com/");
                    //    }
                    //}
                    //if (html.Contains("<link rel=\"canonical\" href=\"https://plus.google.com/\">"))
                    //{
                    //    if (YouTubeHits > 1)
                    //    {
                    //        if (SaveCookie == 0)
                    //        {
                    //            SaveCookie = 1;
                    //            Thread th = new Thread(() => SaveCookie_InThread(html)); th.SetApartmentState(ApartmentState.STA); th.IsBackground = true; th.Start();
                    //        }
                    //    }
                    //    YouTubeHits++;
                    //    if (RedirectionInfo == 1)
                    //    {
                    //        RedirectionInfo = 2;
                    //        LoadUrl("https://www.youtube.com/");
                    //    }
                    //}
                }
            }
            catch { }
        }


        private class RequestHandlerCustom : IRequestHandler
        {
            private readonly EmbeddedBrowser embedBrowser;
            public RequestHandlerCustom(EmbeddedBrowser embedBrowser)
            {
                this.embedBrowser = embedBrowser;
            }

            public bool CanGetCookies(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request)
            {
                throw new NotImplementedException();
            }

            public bool CanSetCookie(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
            {
                throw new NotImplementedException();
            }

            public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
            {
                if (isProxy)
                {
                    callback.Continue(this.embedBrowser.EmbeddeBrowserViewModel.WebAccount.ProxyUsername, this.embedBrowser.EmbeddeBrowserViewModel.WebAccount.ProxyPassword);
                    return true;
                }
                return false;
            }

            public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
            {
                return (IResponseFilter)null;
            }

            public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
            {
                try
                {

                }
                catch { }
                return false;
            }
            public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
            {
                callback.Dispose();
                return CefReturnValue.Continue;
            }

            public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
            {
                return false;
            }

            public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {
                return false;
            }

            public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
            {
            }

            public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
            {
                return url.StartsWith("https://www.google.com");
                //return url.StartsWith("https://get.google.com/apptips/apps/?utm_source=googlemobile&utm_campaign=redirect#!/all");
            }

            public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
            {
                return false;
            }

            public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
            {
            }

            public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
            {
            }



            public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
            {
                this.embedBrowser.Dispatcher.BeginInvoke(new Action(delegate
                {
                    this.embedBrowser.EmbeddeBrowserViewModel.WebAddress = this.embedBrowser.Browser.Address;
                }));

            }

            public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
            {

            }

            public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
            {
                return false;
            }

           

            public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
            {
                return false;
            }
        }

        public class ProxyRequestHandler : IRequestHandler
        {

            private string userName;
            private string password;

            public ProxyRequestHandler(string userName, string password)
            {
                this.userName = userName;
                this.password = password;
            }


            bool IRequestHandler.OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
            {
                return false;
            }
            bool IRequestHandler.OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {
                return OnOpenUrlFromTab(browserControl, browser, frame, targetUrl, targetDisposition, userGesture);
            }


            protected virtual bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
            {
                return false;
            }


            bool IRequestHandler.OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
            {
                return false;
            }

            void IRequestHandler.OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
            {

            }

            CefReturnValue IRequestHandler.OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
            {
                return CefReturnValue.Continue;
            }

            bool IRequestHandler.GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
            {

                if (isProxy == true)
                {
                    callback.Continue(userName, password);

                    return true;
                }

                return false;
            }

            void IRequestHandler.OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
            {

            }

            bool IRequestHandler.OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
            {
                return false;
            }



            bool IRequestHandler.OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
            {
                return url.StartsWith("mailto");
            }

            void IRequestHandler.OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
            {

            }

            bool IRequestHandler.OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
            {
                return false;
            }

            IResponseFilter IRequestHandler.GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
            {
                return null;
            }

            void IRequestHandler.OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
            {

            }

            public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
            {
                return false;
            }

            public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
            {

            }

            public bool CanGetCookies(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request)
            {
                throw new NotImplementedException();
            }

            public bool CanSetCookie(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, Cookie cookie)
            {
                throw new NotImplementedException();
            }
        }

       
        private void MenuItemCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(EmbeddeBrowserViewModel.PageSource);
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }

        private async Task<string> GetPageSource()
        {
            string pageSource = string.Empty;
            try
            {
                await Browser.GetSourceAsync().ContinueWith(taskHtml =>
                {
                    Global.PageSource  = EmbeddeBrowserViewModel.PageSource = taskHtml.Result;
                });
            }
            catch(Exception ex)
            {
                ex.ErrorLog();
            }
            return pageSource;
        }
    }
}
