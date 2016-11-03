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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WorkoutDiary.Database;
using WorkoutDiary.Register;

namespace WorkoutDiary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateDatabases();
        }

        private void CreateDatabases()
        {
            var dbCreator = new DatabaseCreator();
            dbCreator.CreateDbDirectory();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You shall sign in :D");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // DatabaseCreator.CreateDatabases();

            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }

        public string GetMainDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
