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
    public partial class FormAllergenList : Form
    {
        User _user;
        public FormAllergenList()
        {
            InitializeComponent();
        }
        public FormAllergenList(User user):base()
        {
            InitializeComponent();
            _user = user;
        }

        private void FormAllergenList_Load(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.GetUserAllergen(_user.UserId))
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
