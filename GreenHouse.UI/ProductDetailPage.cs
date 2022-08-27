using GreenHouse.Core;
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
        }

        private void ProductDetailPage_Load(object sender, EventArgs e)
        {
            label20.Text = _product.ProductCategory.CategoryName;
            label19.Text = _product.ProductBrand.BrandName;
            label18.Text = _product.ProductName;

            ProductDal productDal = new ProductDal();
            int 
            foreach (var item in productDal.ProductGetAllContent(_product.ProductId))
            {
                listBox1.Items.Add(item.ContentName);
            }
            label10.Text = "";
        }
    }
}
