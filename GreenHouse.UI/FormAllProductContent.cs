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
    public partial class FormAllProductContent : Form
    {
        public FormAllProductContent()
        {
            InitializeComponent();
        }


        private void FormAllProductContent_Load(object sender, EventArgs e)
        {
            ProductDal productDal = new ProductDal();


            dataGridView1.DataSource = productDal.GetSimpleProductWithContent();


            foreach (var item in productDal.GetSimpleProductWithContent())
            {
                listBox1.Items.Add(item.ProductName + " " + item.ContentCount);
            }

        }
       
    }
}
