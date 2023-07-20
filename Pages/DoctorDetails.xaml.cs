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
using Microsoft.UI.Xaml.Media.Imaging;
using System.Numerics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LMS.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DoctorDetails : Page
    {
        private Doctor selectedDoctor;

        public DoctorDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Doctor doctor)
            {
                selectedDoctor = doctor;
                DataContext = doctor;
                /*DoctorNameTextBlock.Name     = selectedDoctor.Name;
                DoctorSpecialityTextBlock.Text = selectedDoctor.Specialization;
                DoctorPhoneNumber.Text = selectedDoctor.Phone;
                DoctorEmail.Text = selectedDoctor.Email;*/
               /* BitmapImage image = new BitmapImage(new Uri(selectedDoctor.ImagePath));
                DoctorImage.Source = image;*/

            }
            base.OnNavigatedTo(e);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
