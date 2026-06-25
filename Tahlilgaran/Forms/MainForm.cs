using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tahlilgaran.Models;

namespace Tahlilgaran.Forms
{
    public partial class MainForm : Form
    {
        private Admin _admin;
        private Form _parent;
        public MainForm(Form parent, Admin admin)
        {
            InitializeComponent();
            _parent = parent;
            _admin = admin;
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

        private void pcbWorkshop_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(this);
            orderForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(this);
            changePasswordForm.SetAdmin(_admin);
            changePasswordForm.Show();
            this.Hide();
        }
    }
}
