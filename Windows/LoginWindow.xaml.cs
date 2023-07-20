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
using Windows.System;
using Windows.Storage;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LMS.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.InitializeComponent();
        }


        private void PasswordBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                // Simulate a button click
                PerformLogin();
            }
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            PerformLogin();
        }


        private void PerformLogin()
        {
            if (AuthenticateUser(UsernameTextBox.Text, PasswordBox.Password))
            {
                  ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                     localSettings.Values["IsLoggedIn"] = true;
                var mainWindow = new MainWindow();

                // Show the main window
                mainWindow.Activate();

                // Close the login window
                this.Close();
            }
            else
            {
                // Display error message if authentication fails
                ErrorTextBlock.Text = "Invalid username or password";
            }

        }

        private bool AuthenticateUser(string username, string password)
        {
            // Replace this with your own authentication logic
            if (username == "admin" && password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
