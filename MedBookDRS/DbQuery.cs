using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MedBookDRS
{
    public class DbQuery
    {

        private static DbQuery instance;

        public string NumeUtilizator { get; set; }
        public string PrenumeUtilizator { get; set; }

        public string Tip_Utilizator { get; set; }
        private DbQuery()
        {
        }

        public static DbQuery Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbQuery();
                }
                return instance;
            }
        }
        public bool VerifySignIn(string Username, string Password, string TipUtilizator)
        {
            var context = new Med_DrsEntities();

            if (TipUtilizator == "Pacient")
            {
                var results = from u in context.Pacientis
                              where u.Email == Username && u.Parola == Password
                              select u;
                if (results.Count() > 0)
                {
                    this.NumeUtilizator = results.First().Nume;
                    this.PrenumeUtilizator = results.First().Prenume;
                    return true;
                }
                else
                    return false;
            }
            else if (TipUtilizator == "Doctor")
            {
                var results = from u in context.Doctoris
                              where u.Email == Username && u.Parola == Password
                              select u;
                if (results.Count() > 0)
                {
                    this.NumeUtilizator = results.First().Nume;
                    this.PrenumeUtilizator = results.First().Prenume;

                    return true;
                }
                else
                    return false;
            }
            return false;

        }
        public bool RegisterUser(string Nume, string Prenume, string Sex, DateTime DataNastere, string Email, string Parola, string Telefon)
        {
            try
            {
                using (var context = new Med_DrsEntities())
                {
                    var results = from u in context.Pacientis
                                  where u.Email == Email
                                  select u;
                    if (results.Count() > 0)
                    {
                        MessageBox.Show($"Exista deja un cont cu acest email!");
                        return false;
                    }
               

                    var newUser = new Pacienti()
                    {
                        Nume = Nume,
                        Prenume = Prenume,
                        Sex = Sex,
                        DataNastere = DataNastere,
                        Email = Email,
                        Parola = Parola,
                        Telefon = Telefon
                    };
                    context.Pacientis.Add(newUser);
                    context.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"ERROR! User-ul nu a putut fi inregistrat!:{Ex.Message}");
            }
            return true;
        }

        public void InregistreazaProgramarea(int IdSpecializare, int IdPacient, int IdDoctor, DateTime DataProgramare, TimeSpan Ora)
        {
            try
            {
                using (var context = new Med_DrsEntities())
                {
                    var programare = new Programari_Pacienti()
                    {
                        IdSpecializare = IdSpecializare,
                        IdPacient = IdPacient,
                        IdDoctor = IdDoctor,
                        DataProgramare = DataProgramare,
                        OraProgramare = Ora
                    };
                    context.Programari_Pacienti.Add(programare);
                    context.SaveChanges();
                    MessageBox.Show($"Programarea s-a efectuat cu succes! Va asteptam in data de " +
                        $"{DataProgramare.Day}-{DataProgramare.Month}-{DataProgramare.Year} la ora {Ora}");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"ERROR! User-ul nu a putut fi inregistrat!:{Ex.Message}");
            }
          
        }
    }


    }



