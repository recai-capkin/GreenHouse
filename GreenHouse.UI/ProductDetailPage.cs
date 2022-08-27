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
        }
    }
}
