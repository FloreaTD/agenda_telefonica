using System;
using System.Configuration;
using salvareFisier;
using clasaPersoana;

namespace proiect_agenda_piu
{

    class Program
    {
        static void Main(string[] args)
        {
            string optiune, nume = "none", prenume = "none", nrTelefon = "none", adresa = "none", fisGrup = "none";
            string numeFisier = "Persoana.txt";
            Fisier adminPersoana = new Fisier(numeFisier);
            int nrPersoane = 0;
            int idPersoana = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nA. Afisare persoana din fisier");
                Console.WriteLine("S. Salvare persoana in fisier ");
                Console.WriteLine("F. Afisare persoane din grup");
                Console.WriteLine("D. Salvare persoana in grup");
                Console.WriteLine("C. Citire persoana ");
                Console.WriteLine("L. Cautare persoana ");
                Console.WriteLine("B. Stergere ecran ");
                Console.WriteLine("X. Inchidere program ");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "A":
                        Persoana[] persoane = adminPersoana.GetPersoana(out nrPersoane);
                        AfisarePersoane(persoane, nrPersoane);
                        break;

                    case "F":
                        Console.WriteLine("Introduceti numele grupului:");
                        fisGrup = Console.ReadLine();
                        string fisierGrup = fisGrup + ".txt";
                        FisierGrup adminGrup = new FisierGrup(fisierGrup);
                        Grup[] grup = adminGrup.GetGrup(out nrPersoane);
                        AfisareGrup(grup, nrPersoane);
                        break;

                    case "S":
                        idPersoana = nrPersoane + 1;
                        nrPersoane = nrPersoane + 1;
                        Persoana persoana = new Persoana(idPersoana, nume, prenume, adresa, nrTelefon);
                        adminPersoana.AddPersoana(persoana);
                        Console.WriteLine("Salvare efectuata");
                        break;

                    case "D":
                        Console.WriteLine("Introduceti numele grupului:");
                        fisGrup = Console.ReadLine();
                        string fisierrGrup = fisGrup + ".txt";
                        FisierGrup adminnGrup = new FisierGrup(fisierrGrup);
                        int idGrup = nrPersoane + 1;
                        nrPersoane = nrPersoane + 1;
                        Grup grupuri = new Grup(fisGrup, idGrup, nume, prenume, adresa, nrTelefon);
                        adminnGrup.AddGrup(grupuri);
                        Console.WriteLine("Salvare efectuata");
                        break;

                    case "L":
                        Console.WriteLine("Introduceti numele:");
                        nume = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele:");
                        prenume = Console.ReadLine();
                        Persoana persoana_cautata = adminPersoana.GetPersoane(nume, prenume);
                        if (string.IsNullOrEmpty(persoana_cautata.nume) && string.IsNullOrEmpty(persoana_cautata.prenume))
                        {
                            Console.WriteLine("Aceasta persoana NU exista!");
                        }
                        else
                        {
                            AfisarePersoanaCautata(persoana_cautata);
                        }
                        break;

                    case "C":
                        Console.WriteLine("Introduceti numele:");
                        nume = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele:");
                        prenume = Console.ReadLine();
                        Console.WriteLine("Introduceti adresa:");
                        adresa = Console.ReadLine();
                        Console.WriteLine("Introduceti numarul de telefon:");
                        nrTelefon = Console.ReadLine();
                        break;

                    case "B":
                        Console.Clear();
                        break;

                    case "X":
                        Console.WriteLine("Programul se inchide..");
                        return;
                    default:
                        Console.WriteLine("Optiunea nu exista!");
                        break;
                }
            } while (optiune.ToUpper() != "X");
        }

        public static void AfisarePersoane(Persoana[] persoana, int nrPersoane)
        {
            Console.WriteLine("Persoanele sunt:");
            for (int contor = 0; contor < nrPersoane; contor++)
            {
                string infoPersoana = string.Format(
                    "\n------------------" +
                    "\nID: #{0}" +
                    "\nNume: {1} {2}" +
                    "\nAdresa: {3}" +
                    "\nTelefon: {4}" +
                    "\n------------------",
                   persoana[contor].idPersoana,
                   persoana[contor].nume,
                   persoana[contor].prenume,
                   persoana[contor].adresa,
                   persoana[contor].nrTelefon);

                Console.WriteLine(infoPersoana);
            }
        }

        public static void AfisareGrup(Grup[] grupuri, int nrGrupuri)
        {
            Console.WriteLine("Persoanele sunt:");
            for (int contor = 0; contor < nrGrupuri; contor++)
            {
                string infoGrup = string.Format(
                    "\n------------------" +
                    "\nGRUP: {0}" +
                    "\nID: #{1}" +
                    "\nNume: {2} {3}" +
                    "\nAdresa: {4}" +
                    "\nTelefon: {5}" +
                    "\n------------------",
                   grupuri[contor].grup,
                   grupuri[contor].idGrup,
                   grupuri[contor].nume,
                   grupuri[contor].prenume,
                   grupuri[contor].adresa,
                   grupuri[contor].nrTelefon);

                Console.WriteLine(infoGrup);
            }
        }

        public static void AfisarePersoanaCautata(Persoana persoana_cautata)
        {
            string infoPersoana = string.Format(
                             "\n------------------" +
                             "\nID: #{0}" +
                             "\nNume: {1} {2}" +
                             "\nAdresa: {3}" +
                             "\nTelefon: {4}" +
                             "\n------------------",
                             persoana_cautata.idPersoana,
                             persoana_cautata.nume,
                             persoana_cautata.prenume,
                             persoana_cautata.adresa,
                             persoana_cautata.nrTelefon);
            Console.WriteLine(infoPersoana);
        }
    }
}
