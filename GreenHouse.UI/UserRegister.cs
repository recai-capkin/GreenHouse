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
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRegisterDto dto = new UserRegisterDto()
            {
                Ad = textBox1.Text,
                Soyad = textBox2.Text,
                KullaniciAdi = textBox3.Text,
                Sifre = textBox4.Text,
                Adres = textBox5.Text,
                Telefon = textBox6.Text,
                Rol = comboBox1.Text,
                Email = textBox7.Text,
            };
            UserDal userDal = new UserDal();
            userDal.UserRegister(dto);
            MessageBox.Show("Kayıt başarılı");
            this.Hide();
        }
    }
}
