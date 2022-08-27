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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserDal userDal = new UserDal();
            User kullanici = userDal.Login(textBox1.Text,textBox2.Text);
            if (kullanici == null)
            {
                MessageBox.Show("Böyle bir kullanıcı yok");
            }
            else if (kullanici.UserRole.UserRoleName.ToLower() == "standartuser" || kullanici.UserRole.UserRoleName.ToLower() == "premiumuser")
            {
                MainForm mainForm = new MainForm(kullanici);
                mainForm.Show();
                this.Hide();
            }
            else if(kullanici.UserRole.UserRoleName.ToLower() == "admin")
            {
                MainForm mainForm = new MainForm(kullanici);
                mainForm.Show();
                this.Hide();
            }
            
        }
    }
}
