using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitairesSLAM;

namespace PileWinformLibrairie
{
    public partial class Convertisseur : Form
    {
        public Convertisseur()
        {
            InitializeComponent();
        }

        private void btnConversion_Click(object sender, EventArgs e)
        {
            Int32 nbAConvertir = 0, resultat, reste;
            Int16 newBase = 0;
            txtResultat.Clear();
            try
            {
                nbAConvertir = Int32.Parse(mskNbAConvertir.Text);
                newBase = Int16.Parse(nudNouvelleBase.Text);
                Pile<int> Wonder = new Pile<int>();
                resultat = nbAConvertir;
                //Reste = 0
                while (resultat != 0)
                {
                    reste = resultat % newBase;
                    resultat = resultat / newBase;
                    Wonder.Empiler(reste);
                }
                while (!Wonder.PileVide())
                {
                    int retour = Wonder.Depiler();
                    if (retour < 10)
                    {
                        txtResultat.Text += retour.ToString();
                    }
                    else
                    {
                        txtResultat.Text += (System.Convert.ToChar(55 + retour));
                    }
                }
            }
            catch (OverflowException oex) 
            {
                MessageBox.Show("Nombre trop grand");
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Nombre trop grand");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
