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
    public partial class Favorites : Form
    {
        User _user;
        public Favorites()
        {
            InitializeComponent();
        }
        public Favorites(User user):base()
        {
            InitializeComponent();
            _user = user;
        }

        private void Favorites_Load(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.GetFavoriteProductLists(_user.UserId))
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.GetFavoriteProducts(_user.UserId, comboBox1.Text))
            {
                listBox1.Items.Add(item.ProductName);
            }
            
        }
    }
}
