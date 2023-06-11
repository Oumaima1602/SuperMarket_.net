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
    public partial class Categories : Form
    {
        Functions Con;
        public Categories()
        {
            InitializeComponent();
            Con = new Functions();
            ListerCategories();
        }

        private void ListerCategories()
        {
            string Req = "Select * from CategorieTbl";
            CategorieList.DataSource = Con.RecupererDonnees(Req);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTb.Text == "" || DescTb.Text == "")
                {
                    MessageBox.Show("PLZ! Complete The Form!!");
                }
                else
                {
                    string Name = NameTb.Text;
                    string Desc = DescTb.Text;
                    string Req = "UPDATE CategorieTbl set CatName = '{0}', CatDesc = '{1}' where CatCode = {2}";
                    Req = string.Format(Req, Name, Desc, Key);
                    Con.EnvoyerDonnees(Req);
                    ListerCategories();
                    MessageBox.Show("Category updated!!");
                    NameTb.Text = "";
                    DescTb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(NameTb.Text == "" || DescTb.Text == "")
                {
                    MessageBox.Show("PLZ! Complete The Form!!");
                }
                else
                {
                    string Name = NameTb.Text;
                    string Desc = DescTb.Text;
                    string Req = "INSERT INTO CategorieTbl values('{0}','{1}')";
                    Req = string.Format(Req, Name, Desc);
                    Con.EnvoyerDonnees(Req);
                    ListerCategories() ;
                    MessageBox.Show("Category added!!");
                    NameTb.Text = "";
                    DescTb.Text = "";
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int Key = 0;
        private void CategorieList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = CategorieList.SelectedRows[0].Cells[1].Value.ToString();
            DescTb.Text = CategorieList.SelectedRows[0].Cells[2].Value.ToString();
            if(NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategorieList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
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
                    string Desc = DescTb.Text;
                    string Req = "DELETE from CategorieTbl where CatCode = {0}";
                    Req = string.Format(Req, Key);
                    Con.EnvoyerDonnees(Req);
                    ListerCategories();
                    MessageBox.Show("Category deleted!!");
                    NameTb.Text = "";
                    DescTb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Connexion Obj = new Connexion();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }
    }
}
