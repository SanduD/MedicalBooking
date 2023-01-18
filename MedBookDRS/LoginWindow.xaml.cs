using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace MedBookDRS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            ComboBoxItem item = new ComboBoxItem();
            item.Content = "Doctor";
            Cmb_Utilizator.Items.Add(item);

            ComboBoxItem item1 = new ComboBoxItem();
            item1.Content = "Pacient";
            Cmb_Utilizator.Items.Add(item1);
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

       
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
          
        }

        private void SignIn_Btn(object sender, RoutedEventArgs e)
        {
            if(Cmb_Utilizator.SelectedItem==null)
            {
                MessageBox.Show("Alege tipul utilizatorului!");
                return;
            }

            string selected = Cmb_Utilizator.Text;
            DbQuery.Instance.Tip_Utilizator = selected;
            bool flag = DbQuery.Instance.VerifySignIn(txtEmail.Text.ToString(), passwordBox.Password, selected);
            
            if (flag)
            {
                var dashboard = new Dashboard();
                dashboard.Left = this.Left;
                dashboard.Top = this.Top;
                dashboard.Width = this.Width;
                dashboard.Height = this.Height;
                dashboard.Show();
                
                this.Close();
                
            }
            else
                MessageBox.Show("Username sau parola incorecte! Incearca din nou.");


        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
                textEmail.Visibility = Visibility.Collapsed;
            else
                textEmail.Visibility = Visibility.Visible;
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void SignUp_Btn(object sender, RoutedEventArgs e)
        {
            var window = new RegisterWindow();
            window.Left = this.Left;
            window.Top=this.Top; 
            window.Width = this.Width;
            window.Height = this.Height;
            window.Show();

            this.Close();
        }

        private void CloseBtn_Login(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MiniminizeBtn_Login(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            
        }
    }
}
