﻿using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using PregnaCare_WpfApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PregnaCare_WpfApp {
    /// <summary>
    /// Interaction logic for UserInformation.xaml
    /// </summary>
    public partial class UserInformation : Window {
        private UserService _userService;
        private User _currentUser;
        
        public UserInformation() {
            InitializeComponent();
            _userService = new UserService();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // Get user data from UserSession
            if (UserSession.Id != Guid.Empty) {
                _currentUser = _userService.GetUserById(UserSession.Id);
                
                // If user not found, handle the error
                if (_currentUser == null) {
                    MessageBox.Show("Unable to load user data. Please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                DisplayUserInfo();
            } else {
                MessageBox.Show("No active user session found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }
        
        private void DisplayUserInfo() {
            if (_currentUser == null) return;
            
            TxtFullName.Text = _currentUser.FullName ?? "Not set";
            TxtEmail.Text = _currentUser.Email ?? "Not set";
            TxtPhoneNumber.Text = _currentUser.PhoneNumber ?? "Not set";
            TxtGender.Text = _currentUser.Gender ?? "Not set";
            TxtDateOfBirth.Text = _currentUser.DateOfBirth?.ToString("dd/MM/yyyy") ?? "Not set";
            TxtAddress.Text = _currentUser.Address ?? "Not set";
            
            // Set user image if available
            if (!string.IsNullOrEmpty(_currentUser.ImageUrl)) {
                try {
                    UserImage.Source = new BitmapImage(new Uri(_currentUser.ImageUrl));
                } catch {
                    // Use default image or handle error
                }
            }
        }
        
        private void BtnEditInfo_Click(object sender, RoutedEventArgs e) {
            if (_currentUser == null) return;
            
            var editDialog = new UserInfoEditDialog(_currentUser);
            bool? result = editDialog.ShowDialog();
            
            if (result == true) {
                // Refresh user data after update
                _currentUser = _userService.GetUserById(_currentUser.Id);
                DisplayUserInfo();
                MessageBox.Show("User information updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
