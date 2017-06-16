using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yum__Mohamed_Cherifi_
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }
        private void btnJouer_Click(object sender, EventArgs e)
        {
            string strNom = tbNom.Text;
            if (strNom.Length < 2 || strNom.Length > 25)
            {
                MessageBox.Show("Vous devez entrer un nom ayant entre 2 et 25 caractères", "Erreur", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                tbNom.Focus();
                tbNom.SelectAll();
            }
            else
            {
                this.Hide();
                Form1 FrmYum = new Form1();
                FrmYum.Show();
                FrmYum.RetournerNom(tbNom.Text);
            }
            
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.Text = "Bienvenue au jeu de YUM";
            this.tbNom.Focus();
            
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        public void RetournerNom(ref string Nom)
        {
            Nom = tbNom.Text;

        }

        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            tbNom.Focus();
        }
    }
}
