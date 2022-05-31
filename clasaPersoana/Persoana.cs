using System;
using clasaPersoana;

namespace clasaPersoana
{
    public class Persoana
    {
        //constante
        private const char SEPARATOR_FISIER = ';';
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int ADRESA = 3;
        private const int NRTELEFON = 4;

        //proprietati auto-implemented
        public int idPersoana { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string adresa { get; set; }
        public string nrTelefon { get; set; }

        //constructori
        public Persoana()
        {
            nume = prenume = adresa = nrTelefon = string.Empty;
        }

        public Persoana(int idPersoana, string nume, string prenume, string adresa, string nrTelefon)
        {
            this.idPersoana = idPersoana;
            this.nume = nume;
            this.prenume = prenume;
            this.adresa = adresa;
            this.nrTelefon = nrTelefon;
        }

        public int getIDPersoana()
        {
            return idPersoana;
        }

        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_FISIER);

            //ORDINEA DE PRELUARE A CAMPURILOR
            idPersoana = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
            adresa = dateFisier[ADRESA];
            nrTelefon = dateFisier[NRTELEFON];
        }

        //ordinea in care sunt scrie in fisier
        public string conversieSir()
        {
            string obiectPersoanaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_FISIER,
                idPersoana.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "),
                (adresa ?? "NECUNOSCUT"),
                (nrTelefon ?? "NECUNOSCUT"));

            return obiectPersoanaPentruFisier;
        }
    }
}

