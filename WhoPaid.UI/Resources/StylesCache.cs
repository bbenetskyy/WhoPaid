using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace WhoPaid.UI.Resources
{
    public static class StylesCache
    {
        private static ResourceDictionary _styles;
        public static ResourceDictionary Styles => _styles ?? (_styles = FindDictionaryByPath("Resources/Styles.xaml"));

        private static ResourceDictionary _colors;
        public static ResourceDictionary Colors => _colors ?? (_colors = FindDictionaryByPath("Resources/Colors.xaml"));

        public static ResourceDictionary FindDictionaryByPath(string path)
        {
            return Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(md => md.Source.OriginalString.Equals(path));
        }
    }
}
