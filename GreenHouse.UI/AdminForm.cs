using GreenHouse.Core;
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
    public partial class AdminForm : Form
    {
        User _user;
        
        public AdminForm()
        {
            InitializeComponent();
        }
        public AdminForm(User user):base()
        {
            _user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminProductVerification adminProductVerification = new AdminProductVerification(_user);
            adminProductVerification.Show();
        }
    }
}
