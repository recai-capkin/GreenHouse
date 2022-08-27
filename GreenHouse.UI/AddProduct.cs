using GreenHouse.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHouse.UI
{
    public partial class AddProduct : Form
    {
        User _user;
        public string ProductContentPicture;
        public string ProductFrontPicture;
        public string ProductBehindPicture;
        public AddProduct()
        {
            InitializeComponent();
        }
        public AddProduct(User user):base()
        {
            InitializeComponent();
            _user = user;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void btnSideMenu_Click(object sender, EventArgs e)
        {
            Navbar navbar = new Navbar();
            navbar.ShowDialog();
        }

        private void btnUserDetail_Click(object sender, EventArgs e)
        {
            UserDetail userDetail = new UserDetail();
            userDetail.Show();
            this.Hide();
        }

        private void btnAddProductImageContent_Click(object sender, EventArgs e)
        {
            string path = "E:\\Resimler\\";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string pictureName = Guid.NewGuid().ToString();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(openFileDialog.FileName, path + pictureName+".jpg");
                ProductContentPicture = path + pictureName+".jpg";
            }
            
        }
    }
}
