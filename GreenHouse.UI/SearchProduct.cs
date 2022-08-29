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

            MainForm mainForm = new MainForm(_user);
            mainForm.ShowDialog();
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ProductGetAllWithDetailFilterByName
            listBox1.Items.Clear();
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.ProductGetAllWithDetailFilterByName(textBox1.Text))
            {
                listBox1.Items.Add(item);
            }
            SearchHistory searchHistory = new SearchHistory()
            {
                SearchDate = DateTime.Now,
                SearchText = textBox1.Text,
                UserId = _user.UserId
            };
            productDal.AddSearchHistory(searchHistory);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.ProductGetAllWithDetailFilterByBarkod(textBox2.Text))
            {
                listBox1.Items.Add(item);
            }
            SearchHistory searchHistory = new SearchHistory()
            {
                SearchDate = DateTime.Now,
                SearchText = textBox1.Text,
                UserId = _user.UserId
            };
            productDal.AddSearchHistory(searchHistory);
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //select the item under the mouse pointer
                listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);

                string _selectedMenuItem = listBox1.Items[listBox1.SelectedIndex].ToString();
                MessageBox.Show(_selectedMenuItem.ToString());
            }
        }

        private void btnUserDetail_Click(object sender, EventArgs e)
        {
            UserDetail userDetail = new UserDetail(_user);
            userDetail.Show();
            this.Hide();
        }
    }
}
