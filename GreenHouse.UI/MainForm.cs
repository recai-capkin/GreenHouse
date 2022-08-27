using GreenHouse.Core;
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
    public partial class MainForm : Form
    {
        User _user;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(User user):base()
        {
            _user = user;
        }

        private void btnAddProductOrUpdate_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Hide();
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            SearchProduct searchProduct = new SearchProduct();
            searchProduct.Show();
            this.Hide();
        }

        private void btnUserDetail_Click(object sender, EventArgs e)
        {
            UserDetail userDetail = new UserDetail();
            userDetail.Show();
            this.Hide();
        }

        private void btnSideMenu_Click(object sender, EventArgs e)
        {
            Navbar navbar = new Navbar();
            navbar.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
