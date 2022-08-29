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

namespace GreenHouse.UI
{
    public partial class Islem : Form
    {
        Product _product;
        User _user;
        public Islem()
        {
            InitializeComponent();
        }
        public Islem(Product product, User user):base()
        {
            _product = product;
            _user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDal product = new ProductDal();
            product.AddFavoriteList(comboBox1.Text,_product.ProductId,_user.UserId);
        }

        private void Islem_Load(object sender, EventArgs e)
        {
            ProductDal productdal = new ProductDal();
            foreach (var item in productdal.GetFavoriteProductLists(_user.UserId))
            {
                comboBox1.Items.Add(item);
            }
        }
    }
}
