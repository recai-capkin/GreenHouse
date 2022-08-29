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
    public partial class FormSearchHistory : Form
    {
        User _user;
        public FormSearchHistory()
        {
            InitializeComponent();
        }
        public FormSearchHistory(User user):base()
        {
            InitializeComponent();
            _user = user;
        }

        private void FormSearchHistory_Load(object sender, EventArgs e)
        {
            UserDal userDal = new UserDal();
            foreach (var item in userDal.GetSearchHistories(_user.UserId))
            {
                listBox1.Items.Add(item.SearchText+ " - "+item.SearchDate);
            }
        }
    }
}
