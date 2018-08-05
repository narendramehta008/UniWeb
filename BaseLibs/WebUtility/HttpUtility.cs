using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.WebUtility
{
    public class HttpUtility
    {
        public WebResponse webResponse;
        public RequestParameters RequestParameters;

        public WebResponse GetResponse(string url, RequestParameters RequestParameter = null)
        {
            WebResponse currentWebResponse = new WebResponse();
            try
            {
                var Request = (HttpWebRequest)WebRequest.Create(url);

                if (RequestParameter == null)
                    SetRequest(ref Request);
                GetHttpWebResponse(ref Request, ref currentWebResponse);

                //var Response = (HttpWebResponse)Request.GetResponse();
                //if (Response.StatusCode == HttpStatusCode.OK)
                //{
                //    Response.Cookies = Request.CookieContainer.GetCookies(Request.RequestUri);
                //    currentWebResponse.ResponseUri = Response.ResponseUri.AbsoluteUri;
                //    ReadCookies(Response.Cookies);
                //    StreamReader reader = new StreamReader(Response.GetResponseStream(), Encoding.UTF8);
                //    currentWebResponse.Reponse = reader.ReadToEnd();
                //    reader.Close();
                //}
                //else
                //{
                //    SetErrorResponse(Response, ref currentWebResponse.WebErrorResponse);
                //    return currentWebResponse;
                //}
                // currentWebResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {

            }

            return currentWebResponse;
        }

        public WebResponse PostResponse(string url, string postData, byte[] postBuffer)
        {
            WebResponse currentWebResponse = new WebResponse();
            try
            {
                var Request = (HttpWebRequest)WebRequest.Create(url);
                SetRequest(ref Request);

                if (postBuffer == null)
                    SetPostData(ref Request, postData);
                else
                    SetPostData(ref Request, postBuffer);

                GetHttpWebResponse(ref Request, ref currentWebResponse);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log.Error(ex.ToString());
            }
            return currentWebResponse;
        }

        public void SetRequestParameters(RequestParameters requestParameters)
        {
            try
            {
                this.RequestParameters = requestParameters;
            }
            catch (Exception ex)
            {
            }
        }

        public RequestParameters GetRequestParameters(RequestParameters requestParameters)
        {
            return this.RequestParameters;
        }

        public void SetRequest(ref HttpWebRequest Request)
        {
            try
            {
                Request.Accept = RequestParameters.Accept;
                if (!string.IsNullOrEmpty(RequestParameters.ContentType))
                    Request.ContentType = RequestParameters.ContentType;
                if (!string.IsNullOrEmpty(RequestParameters.UserAgent))
                    Request.UserAgent = RequestParameters.UserAgent;
                if (!string.IsNullOrEmpty(RequestParameters.Host))
                    Request.Host = RequestParameters.Host;

                if (!string.IsNullOrEmpty(RequestParameters.Referer))
                    Request.Referer = RequestParameters.Referer;
                if (!string.IsNullOrEmpty(RequestParameters.Accept))
                    Request.ContentType = RequestParameters.ContentType;
                if (!string.IsNullOrEmpty(RequestParameters.ContentType))
                    Request.ContentType = RequestParameters.ContentType;

                Request.CookieContainer = new CookieContainer();
                if (RequestParameters.Cookies != null && RequestParameters.Cookies.Count > 0)
                    Request.CookieContainer.Add(RequestParameters.Cookies);
                if (RequestParameters.Cookies == null)
                    RequestParameters.Cookies = new CookieCollection();


            }
            catch (Exception ex)
            {

            }
        }

        private void ReadCookies(CookieCollection cookies)
        {
            try
            {
                foreach (Cookie cookie in cookies)
                {
                    bool flag = true;
                    foreach (Cookie cookie2 in RequestParameters.Cookies)
                        if (cookie.Name.Equals(cookie2.Name) && cookie.Value.Equals(cookie2.Value))
                            flag = false;
                    if (flag)
                        RequestParameters.Cookies.Add(cookie);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SetErrorResponse(HttpWebResponse ErrorResponse, ref HttpWebResponse WebResponse)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private string SetPostData(ref HttpWebRequest Request, string postData)
        {
            string PostDataError = string.Empty;
            try
            {
                postData = String.Format(postData);
                byte[] postBuffer = Encoding.GetEncoding(1252).GetBytes(postData);
                Request.ContentLength = postBuffer.Length;
                Request.Method = "POST";
                Stream postStream = Request.GetRequestStream();
                postStream.Write(postBuffer, 0, postBuffer.Length);
                postStream.Close();
            }
            catch (Exception ex)
            {
                PostDataError = ex.ToString();
            }
            return PostDataError;
        }

        private string SetPostData(ref HttpWebRequest Request, byte[] postBuffer)
        {
            string PostDataError = string.Empty;
            try
            {
                //postData = String.Format(postData);
                //byte[] postBuffer = Encoding.GetEncoding(1252).GetBytes(postData);
                Request.ContentLength = postBuffer.Length;
                Request.Method = "POST";
                Stream postStream = Request.GetRequestStream();
                postStream.Write(postBuffer, 0, postBuffer.Length);
                postStream.Close();
            }
            catch (Exception ex)
            {
                PostDataError = ex.ToString();
            }
            return PostDataError;
        }

        private HttpWebResponse GetHttpWebResponse(ref HttpWebRequest Request, ref WebResponse webResponse)
        {
            HttpWebResponse DefaultResponse = null;
            try
            {
                var Response = (HttpWebResponse)Request.GetResponse();
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    Response.Cookies = Request.CookieContainer.GetCookies(Request.RequestUri);
                    webResponse.ResponseUri = Response.ResponseUri.AbsoluteUri;
                    ReadCookies(Response.Cookies);
                    StreamReader reader = new StreamReader(Response.GetResponseStream(), Encoding.UTF8);
                    webResponse.Reponse = reader.ReadToEnd();
                    reader.Close();
                }
                else
                {
                    webResponse.WebErrorResponse = Response;
                }

                DefaultResponse = Response;
                webResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                ReadError(ex, ref webResponse.Error);
            }
            return DefaultResponse;
        }

        private void ReadError(Exception ex, ref string Error)
        {
            try
            {
                WebException webEx = (WebException)ex;
                Error = (new StreamReader(webEx.Response.GetResponseStream()).ReadToEnd());
            }
            catch (Exception Ex)
            {
                Error = ex.ToString();
            }
        }
    }
}
