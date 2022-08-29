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
    public partial class ChangeEmail : Form
    {
        User _user;
        public ChangeEmail()
        {
            InitializeComponent();
        }
        public ChangeEmail(User user):base()
        {
            _user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDal userdal = new UserDal();
            userdal.UserUpdateEmail(_user.UserId,textBox1.Text);
            MessageBox.Show("Başarılı");
            this.Hide();
        }
    }
}
