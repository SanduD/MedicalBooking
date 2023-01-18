using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedBookDRS
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();


            using (var context = new Med_DrsEntities())
            {
                var specializari = (from s in context.Specializaris
                                    select new
                                    {
                                        s.Denumire
                                    });
                foreach (var s in specializari)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = s.Denumire;
                    Cmb_Specializare.Items.Add(item);
                }

            }
        }

        private void Btn_Programeazate(object sender, RoutedEventArgs e)
        {
            if (Cmb_Specializare.SelectedValue == null)
            {
                MessageBox.Show("Completeaza campul Categorie!");
                return;
            }
            if (DP_DataProgramare.SelectedDate == null)
            {
                MessageBox.Show("Alege o data de programare!");
                return;

            }
            if (Cmb_OraDisponibila.SelectedValue == null)
            {
                MessageBox.Show("Alege o ora!");
                return;

            }
            if (DataGrid_Doctori.SelectedItem == null)
            {
                MessageBox.Show("Selecteaza un Doctor");

                return;

            }
            using (var context = new Med_DrsEntities())
            {
                string specializare = Cmb_Specializare.SelectedItem.ToString().Split(' ')[1];
                DateTime dataProgramare = DP_DataProgramare.SelectedDate.Value;
                string string_ora = Cmb_OraDisponibila.SelectedItem.ToString().Split(' ')[1] + ":00";
                TimeSpan ora = TimeSpan.Parse(string_ora);

                string NumeDoctor = "", PrenumeDoctor = "";
                var selectedItem = DataGrid_Doctori.SelectedItem as Doctori;
                int IdDoctor=0;
                if (selectedItem != null)
                {
                    IdDoctor = selectedItem.IdDoctor;
                    NumeDoctor = selectedItem.Nume;
                    PrenumeDoctor = selectedItem.Prenume;
                }
                else
                {
                    MessageBox.Show("ERROR");
                    return;
                }

                int IdSpecializare = (from S in context.Specializaris
                                      where S.Denumire == specializare
                                      select new
                                      {
                                          S.IdSpecializare
                                      }).First().IdSpecializare;

                int IdPacient = (from p in context.Pacientis
                                 where p.Nume == DbQuery.Instance.NumeUtilizator && p.Prenume == DbQuery.Instance.PrenumeUtilizator
                                 select new
                                 {
                                     p.IdPacient
                                 }).First().IdPacient;

                DbQuery.Instance.InregistreazaProgramarea(IdSpecializare, IdPacient, IdDoctor, dataProgramare, ora);
                Cmb_Specializare.SelectedValue =null;
            }
            InitializeComponent();

        }

        private void ShowDoctors(object sender, RoutedEventArgs e)
        {
            
            using (var context = new Med_DrsEntities())
            {
                if(Cmb_Specializare.SelectedItem==null)
                {
                    DataGrid_Doctori.ItemsSource = null;
                    DP_DataProgramare.SelectedDate = null;
                    return;
                }
                string selected = Cmb_Specializare.SelectedItem.ToString().Split(' ')[1];

                var result = (from d in context.Doctoris
                              join SD in context.SpecializariDoctoris
                              on d.IdDoctor equals SD.IdDoctor
                              join s in context.Specializaris
                              on SD.IdSpecializare equals s.IdSpecializare
                              where s.Denumire == selected
                              select new
                              {
                                  IdDoctor = d.IdDoctor,
                                  Nume = d.Nume,
                                  Prenume = d.Prenume,
                                  Varsta = DateTime.Now.Year - d.DataNastere.Year,
                                  Telefon = d.Telefon,
                                  Studii = s.Studii
                              });

                List<Doctori> doctori = new List<Doctori>();

                foreach(var r in result)
                {
                    Doctori d=new Doctori();
                    d.IdDoctor = r.IdDoctor;
                    d.Nume = r.Nume;
                    d.Prenume = r.Prenume;
                    d.Varsta = r.Varsta;
                    d.Telefon = r.Telefon;
                    d.Studii = r.Studii;
                    doctori.Add(d);

                }

                DataGrid_Doctori.ItemsSource = doctori;

            }
        }
        private void GenerateHour(object sender, SelectionChangedEventArgs e)
        {
            if (DP_DataProgramare.SelectedDate == null)
            {
                MessageBox.Show("Introduceti o data pentru programare!");
                return;
            }

            using (var context = new Med_DrsEntities())
            {
                DateTime data = DP_DataProgramare.SelectedDate.Value;

                var programari = (from P in context.Programari_Pacienti
                                  join D in context.Doctoris
                                  on P.IdDoctor equals D.IdDoctor
                                  join S in context.Specializaris
                                  on P.IdSpecializare equals S.IdSpecializare
                                  where P.DataProgramare.Year == data.Year && P.DataProgramare.Month == data.Month && P.DataProgramare.Day == data.Day
                                  select new
                                  {
                                      S.IdSpecializare,
                                      P.OraProgramare,
                                      P.DataProgramare,
                                      D.Nume,
                                      D.Prenume

                                  });

                List<string> ListaOre = new List<string>();
                int count = programari.Count();

                string selectedNume = "", selectedPrenume = "";
                var selectedItem = DataGrid_Doctori.SelectedItem as Doctori;
                if (selectedItem != null)
                {
                    selectedNume = selectedItem.Nume;
                    selectedPrenume = selectedItem.Prenume;
                }

                for (int i = 8; i <= 16; i++)
                {
                    string ora = i.ToString() + ":00";
                    bool flag = true;
                    foreach (var prog in programari)
                    {
                        if (i.ToString() == prog.OraProgramare.Hours.ToString() && prog.Nume == selectedNume && prog.Prenume == selectedPrenume)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                        ListaOre.Add(ora);

                }
                Cmb_OraDisponibila.Items.Clear();
                foreach (var o in ListaOre)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = o;
                    Cmb_OraDisponibila.Items.Add(item);
                }

            }

        }

    }
}
