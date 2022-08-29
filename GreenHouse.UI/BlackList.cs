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
    public partial class BlackList : Form
    {
        User _user;
        public BlackList()
        {
            InitializeComponent();
        }
        public BlackList(User user):base()
        {
            InitializeComponent();
            _user = user;
        }

        private void BlackList_Load(object sender, EventArgs e)
        {
            ProductDal productdal = new ProductDal();
            foreach (var item in productdal.GetBlackList(_user.UserId))
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
