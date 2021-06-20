using SuricataLogViewer.Views.Pages;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SuricataLogViewer.Services
{
    public static class PageService
    {
        private static Dictionary<Type, Page> pagesDictionary = new Dictionary<Type, Page>();

        public static Page GetPageObject<T>() where T : Page, new()
        {
            if (!pagesDictionary.TryGetValue(typeof(T), out Page page))
            {
                page = new T();
                if(page is not ChartsPage)
                    pagesDictionary.Add(typeof(T), page);
            }
            return page;
        }
    }
}
