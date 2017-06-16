using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Yum__Mohamed_Cherifi_
{
    public partial class Reglements : Form
    {
        public Reglements()
        {
            InitializeComponent();
            this.Text = "Règlements";
        }

        private void Reglements_Load(object sender, EventArgs e)
        {
            string strLigne = "";
            string strReglement = "reglements.txt";
            StreamReader srReglement = new StreamReader(strReglement);

            strLigne = srReglement.ReadLine();
            lbReglements.Items.Add(strLigne);

            while (srReglement.Peek() != -1)
            {
                strLigne = srReglement.ReadLine();
                lbReglements.Items.Add(strLigne);
            }
                
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
