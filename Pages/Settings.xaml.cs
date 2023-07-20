// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LMS.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

       

        private void ThemeToggle_Toggled(object sender, RoutedEventArgs e)
        {
           /* if (ThemeToggle.IsOn)
            {
                
                Application.Current.RequestedTheme = ApplicationTheme.Dark;
            }
            else
            {
                Application.Current.RequestedTheme = ApplicationTheme.Light;
            }*/
        }

        private void SaveEmailPreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            // Save email preferences code here
        }
        
        private void SavePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            // Save email preferences code here
        }
        
        
        private void SaveNotificationSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Save email preferences code here
        }
        
        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Save email preferences code here
        }

    }
}
