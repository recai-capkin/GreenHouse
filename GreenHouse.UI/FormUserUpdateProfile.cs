using GreenHouse.Core;
using GreenHouse.Dal.Concrete;
using GreenHouse.Dto;
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
    public partial class FormUserUpdateProfile : Form
    {
        User _user;
        public FormUserUpdateProfile()
        {
            InitializeComponent();
        }
        public FormUserUpdateProfile(User user):base()
        {
            _user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDal userDal = new UserDal();
            if (userDal.UpdateUserProfile(new UserUpdateProfileDto() 
            { 
                UserId = _user.UserId,
                Name = textBox1.Text,
                Surname = textBox2.Text,
                Address = textBox3.Text,
                Phone = textBox4.Text
            }))
            {
               DialogResult dialogResult =  MessageBox.Show("Güncelleme başarılı","Bilgilendirme",MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void FormUserUpdateProfile_Load(object sender, EventArgs e)
        {
            textBox1.Text = _user.Name;
            textBox2.Text = _user.Surname;
            textBox3.Text = _user.Adress;
            textBox4.Text = _user.Phone;
        }
    }
}
