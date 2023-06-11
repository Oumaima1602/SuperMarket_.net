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
    public partial class Bills : Form
    {
        Functions Con;
        public Bills()
        {
            InitializeComponent();
            Con = new Functions();
            ListerArticles();
            TotalPriceLbl.Text = Connexion.UserName;
        }

        private void ListerArticles()
        {
            string Req = "SELECT ArtCode as Code, ArtName AS Article, ArtPrice AS Price, CatName AS Categories, ArtStock AS Stock FROM ArticlesTbl JOIN CategorieTbl ON ArticlesTbl.ArtCat = CategorieTbl.CatCode";
            Bill.DataSource = Con.RecupererDonnees(Req);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Connexion Obj = new Connexion();
            Obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
        private void SellersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Bills_Load(object sender, EventArgs e)
        {

        }

        
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        int Key = 0;
        private void ArticlesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = Bill.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = Bill.SelectedRows[0].Cells[2].Value.ToString();
            //CategCB.Text = ArticleList.SelectedRows[0].Cells[3].Value.ToString();
            StockTb.Text = Bill.SelectedRows[0].Cells[4].Value.ToString();
            int Key;
            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(Bill.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            PriceTb.Text = "";
            StockTb.Text = "";
            QuantityTb.Text = "";
        }

        private void ModifierStock()
        {
            int stock = Convert.ToInt32(StockTb.Text);
            int newStock = stock - Convert.ToInt32(QuantityTb.Text);
            Console.WriteLine(newStock);
            
            string Req = "UPDATE ArticlesTbl set ArtStock = {0} where ArtCode = {1}";
            Key = Convert.ToInt32(Bill.SelectedRows[0].Cells[0].Value.ToString());
            Console.WriteLine(Key);
            Req = string.Format(Req, newStock, Key);
            Con.EnvoyerDonnees(Req);
            ListerArticles();
        }

        int n = 0;
        int GrdTotal = 0;
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(PriceTb.Text == "" || QuantityTb.Text == "" || StockTb.Text == "" || NameTb.Text == "")
            {
                MessageBox.Show("Missing info!!");
            }else
            {
                if(Convert.ToInt32(QuantityTb.Text) > Convert.ToInt32(StockTb.Text))
                {
                    MessageBox.Show("Insufficient Stock !!");
                }
                else
                {

                    int total = Convert.ToInt32(QuantityTb.Text) * Convert.ToInt32(PriceTb.Text);
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(BillList);
                    row.Cells[0].Value = n + 1;
                    row.Cells[1].Value = NameTb.Text;
                    row.Cells[2].Value = QuantityTb.Text;
                    row.Cells[3].Value = PriceTb.Text;
                    row.Cells[4].Value = total;
                    BillList.Rows.Add(row);
                    GrdTotal += total;
                    TotalPriceLbl.Text = GrdTotal + "$";
                    ModifierStock();
                    NameTb.Text = "";
                    PriceTb.Text = "";
                    StockTb.Text = "";
                    QuantityTb.Text = "";
                    n++;

                }
            }
        }

        private void SellerLbl_Click(object sender, EventArgs e)
        {

        }

        private void InsertBill()
        {
            int Seller = Connexion.UserId;
            Console.WriteLine(Seller);
            string Req = "INSERT INTO BillsTbl values('{0}', {1}, {2})";
            Req = string.Format(Req, DateTime.Today.Date.ToString("yyyy-MM-dd HH:mm:ss"), Seller, GrdTotal);
            Con.EnvoyerDonnees(Req);
            MessageBox.Show("Bill added!!");
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            InsertBill();
            printPreviewDialog1.ShowDialog();
        }


        int Code, Price, Qty, Total;
        string Name;

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

        int pos = 80;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("SuperMarket", new Font("Times New Roman",24), Brushes.Black, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Times New Roman", 22), Brushes.Black, new Point(26,40));
            foreach (DataGridViewRow row in BillList.Rows)
            {
                Code = Convert.ToInt32(row.Cells["Column1"].Value);
                Name = "" + row.Cells["Column2"].Value;
                Price = Convert.ToInt32(row.Cells["Column3"].Value);
                Qty = Convert.ToInt32(row.Cells["Column4"].Value);
                Total = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + Code, new Font("Times New Roman", 20), Brushes.Black, new Point(26, pos));
                e.Graphics.DrawString("" + Name, new Font("Times New Roman", 20), Brushes.Black, new Point(45, pos));
                e.Graphics.DrawString("" + Price, new Font("Times New Roman", 20), Brushes.Black, new Point(120, pos));
                e.Graphics.DrawString("" + Qty, new Font("Times New Roman", 20), Brushes.Black, new Point(170, pos));
                e.Graphics.DrawString("" + Total, new Font("Times New Roman", 20), Brushes.Black, new Point(235, pos));
                pos += 20;
            }
            e.Graphics.DrawString("Total" + GrdTotal + "$", new Font("Times New Roman", 18), Brushes.Black, new Point(50, pos+50));
            e.Graphics.DrawString("*********** SuperMarket ***********", new Font("Times New Roman", 18), Brushes.Black, new Point(10, pos+85));
            BillList.Rows.Clear();
            BillList.Refresh();
            pos = 100;
            GrdTotal = 0;
            n = 0;
            TotalPriceLbl.Text = "";
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
