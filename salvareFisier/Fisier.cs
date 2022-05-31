using System;
using clasaPersoana;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace salvareFisier
{
    public class Fisier
    {
        private const int NR_MAX_PERSOANE = 50;
        private string numeFisier;

        public Fisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddPersoana(Persoana persoana)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(persoana.conversieSir());
            }
        }

        public List<Persoana> GetPersoana()
        {
            ArrayList persoane = new ArrayList();
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Persoana pers = new Persoana(linieFisier);
                    persoane.Add(pers);
                }
            }

            return persoane.Cast<Persoana>().ToList();
        }

        public Persoana[] GetPersoana(out int nrPersoane)
        {
            Persoana[] persoana = new Persoana[NR_MAX_PERSOANE];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrPersoane = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    persoana[nrPersoane++] = new Persoana(linieFisier);
                }
            }

            Array.Resize(ref persoana, nrPersoane);

            return persoana;
        }

        public Persoana GetPersoane(string nume, string prenume)
        {

            Persoana persoana;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {

                    persoana = new Persoana(linieFisier);
                    if (persoana.nume == nume && persoana.prenume == prenume)
                    {

                        return persoana;

                    }

                }
                Persoana persoana_invalid = new Persoana();
                return persoana_invalid;
            }

        }
    }
}
