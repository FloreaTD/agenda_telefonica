using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;
using clasaPersoana;
using salvareFisier;

namespace Interfata
{
    public partial class Interfata : Form
    {
        
        
            Fisier adminPersoana; FisierGrup adminnGrup;

            private Label lblHeaderNume; private Label lblHeaderPrenume; private Label lblHeadernrTel;  private Label lblHeaderAdresa;

            private Label[] lblsNume; private Label[] lblsPrenume; private Label[] lblsnrTel; private Label[] lblsAdresa;

            private const int LATIME_CONTROL = 100;
            private const int DIMENSIUNE_PAS_Y = 30;
            private const int DIMENSIUNE_PAS_X = 150;
            private const int OFFSET_X = 350;

            ArrayList grupuriSelectate = new ArrayList();

            string fisGrup = string.Empty; string fissGrup = string.Empty; bool flag = false; int counter = 0;
           
        public Interfata()
            {
                string numeFisier = "Persoana.txt";
                string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
                adminPersoana = new Fisier(caleCompletaFisier);
                InitializeComponent();

                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(100, 100);
                this.Font = new Font("Arial", 10, FontStyle.Bold);
                this.ForeColor = Color.Black;
                this.Text = "Agenda telefonica";
                AfiseazaPersoane();

                label1.Font = new Font("Arial", 12, FontStyle.Bold);
        }

            private void ResetareDate()
            {
                nume.Text = prenume.Text = adresa.Text = nrtelefon.Text = string.Empty;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                grupuriSelectate.Clear();
            }

            private void OnMouseEnter(object sender, EventArgs e)
            {
            Label label = sender as Label;
            label.ForeColor = Color.LightBlue;
            label.Font = new Font("Arial", 14, FontStyle.Bold | FontStyle.Underline);
            }

         private void OnMouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.DarkBlue;
            label.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
        }

