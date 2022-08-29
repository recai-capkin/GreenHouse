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
    public partial class ChangePassword : Form
    {
        User _user;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public ChangePassword(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDal userDal = new UserDal();
            userDal.UserUpdatePassword(_user.UserId,textBox1.Text);
            MessageBox.Show("Başarılı");
            this.Hide();
        }
    }
}
