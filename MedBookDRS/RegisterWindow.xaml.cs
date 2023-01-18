using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Threading;

namespace MedBookDRS
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton==MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private void Back_Btn(object sender, RoutedEventArgs e)
        {
            var window = new LoginWindow();
            window.Left = this.Left;
            window.Top = this.Top;
            window.Width = this.Width;
            window.Height = this.Height;
            window.Show();

            this.Close();
        }

        private void CloseBtn_Reg(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.Close();
        }

        private void MiniminizeBtn_Reg(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void SignUP_Btn(object sender, RoutedEventArgs e)
        {
            string Nume, Prenume, Sex = "", Email, Parola, Telefon;
            DateTime DataNastere = DP_DataNastere.SelectedDate.Value;
            Nume = TxtBox_Nume.Text;
            Prenume=TxtBox_Prenume.Text;

            if(RdBtn_Barbat.IsChecked==true)
                Sex = "M";
            else if(RdBtn_Femeie.IsChecked==true)
                Sex= "F";

            Email = TxtBox_Email.Text;
            Parola = PassowordBox.Password;
            Telefon = TxtBox_NrTelefon.Text;

            if(DbQuery.Instance.RegisterUser(Nume, Prenume,Sex, DataNastere,Email,Parola,Telefon))
            {
                MessageBox.Show("This is my message.", "My Message Box",MessageBoxButton.OK,MessageBoxImage.Information);
                //System.Threading.Thread.Sleep(2000);

                Back_Btn(sender, e);    
            }


        }
    }
   
}
