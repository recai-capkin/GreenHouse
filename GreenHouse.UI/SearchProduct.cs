using GreenHouse.Core;
using GreenHouse.Dal;
using GreenHouse.Dal.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouse.UI
{
    public partial class SearchProduct : Form
    {
        User _user;
        public SearchProduct()
        {
            InitializeComponent();
        }
        public SearchProduct(User user):base()
        {
            _user = user;
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSideMenu_Click(object sender, EventArgs e)
        {
            Navbar navbar = new Navbar();
            navbar.ShowDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void SearchProduct_Load(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.ProductGetAllWithDetail())
            {
                listBox1.Items.Add(item);
            }
            
        }
       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product data = (Product)listBox1.SelectedItem;
            ProductDetailPage productDetailPage = new ProductDetailPage(data, _user);
            productDetailPage.Show();
        }
    }
}
