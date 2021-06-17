using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SuricataLogViewer
{
    public static class PageController
    {
        private static Dictionary<Type, Page> pagesDictionary = new Dictionary<Type, Page>();

        public static Page GetPageObject<T>() where T : Page, new()
        {
            if (!pagesDictionary.TryGetValue(typeof(T), out Page page))
            {
                page = new T();
                pagesDictionary.Add(typeof(T), page);
            }
            return page;
        }
    }
}
