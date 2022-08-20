using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USPFLM_Browser_App
{
    internal class PageSource
    {
        public static string pageSource;
        public static string pageURL;

        public PageSource(string pageSource, string pageURL)
        {
            sourceText = pageSource;
            PageURL = pageURL;
        }

        private string sourceText
        {
            set
            {
                pageSource = value;
            }
            
            get
            {
                return pageSource;
            }
        }

        private string PageURL
        {
            set
            {
                pageURL = value;
            }

            get
            {
                return pageURL;
            }
        }
    }
}
