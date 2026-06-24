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
    public partial class MainForm : Form
    {
        private Form _parent;
        public MainForm(Form parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void pcbInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm(this);
            inventoryForm.Show();
            this.Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Close();
        }
    }
}
