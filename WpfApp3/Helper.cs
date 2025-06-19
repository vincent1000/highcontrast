using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace WpfApp3
{
    public class Helper
    {
        private static readonly String TAG = "Helper";
        private static Helper mInstance = null;
        private ResourceDictionary mAppResourceDictionary = null;
        public event Action<bool>? HighContrastChanged;
        public static Helper Instance
        {
            get
            {
                lock (TAG)
                {
                    if (mInstance == null)
                        mInstance = new Helper();
                }
                return mInstance;
            }
        }
        public void OnHighContrastChanged(bool isHighContrast)
        {
            mAppResourceDictionary.MergedDictionaries.RemoveAt(0);
            LoadBrushResource(isHighContrast);
        }
        public void LoadTheme(bool isHighContrast)
        {
            mAppResourceDictionary = Application.Current.Resources.MergedDictionaries[0];

            mAppResourceDictionary.MergedDictionaries.RemoveAt(0);
            mAppResourceDictionary.MergedDictionaries.RemoveAt(0);

            LoadBrushResource(true);
        }
        private void LoadBrushResource(bool isHighContrast)
        {
            var resource = new ResourceDictionary();
            resource.Source = isHighContrast
                ? new Uri("pack://application:,,,/WpfApp3;component/dark.xaml", UriKind.RelativeOrAbsolute)
                : new Uri("pack://application:,,,/WpfApp3;component/default.xaml", UriKind.RelativeOrAbsolute);
            mAppResourceDictionary.MergedDictionaries.Insert(0, resource);

        }
    }
}
