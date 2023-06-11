using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarche
{

    
    public partial class Connexion : Form
    {
        Functions Con;
        public Connexion()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PseudoTb_TextChanged(object sender, EventArgs e)
        {

        }

        public static int UserId;
        public static string UserName;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(PseudoTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter All The informations!!!");
            }else if(PseudoTb.Text == "Admin" || PasswordTb.Text == "Admin")
            {
                Articles Obj = new Articles();
                Obj.Show();
                this.Hide();
            }
            else
            {
                string Req = "select * from SellerTbl where SellerPseudo = '{0}' and SellerPass = '{1}'";
                Req = string.Format(Req, PseudoTb.Text, PasswordTb.Text);
                DataTable dt = Con.RecupererDonnees(Req);
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Seller Not Found");
                }
                else
                {
                    UserName = dt.Rows[0][2].ToString();
                    UserId = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Bills Obj = new Bills();
                    Obj.Show();
                    this.Hide();
                }
            }
        }

        private void Connexion_Load(object sender, EventArgs e)
        {

        }

        private void dhowPassCb_CheckedChanged(object sender, EventArgs e)
        {
            if(dhowPassCb.Checked == true)
            {
                PasswordTb.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTb.UseSystemPasswordChar = true;
            }
        }
    }
}
