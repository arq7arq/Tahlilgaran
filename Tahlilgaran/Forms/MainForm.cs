using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tahlilgaran.Data;
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

        private void ShowReminder()
        {
            using var db = new AppDBContext();

            var res = db.Orders.Where(x => x.Reminder && x.FinishTime != null);

            string list = "";

            string now = DateTime.Now.ToString("yy/MM/dd");

            foreach (var item in res)
            {
                DateTime date = item.FinishTime.Value;
                string date2 = date.AddMonths(6).ToString("yy/MM/dd");

                if (date2.Equals(now))
                {
                    list += $"زمان سرویس {item.UserName} فرا رسیده\n";
                }
            }

            if(list == String.Empty)
            {
                return;
            }

            MessageBox.Show(list);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm(this);
            userListForm.Show();
            this.Hide();
        }
    }
}
