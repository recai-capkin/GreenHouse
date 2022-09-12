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
    public partial class FormIncludeContentProduct : Form
    {
        public FormIncludeContentProduct()
        {
            InitializeComponent();
        }

        private void FormIncludeContentProduct_Load(object sender, EventArgs e)
        {
            ProductDal product = new ProductDal();
            foreach (var item in product.GetProductContent())
            {
                comboBox1.Items.Add(item);  
            }
            dataGridView2.DataSource = product.GetAllProductIsVerificationAndMonth();
            GetUserProductCount();
            GetMostFavoritesProduct();
            GetMostProductAddedUserCount();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDal product = new ProductDal();
            dataGridView1.DataSource = product.IsIncludeContentProduct(comboBox1.Text);
        }


        void GetUserProductCount()
        {
            ProductDal product = new ProductDal();
            var data = product.GetUserAddedProduct();
            var data2 = product.GetUserAddedProductList();


            dataGridView3.DataSource = data;
        }

        void GetMostFavoritesProduct()
        {
            ProductDal product = new ProductDal();
            var data = product.MostFavoriteProduct();
            dataGridView4.DataSource = data;
        }
        void GetMostProductAddedUserCount()
        {
            ProductDal product = new ProductDal();
            var data = product.ProductAddUserCounts();
            dataGridView5.DataSource = data;
        }
    }
}
