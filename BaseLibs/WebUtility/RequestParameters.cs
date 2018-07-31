using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.WebUtility
{
    public interface IRequestParameters
    {
        bool KeepAlive { get; set; }
        string ContentType { get; set; }
        string Accept { get; set; }
        string Host { get; set; }
        string Origin { get; set; }
        string Referer { get; set; }
        string UserAgent { get; set; }

        CookieCollection Cookies { get; set; }
        Proxy Proxy { get; set; }
        WebHeaderCollection Headers { get; set; }
        //IRequestParameters GetRequestParameters();
        //void SetRequestParameters(IRequestParameters requestParameters);


    }

    public class RequestParameters : IRequestParameters
    {
        public IRequestParameters requestParameters;
        public bool KeepAlive { get; set; }
        public string ContentType { get; set; }
        public string Accept { get; set; } = "Keep Alive";
        public string Host { get; set; }
        public string Origin { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }

        public CookieCollection Cookies { get; set; }


        public Proxy Proxy { get; set; }
        public WebHeaderCollection Headers { get; set; }

        //public IRequestParameters GetRequestParameters()
        //{
        //    return this.requestParameters;
        //}

        //public void SetRequestParameters(IRequestParameters requestParameters)
        //{
        //    this.requestParameters = requestParameters;
        //}
    }

    public class Proxy
    {
        public Proxy proxy;
        public string ProxyAddress { get; set; }
        public int ProxyPort { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }

        public Proxy GetProxy()
        {
            return this.proxy;
        }

        public void SetProxy(Proxy proxy)
        {
            this.proxy = proxy;
        }

    }
}
