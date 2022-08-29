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
            InitializeComponent();
        }

        private void btnAddProductOrUpdate_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(_user);
            addProduct.Show();
            this.Hide();
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            SearchProduct searchProduct = new SearchProduct(_user);
            searchProduct.Show();
            this.Hide();
        }

        private void btnUserDetail_Click(object sender, EventArgs e)
        {
            UserDetail userDetail = new UserDetail(_user);
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

        private void button4_Click(object sender, EventArgs e)
        {
            FormSearchHistory searchHistory = new FormSearchHistory(_user);
            searchHistory.Show();
        }
    }
}