        private void AfiseazaPersoane()
            {
                this.Controls.Clear();
                this.InitializeComponent();

                string numefisier_buget = fissGrup + ".txt";
                string locatiefisier_solutie_buget = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string cale_completa_fisier_buget = locatiefisier_solutie_buget + "\\" + numefisier_buget;
                adminnGrup = new FisierGrup(cale_completa_fisier_buget);

                lblHeaderNume = new Label();
                lblHeaderNume.Width = LATIME_CONTROL;
                lblHeaderNume.Text = "Nume";
                lblHeaderNume.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                lblHeaderNume.Left = OFFSET_X + 0;
                lblHeaderNume.ForeColor = Color.DarkBlue;
                lblHeaderNume.MouseEnter += OnMouseEnter;
                lblHeaderNume.MouseLeave += OnMouseLeave;
                this.Controls.Add(lblHeaderNume);

                lblHeaderPrenume = new Label();
                lblHeaderPrenume.Width = LATIME_CONTROL;
                lblHeaderPrenume.Text = "Prenume";
                lblHeaderPrenume.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                lblHeaderPrenume.Left = OFFSET_X + DIMENSIUNE_PAS_X;
                lblHeaderPrenume.ForeColor = Color.DarkBlue;
                lblHeaderPrenume.MouseEnter += OnMouseEnter;
                lblHeaderPrenume.MouseLeave += OnMouseLeave;
                this.Controls.Add(lblHeaderPrenume);

                lblHeadernrTel = new Label();
                lblHeadernrTel.Width = LATIME_CONTROL;
                lblHeadernrTel.Text = "Numar";
                lblHeadernrTel.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                lblHeadernrTel.Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
                lblHeadernrTel.ForeColor = Color.DarkBlue;
                lblHeadernrTel.MouseEnter += OnMouseEnter;
                lblHeadernrTel.MouseLeave += OnMouseLeave;
                this.Controls.Add(lblHeadernrTel);

                lblHeaderAdresa = new Label();
                lblHeaderAdresa.Width = LATIME_CONTROL;
                lblHeaderAdresa.Text = "Adresa";
                lblHeaderAdresa.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                lblHeaderAdresa.Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
                lblHeaderAdresa.ForeColor = Color.DarkBlue;
                lblHeaderAdresa.MouseEnter += OnMouseEnter;
                lblHeaderAdresa.MouseLeave += OnMouseLeave;
                this.Controls.Add(lblHeaderAdresa);

                Grup[] grupuri = adminnGrup.GetGrup(out int nrGrupuri);
                Persoana[] persoane = adminPersoana.GetPersoana(out int nrPersoane);

                if(flag == false)
                {
                    lblsNume = new Label[nrPersoane];
                    lblsPrenume = new Label[nrPersoane];
                    lblsnrTel = new Label[nrPersoane];
                    lblsAdresa = new Label[nrPersoane];
                    int i = 0;
                    List<Persoana> perss = adminPersoana.GetPersoana();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = perss;
                foreach (Persoana pers in persoane)
                    {

                    lblsNume[i] = new Label();
                    lblsNume[i].Width = LATIME_CONTROL;
                    lblsNume[i].Text = pers.nume;
                    lblsNume[i].Left = OFFSET_X + 0;
                    lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsNume[i]);

                    lblsPrenume[i] = new Label();
                    lblsPrenume[i].Width = LATIME_CONTROL;
                    lblsPrenume[i].Text = pers.prenume;
                    lblsPrenume[i].Left = OFFSET_X + DIMENSIUNE_PAS_X;
                    lblsPrenume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsPrenume[i]);

                    lblsnrTel[i] = new Label();
                    lblsnrTel[i].Width = LATIME_CONTROL;
                    lblsnrTel[i].Text = pers.nrTelefon;
                    lblsnrTel[i].Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
                    lblsnrTel[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsnrTel[i]);

                    lblsAdresa[i] = new Label();
                    lblsAdresa[i].Width = LATIME_CONTROL + 80;
                    lblsAdresa[i].Text = pers.adresa;
                    lblsAdresa[i].Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
                    lblsAdresa[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsAdresa[i]);
                    i++;
                    }
                }
                else
                {
                    List<Grup> grup = adminnGrup.GetGrup();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = grup;
                    lblsNume = new Label[nrGrupuri];
                    lblsPrenume = new Label[nrGrupuri];
                    lblsnrTel = new Label[nrGrupuri];
                    lblsAdresa = new Label[nrGrupuri];

                int i = 0;
                foreach (Grup persoana in grupuri)
                {
                    lblsNume[i] = new Label();
                    lblsNume[i].Width = LATIME_CONTROL;
                    lblsNume[i].Text = persoana.nume;
                    lblsNume[i].Left = OFFSET_X + 0;
                    lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsNume[i]);

                    lblsPrenume[i] = new Label();
                    lblsPrenume[i].Width = LATIME_CONTROL;
                    lblsPrenume[i].Text = persoana.prenume;
                    lblsPrenume[i].Left = OFFSET_X + DIMENSIUNE_PAS_X;
                    lblsPrenume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsPrenume[i]);

                    lblsnrTel[i] = new Label();
                    lblsnrTel[i].Width = LATIME_CONTROL;
                    lblsnrTel[i].Text = persoana.nrTelefon;
                    lblsnrTel[i].Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
                    lblsnrTel[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsnrTel[i]);

                    lblsAdresa[i] = new Label();
                    lblsAdresa[i].Width = LATIME_CONTROL + 80;
                    lblsAdresa[i].Text = persoana.adresa;
                    lblsAdresa[i].Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
                    lblsAdresa[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsAdresa[i]);
                    Console.WriteLine(persoana.nume);
                    i++;
                }
            }
        }
            
            private void Interfata_Load(object sender, EventArgs e)
            {
                AfiseazaPersoane();
            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                string numeFis = fissGrup+".txt";
                stergereFisier(numeFis);
            }
            else
            {
                string numeFis = "Persoana.txt";
                stergereFisier(numeFis);
            }
            AfiseazaPersoane();
            label1.Text = "Persoana stearsa cu succes!";
        }

        private void stergereFisier(string numeFis)
        {
            string tempFile = Path.GetTempFileName();
            string numeFisier = numeFis;
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = locatieFisierSolutie + "\\" + numeFisier;
            if(nume.Text != string.Empty || nume.Text != "")
            {
                using (var sr = new StreamReader(filePath))
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(prenume.Text) != true && line.Contains(nume.Text) != true)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
                File.Delete(filePath);
                File.Move(tempFile, filePath);
            }
        }

        private void CkbDiscipline_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox;

            string grupSelectat = checkBoxControl.Text;

            if (checkBoxControl.Checked == true)
            {
                grupuriSelectate.Add(grupSelectat);
                fissGrup = (string)grupSelectat;
            }
            else
            {
                grupuriSelectate.Remove(grupSelectat);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numarLitereTelefon = nrtelefon.Text.Length;

                if (nume.Text == String.Empty && prenume.Text == String.Empty && nrtelefon.Text == String.Empty && adresa.Text == String.Empty)
                {
                    label1.Text = " Nu ai introdus datele!";
                }
                else if (nume.Text == String.Empty)
                {
                    label1.Text = " Nu ai introdus numele!";
                }
                else if (prenume.Text == String.Empty)
                {
                    label1.Text = " Nu ai introdus prenumele!";
                }
                else if (nrtelefon.Text == String.Empty)
                {
                    label1.Text = " Nu a introdus numarul de telefon!";
                }
                else if (numarLitereTelefon != 10)
                {
                    label1.Text = " Numar de telefon invalid!";
                }
                else if(radioButton1.Checked)
                {
                    Persoana[] persoane = adminPersoana.GetPersoana(out int nrPersoane);
                Persoana pers = new Persoana(persoane[nrPersoane - 1].getIDPersoana() + 1, nume.Text, prenume.Text, adresa.Text, nrtelefon.Text);
                    adminPersoana.AddPersoana(pers);
                    label1.Text = " Persoana introdusa cu succes!";
                    ResetareDate();
                    AfiseazaPersoane();
                }
                else if(radioButton2.Checked)
                { 
                    for (int intCounter = 0; intCounter < grupuriSelectate.Count; intCounter++)
                    {
                        Console.WriteLine(grupuriSelectate.Count);
                        fisGrup = (string)grupuriSelectate[intCounter];
                        string numefisier_grup = fisGrup + ".txt";
                        string locatiefisier_solutie_grup = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                        string cale_completa_fisier_grup = locatiefisier_solutie_grup + "\\" + numefisier_grup;
                        adminnGrup = new FisierGrup(cale_completa_fisier_grup);
                        Grup[] grup = adminnGrup.GetGrup(out int nrGrupuri);
                        Console.WriteLine(nrGrupuri);
                        if(nrGrupuri == 0)
                        {
                            Grup grupuri = new Grup(fisGrup, nrGrupuri+1 , nume.Text, prenume.Text, adresa.Text, nrtelefon.Text);
                            adminnGrup.AddGrup(grupuri);
                        }
                        else
                        {
                            Grup grupuri = new Grup(fisGrup, grup[nrGrupuri - 1].getID() + 1, nume.Text, prenume.Text, adresa.Text, nrtelefon.Text);
                            adminnGrup.AddGrup(grupuri);
                        }
                    }
                    ResetareDate();
                    label1.Text = " Persoana introdusa cu succes!";
                }
                else
                {
                    label1.Text = "Nu ai ales persoana sau grup!";
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                AfiseazaPersoane();
            }
            else if (radioButton2.Checked)
            {
                if (fissGrup != "")
                {
                    flag = true;
                    AfiseazaPersoane();
                    flag = false;
                    fissGrup = "";
                }
                else
                {
                    label1.Text = " Nu ai ales un grup!";
                }
            }
            else
            {
                label1.Text = " Nu ai ales persoana sau grup!";
            }
        }
    }
}