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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Variables de classe//
        string strNom;
        string strChamp = "champions.txt";
        Image[] timgDe;
        PictureBox[] tpbDe;
        CheckBox[] tcbGarder;
        int[] tintDe;
        int[] tintResultat;
        Random r;
        int intNbBrasser = 0;
        bool booPartieTerminer = false;
        bool booTricher = false;
        int intCompteurCombinaisons;

        Boolean[] tbooBoutonDisponible = new Boolean[11] { false, false, false, false, false, false, false, true, false, false, false };
        //-------------------//

        private void btnMelanger_Click(object sender, EventArgs e)
        {
            btnNouvPartie.Enabled = true;

            MelangerLesDe();

            intNbBrasser++;

            
            foreach (Control c in gbComb.Controls)
            {
                if (c is Button)
                    c.Enabled = true;
            }
            booPartieTerminer = false;
            if (booPartieTerminer == false)
            {

                for (int index = 0; index < tbooBoutonDisponible.Length; index++)
                {
                    if (index == 0 && tbooBoutonDisponible[index] == true)
                        btnCalc1.Enabled = false;

                    if (index == 1 && tbooBoutonDisponible[index] == true)
                        btnCalc2.Enabled = false;

                    if (index == 2 && tbooBoutonDisponible[index] == true)
                        btnCalc3.Enabled = false;

                    if (index == 3 && tbooBoutonDisponible[index] == true)
                        btnCalc4.Enabled = false;

                    if (index == 4 && tbooBoutonDisponible[index] == true)
                        btnCalc5.Enabled = false;

                    if (index == 5 && tbooBoutonDisponible[index] == true)
                        btnCalc6.Enabled = false;

                    if (index == 6 && tbooBoutonDisponible[index] == true)
                        btnBasse.Enabled = false;

                    if (index == 7 && tbooBoutonDisponible[index] == true)
                        btnHaute.Enabled = false;

                    if (index == 8 && tbooBoutonDisponible[index] == true)
                        btnMainPleine.Enabled = false;

                    if (index == 9 && tbooBoutonDisponible[index] == true)
                        btnSequence.Enabled = false;

                    if (index == 10 && tbooBoutonDisponible[index] == true)
                        btnYum.Enabled = false;


                }
            }

            if (intNbBrasser == 1)
            {
                btnMelanger.Text = "Brasser une seconde fois";
            }
            else if (intNbBrasser == 2)
            {
                btnMelanger.Text = "Brasser une Dernière fois";
            }
            else if (intNbBrasser == 3)
            {
                btnMelanger.Enabled = false;
            }


        }

        /**********************************************************
         * public void RetournerNom(string NomRetourner)
         * Methode pour Retouner le nom du formulaire d'accueil
         * entree: NomRetourner
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        public void RetournerNom(string NomRetourner)
        {
            strNom = NomRetourner;
            this.Text = "Bienvenue au jeu de Yum " + strNom;

            
        }

        /**********************************************************
         * private int intAdd(int numeroDe)
         * Methode pour la somme
         * entree: numeroDe
         * sortie: aucun
         * return: intCompt1
         **********************************************************/
        private int intAdd(int numeroDe)
        {
            int intCompt1 = 0;
            foreach (int intCompt2 in tintDe)
            {
                if (intCompt2 == numeroDe)
                    intCompt1 += numeroDe;
            }
            return intCompt1;
        }

       
        
    

        private void Form1_Load(object sender, EventArgs e)
        {
            gbPointage.Visible = false;
            btnNouvPartie.Enabled = false;

            timgDe = new Image[7];
            timgDe[0] = Properties.Resources.Dice_0;
            timgDe[1] = Properties.Resources.Dice_1;
            timgDe[2] = Properties.Resources.Dice_2;
            timgDe[3] = Properties.Resources.Dice_3;
            timgDe[4] = Properties.Resources.Dice_4;
            timgDe[5] = Properties.Resources.Dice_5;
            timgDe[6] = Properties.Resources.Dice_6E;

            tintDe = new int[5] { 0, 0, 0, 0, 0 };

            tintResultat = new int[6] { 0, 0, 0, 0, 0, 0 };

            tpbDe = new PictureBox[] { pbDe1, pbDe2, pbDe3, pbDe4, pbDe5 };
            tcbGarder = new CheckBox[] { cbGarder1, cbGarder2, cbGarder3, cbGarder4, cbGarder5 };

            this.Text = "Bienvenue au jeu de Yum" + strNom;
            r = new Random();

            DesactBoutton();
        }

        /**********************************************************
         * private Image NouveauDe(int intTrouver)
         * retourne une image selon le nombre trouver en parametre
         * entree: int intTrouver
         * sortie: Aucun
         * return: timgDe[intTrouver]
         **********************************************************/
        private Image NouveauDe(int intTrouver)
        {
            return timgDe[intTrouver];
        }

        /**********************************************************
         * private void MelangerLesDe()
         * Methode pour melabger les Dés
         * entree: Aucun
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        private void MelangerLesDe()
        {
            pbDe1.Image = timgDe[tintDe[0]];
            pbDe2.Image = timgDe[tintDe[1]];
            pbDe3.Image = timgDe[tintDe[2]];
            pbDe4.Image = timgDe[tintDe[3]];
            pbDe5.Image = timgDe[tintDe[4]];

            foreach (Control c in gbMesDe.Controls)
            {
                if (c is CheckBox)
                {
                    c.Visible = true;
                }
            }

            for (int i = 0; i <= tpbDe.Length - 1; i++)
            {
                if (!tcbGarder[i].Checked)
                {
                    int intRandom = r.Next(1, 7);
                    tintDe[i] = intRandom;
                    tpbDe[i].Image = timgDe[intRandom];
                }
            }

            if (btnBasse.Enabled == false && lblHaute.Text == "")
            {
                btnHaute.Enabled = true;
            }
        }

        private void btnTricher_Click(object sender, EventArgs e)
        {
            booTricher = true;
            btnNouvPartie.Enabled = true;

            pbDe1.Image = timgDe[tintDe[0]];
            pbDe2.Image = timgDe[tintDe[1]];
            pbDe3.Image = timgDe[tintDe[2]];
            pbDe4.Image = timgDe[tintDe[3]];
            pbDe5.Image = timgDe[tintDe[4]];

            foreach (Control c in gbMesDe.Controls)
            {
                if (c is CheckBox)
                {
                    c.Visible = true;
                }
            }

            for (int i = 0; i <= tpbDe.Length - 1; i++)
            {
                if (!tcbGarder[i].Checked)
                {
                    int intRandom = r.Next(1, 7);
                    tintDe[i] = intRandom;
                    tpbDe[i].Image = timgDe[intRandom];
                }
            }

            if (btnBasse.Enabled == false && lblHaute.Text == "")
            {
                btnHaute.Enabled = true;
            }

            foreach (Control c in gbComb.Controls)
            {
                if (c is Button)
                    c.Enabled = true;
            }
            for (int index = 0; index < tbooBoutonDisponible.Length; index++)
            {
                if (index == 0 && tbooBoutonDisponible[index] == true)
                    btnCalc1.Enabled = false;

                if (index == 1 && tbooBoutonDisponible[index] == true)
                    btnCalc2.Enabled = false;

                if (index == 2 && tbooBoutonDisponible[index] == true)
                    btnCalc3.Enabled = false;

                if (index == 3 && tbooBoutonDisponible[index] == true)
                    btnCalc4.Enabled = false;

                if (index == 4 && tbooBoutonDisponible[index] == true)
                    btnCalc5.Enabled = false;

                if (index == 5 && tbooBoutonDisponible[index] == true)
                    btnCalc6.Enabled = false;

                if (index == 6 && tbooBoutonDisponible[index] == true)
                    btnBasse.Enabled = false;

                if (index == 7 && tbooBoutonDisponible[index] == true)
                    btnHaute.Enabled = false;

                if (index == 8 && tbooBoutonDisponible[index] == true)
                    btnMainPleine.Enabled = false;

                if (index == 9 && tbooBoutonDisponible[index] == true)
                    btnSequence.Enabled = false;

                if (index == 10 && tbooBoutonDisponible[index] == true)
                    btnYum.Enabled = false;
            }


            
        }
    
        /**********************************************************
         * private void ActiverBouton()
         * Methode pour activer les boutons
         * entree: Aucun
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        private void ActiverBouton()
        {
            if (tbooBoutonDisponible[0])
                btnCalc1.Enabled = true;
            else
                btnCalc1.Enabled = false;
            if (tbooBoutonDisponible[1])
                btnCalc2.Enabled = true;
            else
                btnCalc2.Enabled = false;
            if (tbooBoutonDisponible[2])
                btnCalc3.Enabled = true;
            else
                btnCalc3.Enabled = false;
            if (tbooBoutonDisponible[3])
                btnCalc4.Enabled = true;
            else
                btnCalc4.Enabled = false;
            if (tbooBoutonDisponible[4])
                btnCalc5.Enabled = true;
            else
                btnCalc5.Enabled = false;
            if (tbooBoutonDisponible[5])
                btnCalc6.Enabled = true;
            else
                btnCalc6.Enabled = false;
            if (tbooBoutonDisponible[6])
                btnBasse.Enabled = true;
            else
                btnBasse.Enabled = false;
            if (tbooBoutonDisponible[7])
                btnHaute.Enabled = true;
            else
                btnHaute.Enabled = false;
            if (tbooBoutonDisponible[8])
                btnMainPleine.Enabled = true;
            else
                btnMainPleine.Enabled = false;
            if (tbooBoutonDisponible[9])
                btnSequence.Enabled = true;
            else
                btnSequence.Enabled = false;
            if (tbooBoutonDisponible[10])
                btnYum.Enabled = true;
            else
                btnYum.Enabled = false;
	    }

        /**********************************************************
         * private void DesactBoutton()
         * Methode pour desactiver les boutons
         * entree: Aucun
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        private void DesactBoutton()
        {
            foreach (Control c in gbMesDe.Controls)
            {
                if (c is CheckBox)
                    c.Visible = false;
            }

            foreach (Control c in gbComb.Controls)
            {
                if (c is Button)
                    c.Enabled = false;
            }
        }

        /**********************************************************
         * private void RecommencerPartie()
         * Methode pour Recommencer la partie
         * entree: Aucun
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        private void RecommencerPartie()
        {
            CalcPointage();
            intNbBrasser = 0;
            bool booPartieTerminer = false;


            CheckBox cbPourModifier;

            intNbBrasser = 0;

            foreach (Control c in gbComb.Controls)
            {
                if (c is Button)
                    c.Enabled = false;
            }
            foreach (Control c in gbMesDe.Controls)
            {
                if (c is CheckBox)
                {
                    c.Visible = false;
                    cbPourModifier = (CheckBox)c;
                    cbPourModifier.Checked = false;
                }
            }

            pbDe1.Image = Properties.Resources.Dice_0;
            pbDe2.Image = Properties.Resources.Dice_0;
            pbDe3.Image = Properties.Resources.Dice_0;
            pbDe4.Image = Properties.Resources.Dice_0;
            pbDe5.Image = Properties.Resources.Dice_0;

            btnMelanger.Text = "Brasser une première fois";
            btnMelanger.Enabled = true;

            if (intCompteurCombinaisons >= 11 && booPartieTerminer == false)
            {
                booPartieTerminer = true;

                if (booPartieTerminer == true)
                {
                    btnMelanger.Enabled = false;
                    MessageBox.Show("Cette partie est terminé, les points sont enregistrer.");
                    EcritureChampions();
                }

            }
            
        }

        /**********************************************************
         * private bool DesactiverAvecException()
         * Methode pour desactiver les boutons avec certaines Exception
         * entree: Aucun
         * sortie: Aucun
         * return: booDesact
         **********************************************************/
        private bool DesactiverAvecException()
        {
            bool booDesact = false;
            foreach (Control control in gbMesDe.Controls)
            {
                if (control is Button)
                    control.Enabled = false;
            }
            foreach (Control control in gbComb.Controls)
            {
                if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                    control.Visible = false;
                }
                if (control is PictureBox)
                    ((PictureBox)control).Image = this.timgDe[0];
            }

            return booDesact;
        }

        private void btnCalc1_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            tbooBoutonDisponible[0] = true;
            lblCalc1.Text = intAdd(1).ToString();
            btnCalc1.Enabled = false;
            RecommencerPartie();
            
        }

        private void btnCalc2_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            lblCalc2.Text = intAdd(2).ToString();
            btnCalc2.Enabled = false;
            tbooBoutonDisponible[1] = true;
            RecommencerPartie();
            
        }

        private void btnCalc3_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            lblCalc3.Text = intAdd(3).ToString();
            btnCalc3.Enabled = false;
            tbooBoutonDisponible[2] = true;
            RecommencerPartie();
           
        }

        private void btnCalc4_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            lblCalc4.Text = intAdd(4).ToString();
            btnCalc4.Enabled = false;
            tbooBoutonDisponible[3] = true;
            RecommencerPartie();
            
        }

        private void btnCalc5_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            lblCalc5.Text = intAdd(5).ToString();
            btnCalc5.Enabled = false;
            tbooBoutonDisponible[4] = true;
            RecommencerPartie();
            
        }

        private void btnCalc6_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            lblCalc6.Text = intAdd(6).ToString();
            btnCalc6.Enabled = false;
            tbooBoutonDisponible[5] = true;
            RecommencerPartie();
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgR;
            dlgR = MessageBox.Show(strNom + ", voulez-vous VRAIMENT quitter le jeu ?", "Quitter",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);
            if (dlgR == DialogResult.No)
                e.Cancel = true;
            

        }

        

        private void btnAffReglement_Click(object sender, EventArgs e)
        {
            string strReglement = "reglements.txt";
            
            if (File.Exists(strReglement))
            {
                Reglements FrmReglements = new Reglements();
                FrmReglements.ShowDialog();
            }
            else
            {
                MessageBox.Show(strReglement + "n'existe pas");
            }
        }

        private void cbPointage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPointage.Checked == true)
            {
                gbPointage.Visible = true;
            }
            else
                gbPointage.Visible = false;
        }

        private void btnBasse_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            int intCompteur = 0;
            tbooBoutonDisponible[7] = false;

            for (int i = 0; i < 5; i++)
            {
                intCompteur += tintDe[i];
            }
            if (intCompteur >= 21)
            {
                lblBasse.Text = intCompteur.ToString();
                btnBasse.Enabled = false;
                btnHaute.Enabled = true;
            }
            else
            {
                lblBasse.Text = "0";
                btnBasse.Enabled = false;
                btnHaute.Enabled = true;
            }

            tbooBoutonDisponible[6] = true;
            btnHaute.Enabled = true;
            RecommencerPartie();

        }

        private void btnHaute_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            
            int intBasse = int.Parse(lblBasse.Text);

            for (int i = 0; i < 5; i++)
            {
                intNbBrasser += tintDe[i];
            }
            if (intNbBrasser > intBasse)
                lblHaute.Text = intNbBrasser.ToString();
            else
                lblHaute.Text = "0";

            tbooBoutonDisponible[7] = true;
            RecommencerPartie();

        }

        private void btnMainPleine_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            
            int intCompteur1 = 0;
            int intCompteur2 = 0;
            int intCompteur3 = 0;
            int intCompteur4 = 0;
            int intCompteur5 = 0;
            int intCompteur6 = 0;

            for (int i = 0; i < 5; i++)
            {
                if (tintDe[i] == 1)
                {
                    intCompteur1 += 1;
                }
                else if (tintDe[i] == 2)
                {
                    intCompteur2 += 1;
                }
                else if (tintDe[i] == 3)
                {
                    intCompteur3 += 1;
                }
                else if (tintDe[i] == 4)
                {
                    intCompteur4 += 1;
                }
                else if (tintDe[i] == 5)
                {
                    intCompteur5 += 1;
                }
                else if (tintDe[i] == 6)
                {
                    intCompteur6 += 1;
                }
            }
            if ((intCompteur1 == 2 || intCompteur2 == 2 || intCompteur3 == 2 || intCompteur4 == 2 || intCompteur5 == 2 || intCompteur6 == 2) && (intCompteur1 == 3 || intCompteur2 == 3 
                || intCompteur3 == 3 || intCompteur4 == 3 || intCompteur5 == 3 || intCompteur6 == 3))
                lblMainPleine.Text = "25";
            else
                lblMainPleine.Text = "0";

            tbooBoutonDisponible[8] = true;
            RecommencerPartie();


        }

        private void btnDemNPartie_Click(object sender, EventArgs e)
        {


            if (intCompteurCombinaisons < 11)
            {
                intCompteurCombinaisons = 0;
                int intScoreTotal = int.Parse(lblTotal.Text);

                DialogResult dlgrNouvelPart;
                dlgrNouvelPart = MessageBox.Show(strNom + ", vous avez actuellement " + intScoreTotal.ToString() + " points." + Environment.NewLine + Environment.NewLine + "Voulez-vous enregistrer votre pointage ?", "Pointage",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (dlgrNouvelPart == DialogResult.Yes)
                {
                    EcritureChampions();
                }

                RecommencerPartie();

                foreach (Control c in gbComb.Controls)
                {
                    if (c is Label)
                    {
                        c.ResetText();
                    }
                }

                lblJeux1a6.Text = "0";
                lblBonus.Text = "0";
                lblAutresJeux.Text = "0";
                lblTotal.Text = "0";

                tbooBoutonDisponible = new Boolean[11] { false, false, false, false, false, false, false, true, false, false, false };
            }
            else
            {
                intCompteurCombinaisons = 0;

                RecommencerPartie();

                foreach (Control c in gbComb.Controls)
                {
                    if (c is Label)
                    {
                        c.ResetText();
                    }
                }

                lblJeux1a6.Text = "0";
                lblBonus.Text = "0";
                lblAutresJeux.Text = "0";
                lblTotal.Text = "0";

                tbooBoutonDisponible = new Boolean[11] { false, false, false, false, false, false, false, true, false, false, false };

            }
        }

        private void btnSequence_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            
            int intCompteur1 = 0;
            int intCompteur2 = 0;
            int intCompteur3 = 0;
            int intCompteur4 = 0;
            int intCompteur5 = 0;
            int intCompteur6 = 0;

            for (int i = 0; i < 5; i++)
            {
                if (tintDe[i] == 1)
                {
                    intCompteur1 += 1;
                }
                else if (tintDe[i] == 2)
                {
                    intCompteur2 += 1;
                }
                else if (tintDe[i] == 3)
                {
                    intCompteur3 += 1;
                }
                else if (tintDe[i] == 4)
                {
                    intCompteur4 += 1;
                }
                else if (tintDe[i] == 5)
                {
                    intCompteur5 += 1;
                }
                else if (tintDe[i] == 6)
                {
                    intCompteur6 += 1;
                }
            }
            if ((intCompteur1 >= 1 && intCompteur2 >= 1 && intCompteur3 >= 1 && intCompteur4 >= 1 && intCompteur5 >= 1) || (intCompteur2 >= 1 && intCompteur3 >= 1 && intCompteur4 >= 1 && intCompteur5 >= 1 && intCompteur6 >= 1))
                lblSequence.Text = "25";
            else
                lblSequence.Text = "0";

            tbooBoutonDisponible[9] = true;
            RecommencerPartie();
        }

        private void btnYum_Click(object sender, EventArgs e)
        {
            ++intCompteurCombinaisons;
            
            if (tintDe[0] == tintDe[1] && tintDe[1] == tintDe[2] && tintDe[2] == tintDe[3] && tintDe[3] == tintDe[4])
                lblYum.Text = "35";
            else
                lblYum.Text = "0";

            
            tbooBoutonDisponible[10] = true;
            RecommencerPartie();
        }

        /**********************************************************
         * public void CalcPointage()
         * Methode pour calculer le pointage
         * entree: Aucun
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        public void CalcPointage()
        {
            //Pour trouver le bonus :
            bool booBonus = false;
            int intPoint1 = 0;
            int intPoint2 = 0;
            int intPoint3 = 0;
            int intPoint4 = 0;
            int intPoint5 = 0;
            int intPoint6 = 0;
            int intPointBasse = 0;
            int intPointHaute = 0;
            int intPointSequence = 0;
            int intPointMainPleine = 0;
            int intPointYum = 0;
            int intPointAutresJeux = 0;
            int intSommePoint = 0;


            if (lblCalc1.Text != "")
                intPoint1 = int.Parse(lblCalc1.Text);

            if (lblCalc2.Text != "")
                intPoint2 = int.Parse(lblCalc2.Text);

            if (lblCalc3.Text != "")
                intPoint3 = int.Parse(lblCalc3.Text);

            if (lblCalc4.Text != "")
                intPoint4 = int.Parse(lblCalc4.Text);

            if (lblCalc5.Text != "")
                intPoint5 = int.Parse(lblCalc5.Text);

            if (lblCalc6.Text != "")
                intPoint6 = int.Parse(lblCalc6.Text);

            if (lblBasse.Text != "")
                intPointBasse = int.Parse(lblBasse.Text);

            if (lblHaute.Text != "")
                intPointHaute = int.Parse(lblHaute.Text);

            if (lblSequence.Text != "")
                intPointSequence = int.Parse(lblSequence.Text);

            if (lblMainPleine.Text != "")
                intPointMainPleine = int.Parse(lblMainPleine.Text);

            if (lblYum.Text != "")
                intPointYum = int.Parse(lblYum.Text);

            intPointAutresJeux = (intPointBasse + intPointHaute + intPointMainPleine + intPointSequence + intPointYum);
            intSommePoint = (intPoint1 + intPoint2 + intPoint3 + intPoint4 + intPoint5 + intPoint6);

            if (intSommePoint >= 63)
                booBonus = true;
            else
                booBonus = false;

            if (booBonus)
                lblBonus.Text = "25";
            else
                lblBonus.Text = "0";

            int intBonus = int.Parse(lblBonus.Text);

            lblJeux1a6.Text = intSommePoint.ToString();
            lblAutresJeux.Text = intPointAutresJeux.ToString();
            lblTotal.Text = (intSommePoint + intPointAutresJeux + intBonus).ToString();

        }

        /**********************************************************
         * private void EcritureChampions()
         * Methode pour Ecrire dans le fichier champions
         * entree: Aucun
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        private void EcritureChampions()
        {
            int intScoreTotal = int.Parse(lblTotal.Text);

            FileInfo fiFichierChamp = new FileInfo(strChamp);

            //Date Format (aaaa/mm/jj)
            string strAnnee = fiFichierChamp.LastWriteTime.Year.ToString("D2") + "/";
            string strMois = fiFichierChamp.LastWriteTime.Month.ToString("D2") + "/";
            string strJour = fiFichierChamp.LastWriteTime.Day.ToString("D2") + "-";

            //Date Format (hh:mm:ss)
            string strHeure = fiFichierChamp.LastWriteTime.Hour.ToString("D2") + ":";
            string strMinute = fiFichierChamp.LastWriteTime.Minute.ToString("D2") + ":";
            string strSeconde = fiFichierChamp.LastWriteTime.Second.ToString("D2");

            string strDate = strAnnee + strMois + strJour + strHeure + strMinute + strSeconde;

            StreamWriter swChampions = new StreamWriter(strChamp, true);

            if (booTricher == false)
            {
                swChampions.Write(strNom.PadRight(25));
                swChampions.Write(".....");
                swChampions.Write(strDate.PadRight(19));
                swChampions.Write(".....Points : ");
                swChampions.Write(intScoreTotal.ToString());
                swChampions.WriteLine();
            }
            else
            {
                swChampions.Write(strNom.PadRight(25));
                swChampions.Write(".....");
                swChampions.Write(strDate.PadRight(19));
                swChampions.Write(".....Points : ");
                swChampions.Write( "-" + intScoreTotal.ToString());
                swChampions.WriteLine();
            }
            swChampions.Close();
             
        }

        private void btnSuppChp_Click(object sender, EventArgs e)
        {
            if (File.Exists("champions.txt"))
            {
                DialogResult dlgr;
                dlgr = MessageBox.Show("Voulez-vous vraiment supprimer le fichier champions.txt","Suppression",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (dlgr == DialogResult.Yes )
                {
                    MessageBox.Show("Le fichier champion.txt a été supprimé !", "Suppression");
                    FileInfo FChamp = new FileInfo(strChamp);
                    FChamp.Delete();
                }

            }
            else
            {
                MessageBox.Show("Le fichier champions.txt n'existe pas!" + Environment.NewLine + "il sera créé lorsque nécessaire!", "Erreur");
            }
        }

        /**********************************************************
         * private void AfficherChampions()
         * Methode pour Afficher le fichier champions dans le lblChampions
         * entree: Aucun
         * sortie: Aucun
         * return: Aucun
         **********************************************************/
        private void AfficherChampions()
        {
            int intCompteurLigne = 0;
            

            if (File.Exists(strChamp))
            {
                lblChampions.ResetText();
                StreamReader srChampions = new StreamReader(strChamp);
                string strLigne = srChampions.ReadLine();

                while (strLigne != null)
                {
                    intCompteurLigne++;
                    strLigne = srChampions.ReadLine();
                }

                string[] tstrNom = new string[intCompteurLigne];
                string[] tstrDate = new string[intCompteurLigne];
                int[] tintScore = new int[intCompteurLigne];

                    srChampions = new StreamReader(strChamp);

                    for (int ligne = 0; ligne < intCompteurLigne; ligne++)
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            tstrNom[ligne] += (char)srChampions.Read();
                        }

                        tstrNom[ligne] = tstrNom[ligne].Trim();

                        for (int z = 0; z < 38; z++)
                        {
                            tstrDate[ligne] += (char)srChampions.Read();
                        }

                        tstrDate[ligne] = tstrDate[ligne].Trim();

                        tintScore[ligne] = int.Parse(srChampions.ReadLine());

                        lblChampions.Text += tstrNom[ligne].PadRight(25) + "---> " + tintScore[ligne].ToString() + Environment.NewLine;
                    }

                        srChampions.Close();
                
            }
            else
            {
                MessageBox.Show("Le Fichier champions.txt n'existe pas", "Erreur");
            }
        }

        private void cbChampions_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChampions.Checked == true)
            {
                lblChampions.Visible = true;
                AfficherChampions();
            }
            else
            {
                lblChampions.Visible = false;
            }

            
        }

        }

        }

        

        

        
    




