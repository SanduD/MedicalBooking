using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for UC_RezolvaProgramari.xaml
    /// </summary>
    public partial class UC_RezolvaProgramari : UserControl
    {
        double PretGlobal = 0, pretServiciu1 = 0, pretServiciu2 = 0, pretServiciu3 = 0;
        public UC_RezolvaProgramari()
        {
            InitializeComponent();
            AfiseazaProgramari();
        }

        private void AfiseazaProgramari()
        {

            using (var context = new Med_DrsEntities())
            {
                int IdDoctor = (from d in context.Doctoris
                                where d.Nume == DbQuery.Instance.NumeUtilizator && d.Prenume == DbQuery.Instance.PrenumeUtilizator
                                select new { d.IdDoctor }).First().IdDoctor;


                var result = (from P in context.Pacientis
                              join PP in context.Programari_Pacienti
                              on P.IdPacient equals PP.IdPacient
                              join D in context.Doctoris
                              on PP.IdDoctor equals D.IdDoctor
                              where D.IdDoctor == IdDoctor && PP.Descriere == null
                              select new
                              {
                                  IdProgramare = PP.IdProgramare,
                                  Nume = P.Nume,
                                  Prenume = P.Prenume,
                                  Varsta = DateTime.Now.Year - P.DataNastere.Year,
                                  DataProgramare = PP.DataProgramare.Day + "-" + PP.DataProgramare.Month + "-" + PP.DataProgramare.Year,
                                  Ora = PP.OraProgramare,
                                  Sex = P.Sex
                              }
                              );
                List<Consultatii> consultatii = new List<Consultatii>();
                foreach (var r in result)
                {
                    Consultatii Cons = new Consultatii();
                    Cons.IdProgramare = r.IdProgramare;
                    Cons.Nume = r.Nume;
                    Cons.Prenume = r.Prenume;
                    Cons.Varsta = r.Varsta;
                    Cons.DataProgramare = r.DataProgramare;
                    Cons.Ora = r.Ora;
                    Cons.Sex = r.Sex;
                    consultatii.Add(Cons);
                }
                int count = result.Count();
                DataGrid_Pacienti.ItemsSource = consultatii;
            }
        }
        

        private void RezolvaProgramari(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = DataGrid_Pacienti.SelectedItem as Consultatii;
            if (selectedItem == null)
            {
                Cmb_Serviciu1.Visibility = Visibility.Collapsed;
                Txt_Combo.Visibility = Visibility.Collapsed;
                Txt_Pret.Visibility = Visibility.Collapsed;
                Btn_Confirm.Visibility = Visibility.Collapsed;
                
                return;
            }
            Btn_Confirm.Visibility = Visibility.Visible;
            Cmb_Serviciu1.Visibility = Visibility.Visible;
            Txt_Combo.Visibility = Visibility.Visible;
            Txt_Pret.Visibility = Visibility.Visible;
            Cmb_Serviciu1.Items.Clear();
            
            using (var context = new Med_DrsEntities())
            {
                var result = (from S in context.ServiciiMedicales
                              select new
                              {
                                  S.Denumire,

                              });
                foreach (var s in result)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = s.Denumire;
                    Cmb_Serviciu1.Items.Add(item);
                }

            }

        }

        private void AfiseazaServiciu2(object sender, SelectionChangedEventArgs e)
        {
            if (Cmb_Serviciu1.SelectedItem == null )
            {
                Cmb_Serviciu2.Visibility = Visibility.Collapsed;
                Cmb_Serviciu2.ItemsSource = null;
                PretServiciu1.Text = "";
                PretTotalConsultatie.Text = "";
                Cmb_Serviciu3.Visibility = Visibility.Collapsed;
                Cmb_Serviciu3.ItemsSource = null;
                PretServiciu2.Text = "";
                PretServiciu3.Text = "";
                PretGlobal -= (pretServiciu1+pretServiciu2+pretServiciu3);
                pretServiciu1 = pretServiciu2 = pretServiciu3 = 0;
                PretTotalConsultatie.Text = "Pret consultatie: " + PretGlobal + " RON";


                return;
            }

            PretTotalConsultatie.Visibility = Visibility.Visible;
            Cmb_Serviciu2.Items.Clear();
            Cmb_Serviciu2.Visibility = Visibility.Visible;
            using (var context = new Med_DrsEntities())
            {
                var result = (from S in context.ServiciiMedicales
                              select new
                              {
                                  S.Pret,
                                  S.Denumire
                              });

                int index = Cmb_Serviciu1.SelectedItem.ToString().IndexOf(':');
                string DenumireServiciu = Cmb_Serviciu1.SelectedItem.ToString().Substring(index + 2);

                pretServiciu1 = result.Where(s => s.Denumire == DenumireServiciu).Select(s => s.Pret).First();

                PretGlobal += pretServiciu1;
                PretTotalConsultatie.Text = "Pret consultatie: " + PretGlobal.ToString() + " RON";

                PretServiciu1.Text = pretServiciu1.ToString() + " RON";
                foreach (var s in result)
                {
                    if (s.Denumire != DenumireServiciu)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = s.Denumire;
                        Cmb_Serviciu2.Items.Add(item);
                    }
                }

            }

        }

        private void AfiseazaServiciu3(object sender, SelectionChangedEventArgs e)
        {

            if (Cmb_Serviciu2.SelectedItem == null)
            {
                Cmb_Serviciu3.Visibility = Visibility.Collapsed;
                Cmb_Serviciu3.ItemsSource = null;
                PretServiciu2.Text = "";
                PretServiciu3.Text = "";
                PretGlobal-=(pretServiciu2+pretServiciu3);
                pretServiciu3 = pretServiciu2 = 0;
                PretTotalConsultatie.Text = "Pret consultatie: " + PretGlobal + " RON";

                return;
            }

            Cmb_Serviciu3.Items.Clear();
            Cmb_Serviciu3.Visibility = Visibility.Visible;
            using (var context = new Med_DrsEntities())
            {
                var result = (from S in context.ServiciiMedicales
                              select new
                              {
                                  S.Pret,
                                  S.Denumire
                              });

                int index = Cmb_Serviciu2.SelectedItem.ToString().IndexOf(':');

                string DenumireServiciu1 = Cmb_Serviciu1.SelectedItem.ToString().Substring(index + 2);

                string DenumireServiciu = Cmb_Serviciu2.SelectedItem.ToString().Substring(index + 2);

             

                pretServiciu2 = result.Where(s => s.Denumire == DenumireServiciu).Select(s => s.Pret).First();

                PretGlobal += pretServiciu2;

                PretTotalConsultatie.Text = "Pret consultatie: " + PretGlobal.ToString() + " RON";
                PretServiciu2.Text = pretServiciu2.ToString() + " RON";
                foreach (var s in result)
                {
                    if (s.Denumire != DenumireServiciu && s.Denumire!=DenumireServiciu1)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = s.Denumire;
                        Cmb_Serviciu3.Items.Add(item);
                    }
                }

            }
        }

        private void AfiseazaServiciu4(object sender, SelectionChangedEventArgs e)
        {
            if (Cmb_Serviciu3.SelectedItem == null)
            {
                PretGlobal -= pretServiciu3;
                pretServiciu3 = 0;
                PretTotalConsultatie.Text = "Pret consultatie: " + PretGlobal + " RON";
                PretServiciu3.Text = "";
                return;
            }


            using (var context = new Med_DrsEntities())
            {
                var result = (from S in context.ServiciiMedicales
                              select new
                              {
                                  S.Pret,
                                  S.Denumire
                              });

                int index = Cmb_Serviciu3.SelectedItem.ToString().IndexOf(':');
                string DenumireServiciu = Cmb_Serviciu3.SelectedItem.ToString().Substring(index + 2);

                

                pretServiciu3 = result.Where(s => s.Denumire == DenumireServiciu).Select(s => s.Pret).First();

                PretGlobal += pretServiciu3;
                PretTotalConsultatie.Text = "Pret consultatie: " + PretGlobal + " RON";
                PretServiciu3.Text = pretServiciu3.ToString() + " RON";

            }
        }

        private void ConfirmaConsultatia(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGrid_Pacienti.SelectedItem as Consultatii;
            if (selectedItem == null || Cmb_Serviciu1.SelectedItem==null)
                return;
            int index = Cmb_Serviciu1.SelectedItem.ToString().IndexOf(':');
            string serviciu1 = Cmb_Serviciu1.SelectedItem.ToString().Substring(index + 2);
            
            string serviciu2="", serviciu3="", toateServiciile = "";
            toateServiciile += serviciu1;

            if (Cmb_Serviciu2.SelectedItem != null)
            {
                index = Cmb_Serviciu2.SelectedItem.ToString().IndexOf(':');
                serviciu2 = Cmb_Serviciu2.SelectedItem.ToString().Substring(index + 2);
                toateServiciile += ", " + serviciu2;
            }

            if (Cmb_Serviciu3.SelectedItem != null)
            {
                index = Cmb_Serviciu3.SelectedItem.ToString().IndexOf(':');
                serviciu2 = Cmb_Serviciu3.SelectedItem.ToString().Substring(index + 2);
                toateServiciile += ", " + serviciu3;
            }

            using (var context =new Med_DrsEntities())
            {
                var Programari = (from PP in context.Programari_Pacienti
                                  where PP.IdProgramare == selectedItem.IdProgramare
                                  select PP).First();

                Programari.Descriere = toateServiciile;
                Programari.PretTotal = PretGlobal;
                context.SaveChanges();
                MessageBox.Show("Programare finalizata!");

            }
            this.InitializeComponent();
        }
    }
}
