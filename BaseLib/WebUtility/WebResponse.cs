using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib.WebUtility
{
    public class WebResponse
    {
        public string Reponse = string.Empty;
        public bool IsSuccess;
        public string Error = string.Empty;
        public string ResponseUri = string.Empty;
        public HttpWebResponse WebErrorResponse;

    }
}
