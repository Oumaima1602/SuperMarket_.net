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
    public partial class Articles : Form
    {
        Functions Con;
        public Articles()
        {
            InitializeComponent();
            Con = new Functions();
            
            FillCategories();ListerArticles();
        }

        private void ListerArticles()
        {
            string Req = "Select * from ArticlesTbl";
            ArticleList.DataSource = Con.RecupererDonnees(Req);
        }

        private void Filtering()
        {
            string Req = "Select * from ArticlesTbl where ArtCat = {0}";
            int Cat = Convert.ToInt32(FilterCb.SelectedValue.ToString());
            Req = string.Format(Req, Cat);
            ArticleList.DataSource = Con.RecupererDonnees(Req);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListerArticles();
        }

        private void FillCategories()
        {
            string Req = "SELECT * FROM CategorieTbl";
            CategCB.DisplayMember = Con.RecupererDonnees(Req).Columns["CatName"].ToString();
            CategCB.ValueMember = Con.RecupererDonnees(Req).Columns["CatCode"].ToString();
            CategCB.DataSource = Con.RecupererDonnees(Req);
            FilterCb.DisplayMember = Con.RecupererDonnees(Req).Columns["CatName"].ToString();
            FilterCb.ValueMember = Con.RecupererDonnees(Req).Columns["CatCode"].ToString();
            FilterCb.DataSource = Con.RecupererDonnees(Req);
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTb.Text == "" || PriceTb.Text == "" || CategCB.SelectedIndex == -1 || StockTb.Text == "")
                {
                    MessageBox.Show("PLZ! Complete The Form!!");
                }
                else
                {
                    //DateTime selectedDate = ExpDatePD.Value.Date.SelectedDate; // Récupérer la valeur sélectionnée dans le DatePicker
                    //string formattedDate = selectedDate.ToString("yyyy-MM-dd HH:mm:ss"); // Formater la date dans le format approprié
                    string Name = NameTb.Text;
                    int Price = Convert.ToInt32(PriceTb.Text);
                    int Category = Convert.ToInt32(CategCB.SelectedValue.ToString());
                    int Stock = Convert.ToInt32(StockTb.Text);


                    string ExpDate = ExpDatePD.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    string Req = "INSERT INTO ArticlesTbl values('{0}',{1},{2},{3},'{4}')";
                    Req = string.Format(Req, Name, Price, Category, Stock, ExpDate);
                    Con.EnvoyerDonnees(Req);
                    ListerArticles();
                    MessageBox.Show("Article added!!");
                    NameTb.Text = "";
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    CategCB.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int Key = 0;
        private void ArticleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = ArticleList.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = ArticleList.SelectedRows[0].Cells[2].Value.ToString();
            CategCB.Text = ArticleList.SelectedRows[0].Cells[3].Value.ToString();
            StockTb.Text = ArticleList.SelectedRows[0].Cells[4].Value.ToString();
            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ArticleList.SelectedRows[0].Cells[0].Value.ToString());

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
                    string Price = PriceTb.Text;
                    int Category = Convert.ToInt32(CategCB.SelectedValue.ToString());
                    int Stock = Convert.ToInt32(StockTb.Text);
                    string ExpDate = ExpDatePD.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    string Req = "DELETE from ArticlesTbl where ArtCode = {0}";
                    Req = string.Format(Req, Key);
                    Con.EnvoyerDonnees(Req);
                    ListerArticles();
                    MessageBox.Show("Article deleted!!");
                    NameTb.Text = "";
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    CategCB.SelectedIndex = -1;
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
                if (NameTb.Text == "" || PriceTb.Text == "" || CategCB.SelectedIndex == -1 || StockTb.Text == "")
                {
                    MessageBox.Show("PLZ! Complete The Form!!");
                }
                else
                {
                    string Name = NameTb.Text;
                    string Price = PriceTb.Text;
                    int Category = Convert.ToInt32(CategCB.SelectedValue.ToString());
                    int Stock = Convert.ToInt32(StockTb.Text);
                    string ExpDate = ExpDatePD.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    string Req = "UPDATE ArticlesTbl set ArtName = '{0}', ArtPrice = {1}, ArtCat = {2}, ArtStock = {3}, ArtExpDate = '{4}' where ArtCode = {5}";
                    Req = string.Format(Req, Name, Price, Category, Stock, ExpDate, Key);
                    Con.EnvoyerDonnees(Req);
                    ListerArticles();
                    MessageBox.Show("Article updated!!");
                    NameTb.Text = "";
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    CategCB.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtering();
        }

        private void Articles_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Connexion Obj = new Connexion();
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
