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
    public partial class Sellers : Form
    {

        Functions Con;
        public Sellers()
        {
            InitializeComponent();
            Con = new Functions();
            ListerSellers();
        }

        private void ListerSellers()
        {
            string Req = "Select * from SellerTbl";
            SellersList.DataSource = Con.RecupererDonnees(Req);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTb.Text == "" || PseudoTb.Text == "" || PasswordTb.Text == ""||PhoneTb.Text == ""  || AddressTb.Text == "")
                {
                    MessageBox.Show("PLZ! Complete The Form!!");
                }
                else
                {
                   
                    string Name = NameTb.Text;
                    string Pseudo = PseudoTb.Text;
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Address = AddressTb.Text;


                    string Req = "INSERT INTO SellerTbl values('{0}','{1}','{2}','{3}','{4}')";
                    Req = string.Format(Req, Name, Pseudo, Password, Phone, Address);
                    Con.EnvoyerDonnees(Req);
                    ListerSellers();
                    MessageBox.Show("Seller added!!");
                    NameTb.Text = "";
                    PseudoTb.Text = "";
                    PasswordTb.Text = "";
                    PhoneTb.Text = "";
                    AddressTb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        int Key = 0;

        private void SellersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = SellersList.SelectedRows[0].Cells[1].Value.ToString();
            PseudoTb.Text = SellersList.SelectedRows[0].Cells[2].Value.ToString();
            PasswordTb.Text = SellersList.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = SellersList.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = SellersList.SelectedRows[0].Cells[5].Value.ToString();
            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SellersList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("PLZ! Select an item");
                }
                else
                {
                    string Name = NameTb.Text;
                    string Pseudo = PseudoTb.Text;
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Address = AddressTb.Text;
                    string Req = "DELETE from SellerTbl where SellerCode = {0}";
                    Req = string.Format(Req, Key);
                    Con.EnvoyerDonnees(Req);
                    ListerSellers();
                    MessageBox.Show("Seller deleted!!");
                    NameTb.Text = "";
                    PseudoTb.Text = "";
                    PasswordTb.Text = "";
                    PhoneTb.Text = "";
                    AddressTb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTb.Text == "" || PseudoTb.Text == "" || PasswordTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "")
                {
                    MessageBox.Show("PLZ! Complete The Form!!");
                }
                else
                {
                    string Name = NameTb.Text;
                    string Pseudo = PseudoTb.Text;
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Address = AddressTb.Text;
                    string Req = "UPDATE SellerTbl set SellerName = '{0}', SellerPseudo = '{1}', SellerPass = '{2}', SellerPhone = '{3}', SellerAdd = '{4}' where SellerCode = {5}";
                    Req = string.Format(Req, Name, Pseudo, Password, Phone, Address, Key);
                    Con.EnvoyerDonnees(Req);
                    ListerSellers();
                    MessageBox.Show("Seller updated!!");
                    NameTb.Text = "";
                    PseudoTb.Text = "";
                    PasswordTb.Text = "";
                    PhoneTb.Text = "";
                    AddressTb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Connexion Obj = new Connexion();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Articles Obj = new Articles();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Sellers Obj = new Sellers();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }
    }
}
