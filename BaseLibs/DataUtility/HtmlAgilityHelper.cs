using BaseLibs.Logger;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.DataUtility
{
   public   class HtmlAgilityHelper
    {
        public static List<string> GetListHtmlByClassName(string htmlPage,string className,bool IsInnerHtml=true)
        {
            List<string> listElementsByClassName = new List<string>();
            try
            {
                HtmlDocument _doc=new HtmlDocument();
                _doc.LoadHtml(htmlPage);
                if (IsInnerHtml)
                    listElementsByClassName = _doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", className))
                        .OfType<HtmlNode>().Select(x => x.InnerHtml?.InnerHtml()).ToList();
                else
                    listElementsByClassName = _doc.DocumentNode.SelectNodes(string.Format("//*[contains(@class,'{0}')]", className))
                        .OfType<HtmlNode>().Select(x => x.OuterHtml).ToList();
            }
            catch(Exception ex)
            {
                ex.ErrorLog();
            }
            return listElementsByClassName;
        }

        public static string GetHtmlByClassName(string htmlPage, string className, bool IsInnerHtml = true)
        {
            string elementByClassName = string.Empty;
            try
            {
                HtmlDocument _doc = new HtmlDocument();
                _doc.LoadHtml(htmlPage);
                if (IsInnerHtml)
                    elementByClassName = _doc.DocumentNode.SelectSingleNode(string.Format("//*[contains(@class,'{0}')]", className)).InnerHtml?.InnerHtml();
                else
                    elementByClassName = _doc.DocumentNode.SelectSingleNode(string.Format("//*[contains(@class,'{0}')]", className)).OuterHtml;
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
            return elementByClassName;
        }

        public static List<string> GetListHtmlById(string htmlPage, string idName, bool IsInnerHtml = true)
        {
            List<string> listElementsById = new List<string>();
            try
            {
                HtmlDocument _doc = new HtmlDocument();
                _doc.LoadHtml(htmlPage);
                if (IsInnerHtml)
                    listElementsById = _doc.DocumentNode.SelectNodes(string.Format("//*[contains(@id,'{0}')]", idName))
                        .OfType<HtmlNode>().Select(x => x.InnerHtml?.InnerHtml()).ToList();
                else
                    listElementsById = _doc.DocumentNode.SelectNodes(string.Format("//*[contains(@id,'{0}')]", idName))
                        .OfType<HtmlNode>().Select(x => x.OuterHtml).ToList();
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
            return listElementsById;
        }

        public static string GetHtmlById(string htmlPage, string idName, bool IsInnerHtml = true)
        {
            string elementById = string.Empty;
            try
            {
                HtmlDocument _doc = new HtmlDocument();
                _doc.LoadHtml(htmlPage);
                if (IsInnerHtml)
                    elementById = _doc.GetElementbyId(idName).InnerHtml?.InnerHtml();
                else
                    elementById = _doc.GetElementbyId(idName).OuterHtml;
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
            return elementById;
        }

    }
}
