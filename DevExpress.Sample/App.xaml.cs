using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace DevExpress.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var theme = new Theme("FaceAzureDark");
            theme.AssemblyName = "DevExpress.Xpf.Themes.FaceAzureDark.v22.2";
            Theme.RegisterTheme(theme);

            ApplicationThemeHelper.ApplicationThemeName = "FaceAzureDark";
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemedWindow.RoundCorners = true;
        }
    }
}
