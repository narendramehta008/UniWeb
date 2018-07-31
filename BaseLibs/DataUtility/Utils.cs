using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.DataUtility
{
    public class Utils
    {
        public static String GetBetween(String source, String startString, String endString)
        {
            String str = "";
            if (source.Contains(startString) && (source.Contains(endString)))
            {
                int start = source.IndexOf(startString) + startString.Length;
                int end = source.IndexOf(endString, start);
                str = source.Substring(start, end - start);
            }
            return str;
        }

        public static String GetBetweenReverse(String source, String startString, String endString)
        {
            String str = "";
            if (source.Contains(startString) && (source.Contains(endString)))
            {
                int start = source.IndexOf(startString) + startString.Length;
                int end = source.IndexOf(endString, start);
                str = source.Substring(start, end - start);
            }
            return str;
        }
    }
}
