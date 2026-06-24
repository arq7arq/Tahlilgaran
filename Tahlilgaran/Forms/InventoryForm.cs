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
    public partial class InventoryForm : Form
    {
        private Form _parent;
        public InventoryForm(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            
        }

        private void InventoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }


    }
}
