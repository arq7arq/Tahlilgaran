using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tahlilgaran.Forms
{
    public partial class OrderDetail : Form
    {
        private Form _parent;
        public OrderDetail(Form parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void SetProblems(string problems)
        {
            txbProblems.Text = problems;
        }

        private void OrderDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }
    }
}
