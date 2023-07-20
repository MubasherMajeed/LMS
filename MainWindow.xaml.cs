// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using static System.Net.Mime.MediaTypeNames;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LMS
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnNavigationViewSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem selectedItem = args.SelectedItem as NavigationViewItem;

            switch (selectedItem.Tag)
            {
                case "home":
                    contentFrame.Navigate(typeof(Pages.HomePage));
                    break;
                case "doctors":
                    contentFrame.Navigate(typeof(Pages.Doctors));
                    break;
                case "patients":
                    contentFrame.Navigate(typeof(Pages.Patient.Patients));
                    break;
               /* case "settings":
                    contentFrame.Navigate(typeof(Pages.Settings));
                    break;*/
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                // The default settings icon button was clicked
                // Navigate to the desired page
                contentFrame.Navigate(typeof(Pages.Settings));
            }
        }


        private void OnAutoSuggestBoxTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Get the suggestions for the search query
            var suggestions = navigationView.MenuItems
                .Where(x => x is NavigationViewItem)
                .Select(x => x as NavigationViewItem)
                .Where(x => x.Content.ToString().StartsWith(sender.Text, StringComparison.OrdinalIgnoreCase))
                .Select(x => new { x.Content, x });

            sender.ItemsSource = suggestions;
        }

        private void OnAutoSuggestBoxQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            // Navigate to the selected item
            if (args.ChosenSuggestion != null)
            {
                var item = (args.ChosenSuggestion as dynamic).x as NavigationViewItem;
                navigationView.SelectedItem = item;
                item.IsExpanded = true;
            }
        }

        private void OnAutoSuggestBoxSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set the search query text to the chosen suggestion
            sender.Text = (args.SelectedItem as dynamic).Content.ToString();
        }










    }
    }
