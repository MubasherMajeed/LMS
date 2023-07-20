// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LMS
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
       /* protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new Windows.LoginWindow();
            m_window.Activate();
        }

        private Window m_window;*/
        private Window m_window;

           private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // Display the Splash Screen
            /*splashScreen = args.SplashScreen;
            var splashScreenImage = new BitmapImage();
            splashScreenImage.UriSource = new Uri("ms-appx:///Assets/SplashScreen.png");
            var splashScreenView = new SplashView(splashScreenImage);
            splashScreenView.Show();*/

            // Perform any initialization logic
            // ...

            // Perform authentication logic
            var isLoggedIn = await AuthenticateUserAsync();

            // Close the Splash Screen and navigate to the appropriate page
          /*  splashScreenView.Close();*/
            if (isLoggedIn)
            {
                m_window = new MainWindow();
                m_window.Activate();
            }
            else
            {
                m_window = new Windows.LoginWindow();
                m_window.Activate();
            }
        }

        private async Task<bool> AuthenticateUserAsync()
        {
            // Replace this with your own authentication logic
            await Task.Delay(2000); // Simulate a delay to show the Splash Screen for longer
            return localSettings.Values.ContainsKey("IsLoggedIn") && (bool)localSettings.Values["IsLoggedIn"]; 
        }




    }
}
