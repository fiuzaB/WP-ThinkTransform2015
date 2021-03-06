﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WP_TT.Services;
using Windows.UI.Popups;
using WP_TT.Models;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.System;

namespace WP_TT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {

        public Login()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {

            await login();

        }

        private async System.Threading.Tasks.Task login()
        {
            progressRing.IsActive = true;

            bool result = await SecurityService.tryLogin(usernameTextBox.Text, passwordTextBox.Password);
            progressRing.IsActive = false;
            if (result)
            {
                this.Frame.Navigate(typeof(HubPage));
            }
            else
            {
                MessageDialog message = new MessageDialog("Ocorreu um problema ao contactar o servidor. Verifique os dados e tente novamente.");

                await message.ShowAsync();
            }
        }

        private void TxtName_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                passwordTextBox.Focus(FocusState.Keyboard);
        }

        private async void TxtPassword_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                await this.login();
        }
    }
}
