using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MedBookDRS
{
    public class Consultatii
    {
        public int IdProgramare { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta { get; set; }

        public string DataProgramare { get; set; }

        public string Sex { get; set; }
        public TimeSpan Ora { get; set; }

    }
}
