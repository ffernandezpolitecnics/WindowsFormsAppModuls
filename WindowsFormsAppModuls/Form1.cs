using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppModuls
{
    public partial class Form1 : Form
    {
        String[] cursosMati = { "DAM1A", "DAM2A", "DAW1A", "DAW2A" };
        String[] cursosTarda = { "DAM1T", "DAM2T" };
        String[] professorsDAM1A = { "Serrano, Joan", "García, José Luís", "Segura, Consuelo", "Méndez Urbano" };
        String[] professorsDAM2A = { "Serrano, Joan", "García, José Luís", "Segura, Consuelo", "Méndez Urbano", "Fernández, Francisco" };
        String[] professorsDAW1A = { "Serrano, Joan", "Galcerà, Xavi", "Segura, Consuelo" };
        String[] professorsDAW2A = { "Serrano, Joan", "Domingo, Antonio", "Martínez, Alba", "Méndez Urbano", "Fernández, Francisco" };
        String[] professorsDAM1T = { "Martínez, Alba", "Méndez Urbano" };
        String[] professorsDAM2T = { "Serrano, Joan", "Domingo, Antonio", "Martínez, Alba", "Méndez Urbano", "Fernández, Francisco" };
        String[] moduls = { "Sistemes informàtics", "Bases de dades", "Programació", "Llenguatge de Marques", "Entorns de desenvolupaments",
            "Disseny interfícies", "Programació mòbils", "Programació serveis i processos", "Sistemes gestors empresarials", "Projecte" };


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Omplir els mòduls
            comboBoxModul.Items.AddRange(moduls);

            OmplirCursos(radioButtonMati, comboBoxCurs);
            OmplirCursos(radioButtonMatiVol, comboBoxCursVol);

        }

        private void OmplirCursos(RadioButton r, ComboBox c)
        {
            c.Items.Clear();

            if (r.Checked)
            {
                c.Items.AddRange(cursosMati);
            }
            else
            {
                c.Items.AddRange(cursosTarda);
            }
        }

        private void radioButtonMati_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTutor.Clear();
            comboBoxProfessor.Items.Clear();
            OmplirCursos(radioButtonMati, comboBoxCurs);
        }

        private void radioButtonMatiVol_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTutorVol.Clear();
            comboBoxProfessorVol.Items.Clear();
            OmplirCursos(radioButtonMatiVol, comboBoxCursVol);
        }

        private void comboBoxCurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            OmplirTutor(comboBoxCurs, textBoxTutor);
            OmplirProfessors(comboBoxCurs.SelectedItem.ToString(), comboBoxProfessor);
        }

        private void comboBoxCursVol_SelectedIndexChanged(object sender, EventArgs e)
        {
            OmplirTutor(comboBoxCursVol, textBoxTutorVol);
            OmplirProfessors(comboBoxCursVol.SelectedItem.ToString(), comboBoxProfessorVol);
        }

        private void OmplirProfessors(string curs, ComboBox c)
        {
            c.Items.Clear();

            switch (curs)
            {
                case "DAM1A":
                    c.Items.AddRange(professorsDAM1A);
                    break;
                case "DAM2A":
                    c.Items.AddRange(professorsDAM2A);
                    break;
                case "DAW1A":
                    c.Items.AddRange(professorsDAW1A);
                    break;
                case "DAW2A":
                    c.Items.AddRange(professorsDAW2A);
                    break;
                case "DAM1T":
                    c.Items.AddRange(professorsDAM1T);
                    break;
                case "DAM2T":
                    c.Items.AddRange(professorsDAM2T);
                    break;
            }
        }

        private void OmplirTutor(ComboBox c, TextBox t)
        {           
            switch (c.SelectedItem.ToString())
            {
                case "DAM1A":
                    t.Text = "Serrano, Joan";
                    break;
                case "DAM2A":
                    t.Text = "García, José Luis";
                    break;
                case "DAW1A":
                    t.Text = "Segura, Consuelo";
                    break;
                case "DAW2A":
                    t.Text = "Domingo, Antonio";
                    break;
                case "DAM1T":
                    t.Text = "Martínez, Alba";
                    break;
                case "DAM2T":
                    t.Text = "Fernández, Francisco";
                    break;
            }
        }

        private void buttonAfegirResum_Click(object sender, EventArgs e)
        {
            if (ValidarDades())
            {

            }
        }

        private bool ValidarDades()
        {
            bool correcte = true;

            if (textBoxCognoms.Text.Equals(""))
            {
                correcte = false;
                MessageBox.Show("Els cognoms no poden estar buits", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCognoms.Focus();
            }
            else if (textBoxNom.Text.Equals(""))
            {
                correcte = false;
                MessageBox.Show("El nom no pot estar buit", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNom.Focus();
            }
            else if (comboBoxModul.SelectedIndex == -1)
            {
                correcte = false;
                MessageBox.Show("S'ha de seleccionar un mòdul", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxModul.Select();
            }
            else if (checkedListBoxUfs.CheckedItems.Count == 0)
            {
                correcte = false;
                MessageBox.Show("S'ha de seleccionar almneys una UF", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkedListBoxUfs.Focus();
            }
            else if (comboBoxCurs.SelectedIndex == -1)
            {
                correcte = false;
                MessageBox.Show("S'ha de seleccionar un curs", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxCurs.Select();
            }
            else if (comboBoxCursVol.SelectedIndex == -1)
            {
                correcte = false;
                MessageBox.Show("S'ha de seleccionar un curs", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxCursVol.Select();
            }
            else if (comboBoxProfessor.SelectedIndex == -1)
            {
                correcte = false;
                MessageBox.Show("S'ha de seleccionar un professor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxProfessor.Select();
            }
            else if (comboBoxProfessorVol.SelectedIndex == -1)
            {
                correcte = false;
                MessageBox.Show("S'ha de seleccionar un professor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxProfessorVol.Select();
            }

            return correcte;
        }
    }
}
