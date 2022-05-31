using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfata
{
    public partial class Meniu : Form
    {

        Interfata interfata = new Interfata();

        public Meniu()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            interfata.Closed += (s, args) => this.Close();
            interfata.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string title = "Manual de utilizare";
            string message = "\n Bun venit!" +
                "\n\nIntroducere persoana fara grup:" +
                "\n\nPentru a adauga o persoana se introduc urmatoarele date: nume, prenume, numar de telefon si adresa" +
                "\nDupa se bifeaza butonul 'Persoana' si se apasa butonul de 'Adauga'" +
                "\n\nIntroducere persoana cu grup:" +
                "\n\nPentru a adauga o persoana se introduc urmatoarele date: nume, prenume, numar de telefon si adresa" +
                "\nDupa se bifeaza butonul 'Grup', se bifeaza un grup sau mai multe grupuri dorite precum: 'universitate' sau 'familie' si se apasa butonul de 'Adauga'" +
                "\n\nAfisare persoane:" +
                "\n\nSe bifeaza butonul 'Persoana' sau 'Grup' impreuna cu casuta numelui grupului si se apasa butonul 'Afiseaza'";
            MessageBox.Show(message, title);
        }
    }
}
