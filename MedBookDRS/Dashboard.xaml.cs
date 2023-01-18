using MaterialDesignThemes.Wpf;
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

namespace MedBookDRS
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            CC.Content = new UserControl1();

            Rbtn1.IsChecked = true;
            string text="";
            if(DbQuery.Instance.Tip_Utilizator=="Doctor")
            {
                 text = "Salut, Dr. " + DbQuery.Instance.NumeUtilizator+"!";
                img_User.Kind = PackIconKind.Doctor;
                Btn_ProgramariDoctor.Visibility = Visibility.Visible;
                Btn_IstoricDoctor.Visibility = Visibility.Visible;
            }
            else if(DbQuery.Instance.Tip_Utilizator == "Pacient")
            {
                text = "Salut, " + DbQuery.Instance.NumeUtilizator+"!";
                Btn_FaProgramare.Visibility = Visibility.Visible;
                Btn_IstoricPacient.Visibility = Visibility.Visible;

            }
            txt_Username.Text = text;

        }


        private void CloseBtn_Dash(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private void MiniminizeBtn_Dash(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Btn_FaProgramare_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl2();//Fa_Programare

        }

        private void Rbtn1_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl1();
        }

        private void Rbtn3_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl3();

        }

        private void Btn_LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new LoginWindow();
            window.Left = this.Left;
            window.Top = this.Top;
            window.Width = this.Width;
            window.Height = this.Height;
            window.Show();

            this.Close();
        }

        private void Btn_RezolvaProgramari(object sender, RoutedEventArgs e)
        {
            CC.Content = new UC_RezolvaProgramari();
        }
    }
}
