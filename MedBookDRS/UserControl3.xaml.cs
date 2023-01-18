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

namespace MedBookDRS
{
    /// <summary>
    /// Interaction logic for UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();

            
            ArataIstoric();


        }

        private void ArataIstoric()
        {
            if (DbQuery.Instance.Tip_Utilizator == "Pacient")
            {
                txt_ProgramarileTale.Visibility = Visibility.Visible;
                using (var context = new Med_DrsEntities())
                {
                    string prenume = DbQuery.Instance.PrenumeUtilizator;
                    string nume = DbQuery.Instance.NumeUtilizator;
                    var result = (from P in context.Pacientis
                                  join PP in context.Programari_Pacienti
                                  on P.IdPacient equals PP.IdPacient
                                  join D in context.Doctoris
                                  on PP.IdDoctor equals D.IdDoctor
                                  where P.Prenume == prenume && P.Nume == nume
                                  select new
                                  {
                                      NumeDoctor = D.Nume,
                                      PrenumeDoctor = D.Prenume,
                                      DataProgramare = PP.DataProgramare.Day + "-" + PP.DataProgramare.Month + "-" + PP.DataProgramare.Year,
                                      Servicii_Medicale = PP.Descriere,
                                      PretTotal = PP.PretTotal
                                  }
                                  ).ToList();

                    DataGrid_IstoricClient.ItemsSource = result;
                }
            }
            else if (DbQuery.Instance.Tip_Utilizator == "Doctor")
            {
                Cmb_NumePacient.Visibility = Visibility.Visible;
                using (var context = new Med_DrsEntities())
                {
                    var result = (from p in context.Pacientis
                                  select new
                                  {
                                      p.Nume,
                                      p.Prenume
                                  });

                    Cmb_NumePacient.Items.Clear();
                  
                    foreach(var r in result)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = r.Nume;
                        Cmb_NumePacient.Items.Add(item);

                    }
                }

               
            }
        }

        private void ArataPacienti(object sender, SelectionChangedEventArgs e)
        {
            if (Cmb_PrenumePacient.SelectedItem == null)
            {
                DataGrid_IstoricClient.ItemsSource = null;

                return;

            }

            using (var context = new Med_DrsEntities())
            {
                string selectedNume = Cmb_NumePacient.SelectedItem.ToString().Split(':')[1].Trim(' ');
                string selectedPrenume = Cmb_PrenumePacient.SelectedItem.ToString().Split(':')[1].Trim(' ');

                var result = (from P in context.Pacientis
                              join PP in context.Programari_Pacienti
                              on P.IdPacient equals PP.IdPacient
                              join D in context.Doctoris
                              on PP.IdDoctor equals D.IdDoctor
                              where P.Prenume == selectedPrenume && P.Nume == selectedNume
                              select new
                              {
                                  Nume_Doctor = D.Nume,
                                  Prenume_Doctor = D.Prenume,
                                  DataProgramare = PP.DataProgramare.Day + "-" + PP.DataProgramare.Month + "-" + PP.DataProgramare.Year,
                                  Servicii_Medicale = PP.Descriere,
                                  PretTotal = PP.PretTotal
                              }
                                  ).ToList();
                DataGrid_IstoricClient.ItemsSource = result;

            }
        }

        private void ArataPrenume(object sender, SelectionChangedEventArgs e)
        {
            if (Cmb_NumePacient.SelectedItem == null)
            {
                Cmb_PrenumePacient.Items.Clear();
                DataGrid_IstoricClient.ItemsSource = null;
                Cmb_PrenumePacient.Visibility = Visibility.Collapsed;
                return;

            }
            string selectedNume = Cmb_NumePacient.SelectedItem.ToString().Split(':')[1].Trim(' ');
            Cmb_PrenumePacient.Visibility = Visibility.Visible;
            using (var context = new Med_DrsEntities())
            {
                var result = (from p in context.Pacientis
                              where p.Nume==selectedNume
                              select new
                              {
                                  p.Prenume
                              });

                int count = result.Count();
                Cmb_PrenumePacient.Items.Clear();
                foreach (var r in result)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = r.Prenume;
                    Cmb_PrenumePacient.Items.Add(item);

                }
            }
        }

        
    }
}
