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
using WorkoutDiary.Registration;
using WorkoutDiary.Database;
using System.IO;
using WorkoutDiary.Models;

namespace WorkoutDiary.Register
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        #region Private Variables

        private RegistrationValidation _registrationValidation;

        #endregion

        #region Component Initialization
        public RegisterWindow()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            _registrationValidation = new RegistrationValidation();
            btnRegister.IsEnabled = false;
        }
        #endregion

        #region Event Handlers
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            _registrationValidation.AddUser(tbxUsername.Text, tbxPassword.Password);
            MessageBox.Show("New user added!");
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void tbxUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            string message = _registrationValidation.IsValidUsername(tbxUsername.Text);
            lblUserNameMessage.Content = message;
            UnlockRegistrationButton();
        }

        private void tbxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_registrationValidation.IsValidPassword(tbxPassword.Password));
            UnlockRegistrationButton();
        }

        private void tbxPasswordRepeat_LostFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_registrationValidation.PasswordsMatch(tbxPassword.Password, tbxPasswordRepeat.Password));
            UnlockRegistrationButton();
        }
        #endregion

        private void UnlockRegistrationButton()
        {
            if(_registrationValidation.ReleaseRegistrationButton())
            {
                btnRegister.IsEnabled = true;
            }
            else if(!_registrationValidation.ReleaseRegistrationButton())
            {
                btnRegister.IsEnabled = false;
            }
        }
    }
}
