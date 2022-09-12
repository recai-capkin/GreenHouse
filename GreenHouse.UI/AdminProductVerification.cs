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
    public partial class AdminProductVerification : Form
    {
        User _user;
        Product selectedProduct;
        public AdminProductVerification()
        {
            InitializeComponent();
        }
        public AdminProductVerification(User user):base()
        {
            _user = user;
            InitializeComponent();
        }

        private void AdminProductVerification_Load(object sender, EventArgs e)
        {
            ListboxFillProduct();
        }

        void ListboxFillProduct()
        {
            listBox1.Items.Clear();
            ProductDal productDal = new ProductDal();
            foreach (var item in productDal.GetUnvouchedProductList())
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //select the item under the mouse pointer
                listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
                
                

                
                if (listBox1.SelectedIndex != -1)
                {
                    selectedProduct = (Product)listBox1.Items[listBox1.SelectedIndex];
                    contextMenuStrip1.Show(this, new Point(e.X, e.Y));
                }
                
            }
        }

        private void onaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedProduct.UserAdminId = _user.UserId;
            selectedProduct.AdminVerificationDate = DateTime.Now;
            ProductDal productDal=new ProductDal();
            if (productDal.VerificationProduct(selectedProduct))
            {
                MessageBox.Show("Ekleme Başarılı.");
                ListboxFillProduct();
            }
            else
            {
                MessageBox.Show("Ekleme Başarısız.");
            }
        }
    }
}
