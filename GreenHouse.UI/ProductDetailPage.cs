using GreenHouse.Core;
using GreenHouse.Dal.Concrete;
using GreenHouse.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouse.Dal
{
    public partial class ProductDetailPage : Form
    {
        Product _product;
        User _user;
        public ProductDetailPage()
        {
            InitializeComponent();
            
        }
        public ProductDetailPage(Product product,User user):base()
        {
            _product = product;
            _user = user;
            InitializeComponent();
            label17.Visible = false;    
        }

        private void ProductDetailPage_Load(object sender, EventArgs e)
        {
            label20.Text = _product.ProductCategory.CategoryName;
            label19.Text = _product.ProductBrand.BrandName;
            label18.Text = _product.ProductName;

            ProductDal productDal = new ProductDal();
            List<ProductContent> blackListContent = new List<ProductContent>();
            List<ProductContent> temizContent = new List<ProductContent>();
            List<ProductContent> ortaContent = new List<ProductContent>();
            List<ProductContent> riskliContent = new List<ProductContent>();
            List<ProductContent> azContent = new List<ProductContent>();
            int riskli = 0;
            int temiz = 0;
            int orta = 0;
            int az = 0;
            int blackList = 0;
            foreach (var item in productDal.ProductGetAllContent(_product.ProductId))
            {
                if (item.ContentThreadLevel == "Riskli")
                {
                    listBox1.Items.Add(item);
                    riskliContent.Add(item);
                }
                else if (item.ContentThreadLevel == "Temiz")
                {
                    listBox1.Items.Add(item);
                    temizContent.Add(item);
                }
                else if (item.ContentThreadLevel == "Orta Riskli")
                {
                    listBox1.Items.Add(item);
                    ortaContent.Add(item);
                }
                else if (item.ContentThreadLevel == "Az Riskli")
                {
                    listBox1.Items.Add(item);
                    azContent.Add(item);
                }   
            }
            UserDal userDal = new UserDal();
            var userallergen = userDal.GetUserAllergen(_user.UserId);
            foreach (var item in productDal.ProductGetAllContent(_product.ProductId))
            {
                if (userallergen.Any(x => x.AllergenContentName == item.ContentName))
                {
                    blackList++;
                    blackListContent.Add(item);
                }
            }

            label10.Text = blackListContent.Count.ToString();
            label11.Text = riskliContent.Count.ToString();
            label12.Text = ortaContent.Count.ToString();
            label13.Text = azContent.Count.ToString();
            label14.Text = temizContent.Count.ToString();
            label23.Text = userDal.GetUserName(_product.UserId); 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductContent data = (ProductContent)listBox1.SelectedItem;
            label21.Text = data.ContentName;
            textBox1.Text = data.ContentDescription;
            UserDal userDal = new UserDal();
            var userallergen = userDal.GetUserAllergen(_user.UserId);
            foreach (var item in userallergen)
            {
                if (item.AllergenContentName == data.ContentName)
                {
                    label17.Visible = true;
                    break;
                }
                else
                {
                    label17.Visible = false;
                }
            }
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(_user);
            mainForm.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Islem islem = new Islem(_product,_user);
            islem.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            productDal.AddBlackList(_product.ProductId, _user.UserId);
            MessageBox.Show("Ürün karalisteye eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDetail userDetail = new UserDetail(_user);
            userDetail.Show();
            this.Hide();
        }
    }
}
