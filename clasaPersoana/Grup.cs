using System;
using System.Collections.Generic;
using System.Text;
using clasaPersoana;

namespace clasaPersoana
{
    public class Grup
    {

        //constante
        private const char SEPARATOR_FISIER = ';';
        private const int GRUP = 0;
        private const int ID = 1;
        private const int NUME = 2;
        private const int PRENUME = 3;
        private const int ADRESA = 4;
        private const int NRTELEFON = 5;

        //proprietati
        public string grup { get; set; }
        public int idGrup { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string adresa { get; set; }
        public string nrTelefon { get; set; }

        public int optiune;

        //constructori
        public Grup()
        {
            grup = nume = prenume = adresa = nrTelefon = string.Empty;
        }

        enum grupuri
        {
            grup1 = 1,
            grup2 = 2,
            grup3 = 3,
            grup4 = 4
        };

        //public const grupuri PROGRAM_GRUP = grupuri.grup4;

        public Grup(string grup, int idPersoana, string nume, string prenume, string adresa, string nrTelefon)
        {
            this.grup = grup;
            this.idGrup = idPersoana;
            this.nume = nume;
            this.prenume = prenume;
            this.adresa = adresa;
            this.nrTelefon = nrTelefon;
        }

        public int getID()
        {
            return idGrup;
        }

        public Grup(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_FISIER);

            //ORDINEA DE PRELUARE A CAMPURILOR
            grup = dateFisier[GRUP];
            idGrup = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
            adresa = dateFisier[ADRESA];
            nrTelefon = dateFisier[NRTELEFON];
        }

        //ordinea in care sunt scrie in fisier
        public string conversieSir()
        {
            string obiectPersoanaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                SEPARATOR_FISIER,
                (grup ?? " NECUNOSCUT"),
                idGrup.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "),
                (adresa ?? "NECUNOSCUT"),
                (nrTelefon ?? "NECUNOSCUT"));

            return obiectPersoanaPentruFisier;
        }
    }
}
