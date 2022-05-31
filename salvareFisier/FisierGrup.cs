using System;
using clasaPersoana;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace salvareFisier
{
    public class FisierGrup
    {
        private const int NR_MAX_PERSOANE = 20;
        private string numeGrup;

        public FisierGrup(string numeGrup)
        {
            this.numeGrup = numeGrup;
            Stream streamFisierText = File.Open(numeGrup, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public List<Grup> GetGrup()
        {
            ArrayList grup = new ArrayList();
            using (StreamReader streamReader = new StreamReader(numeGrup))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Grup gr = new Grup(linieFisier);
                    grup.Add(gr);
                }
            }

            return grup.Cast<Grup>().ToList();
        }

        public Grup[] GetGrup(out int nrGrupuri)
        {
            Grup[] grup = new Grup[NR_MAX_PERSOANE];
            using (StreamReader streamReader = new StreamReader(numeGrup))
            {
                string linieFisier;
                nrGrupuri = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    grup[nrGrupuri++] = new Grup(linieFisier);
                }
            }

            Array.Resize(ref grup, nrGrupuri);
            return grup;
        }


        public void AddGrup(Grup grup)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeGrup, true))
            {
                streamWriterFisierText.WriteLine(grup.conversieSir());
            }

        }
    }
}