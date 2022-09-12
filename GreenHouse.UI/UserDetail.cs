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
    public partial class UserDetail : Form
    {
        User _user;

        public UserDetail()
        {
            InitializeComponent();
        }
        public UserDetail(User user):base()
        {
            _user = user;
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(_user);
            mainForm.ShowDialog();
            this.Hide();
        }

        private void btnSideMenu_Click(object sender, EventArgs e)
        {
            Navbar navbar = new Navbar();
            navbar.ShowDialog();
        }

        private void btnUserDetail_Click(object sender, EventArgs e)
        {
            
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();
            if (_user.UserRole.UserRoleName != "PremiumUser")
            {
                button2.Visible = true;
            }
            else
            {
                button2.Visible=false;
            }
            label1.Text = _user.Name + " " + _user.Surname;
            label3.Text = _user.UserAddDate.ToString();
            label4.Text = productDal.UserProductAddCount(_user.UserId).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeEmail changeEmail = new ChangeEmail(_user);
            changeEmail.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Favorites favorites = new Favorites(_user);
            favorites.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BlackList blackList = new BlackList(_user);
            blackList.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(_user);
            changePassword.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormAllergenList allergenList = new FormAllergenList(_user);
            allergenList.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ForumAllergenAdd forumAllergenAdd = new ForumAllergenAdd(_user);    
            forumAllergenAdd.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormUserUpdateProfile formUserUpdateProfile = new FormUserUpdateProfile(_user);
            formUserUpdateProfile.Show();
        }
    }
}
