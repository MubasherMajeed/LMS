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

namespace LMS.Pages.Patient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Patients : Page
    {
        private List<Patient> patients;
        public Patients()
        {
            this.InitializeComponent();

            // Initialize the list of doctors
            this.patients = new List<Patient>()
        {
            new Patient("Dr. John Doe",  "john.doe@example.com", "123-456-7890", "https://images.unsplash.com/photo-1659482633371-c51d3a02bc81?ixlib=rb-4.0.3&ixid=MnwxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHw2fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=500&q=60"),
            new Patient("Dr. Jane Smith",  "jane.smith@example.com", "123-456-7890", "ms-appx:///Assets/LockScreenLogo.scale-200.png"),
            new Patient("Dr. Mark Johnson",  "mark.johnson@example.com", "123-456-7890", "https://images.unsplash.com/photo-1659482633371-c51d3a02bc81?ixlib=rb-4.0.3&ixid=MnwxMjA3fDF8MHxlZGl0b3JpYWwtZmVlZHw2fHx8ZW58MHx8fHw%3D&auto=format&fit=crop&w=500&q=60"),
            new Patient("Dr. Sarah Lee", "sarah.lee@example.com", "123-456-7890", "https://images.unsplash.com/photo-1679687189714-6a0e57adc199?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxMnx8fGVufDB8fHx8&auto=format&fit=crop&w=500&q=60"),
            new Patient("Dr. David Chen", "david.chen@example.com", "123-456-7890", "https://images.unsplash.com/photo-1679687189714-6a0e57adc199?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxMnx8fGVufDB8fHx8&auto=format&fit=crop&w=500&q=60")
        };

            // Bind the list of doctors to the ListView
            LoadDoctors();
        }

        private void LoadDoctors()
        {
            // populate the list of doctors
            // ...

            // bind the list of doctors to the DoctorsListView
            PatientListView.ItemsSource = patients;
        }

        /* private void DoctorsListView_ItemClick(object sender, ItemClickEventArgs e)
         {
             // Handle the click on a doctor item
             var doctor = (Doctor)e.ClickedItem;
             Console.WriteLine(doctor);
             *//*ShowDoctorDetailsDialog(doctor);*//*
             // Navigate to the doctor details page and pass the selected doctor object
                 Frame.Navigate(typeof(Pages.DoctorDetails), doctor);
         }*/
        private void PatientListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // get the selected doctor object
            var patient = e.ClickedItem as Patient;
            Console.WriteLine(patient.Name);
            // navigate to the DoctorDetailsPage with the selected doctor object as parameter
            Frame.Navigate(typeof(Pages.Patient.patient_details), patient);
        }

        private async void AddNewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ContentDialog();
            dialog.XamlRoot = Content.XamlRoot;
            dialog.Title = "Add New Patient";
            var panel = new StackPanel();

            var nameTextBox = new TextBox();
            nameTextBox.Header = "Name";
            panel.Children.Add(nameTextBox);

            
            var emailTextBox = new TextBox();
            emailTextBox.Header = "Email";
            panel.Children.Add(emailTextBox);

            var phoneTextBox = new TextBox();
            phoneTextBox.Header = "Phone Number";
            panel.Children.Add(phoneTextBox);

            var imageTextBox = new TextBox();
            imageTextBox.Header = "Image URL";
            panel.Children.Add(imageTextBox);

            dialog.Content = panel;
            dialog.PrimaryButtonText = "Add";
            dialog.SecondaryButtonText = "Cancel";

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
               

                Patient newPatient = new Patient
                (
                     nameTextBox.Text,
                     emailTextBox.Text,
                    phoneTextBox.Text,
                    imageTextBox.Text
                );

                // Add the new doctor to the list
                patients.Add(newPatient);
                PatientListView.ItemsSource = null;
                PatientListView.ItemsSource = patients;
            }
        }


    }

    public class Patient
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }

        public Patient(string name, string email, string phone, string imagePath)
        {
            Name = name;
            Email = email;
            Phone = phone;
            ImagePath = imagePath;
        }
    }
}