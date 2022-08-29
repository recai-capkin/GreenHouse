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
    public partial class ForumAllergenAdd : Form
    {
        User _user;
        public ForumAllergenAdd()
        {
            InitializeComponent();
        }
        public ForumAllergenAdd(User user):base()
        {
            _user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            productDal.UserAllergenAdd(_user.UserId,comboBox1.Text);
        }

        private void ForumAllergenAdd_Load(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.GetProductContent())
            {
                comboBox1.Items.Add(item);
            }
        }
    }
}
