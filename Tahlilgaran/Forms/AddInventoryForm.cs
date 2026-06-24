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
    public partial class AddInventoryForm : Form
    {
        private InventoryForm _parent;
        public AddInventoryForm(InventoryForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void AddInventoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void txbCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow only digits
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Allow only digits
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var db = new AppDBContext();

            string title = txbName.Text;
            int count = Convert.ToInt32(txbCount.Text);
            long price = Convert.ToInt64(txbPrice.Text);
            string description = txbDesc.Text;

            Inventory inventory = new Inventory()
            {
                Title = title,
                Description = description,
                Count = count,
                Price = price
            };

            try
            {
                db.Add(inventory);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
            finally
            {
                MessageBox.Show("کالا با موفقیت ثبت شد");
                _parent.Show();
                _parent.UpdateData();
                this.Close();
            }
        }
    }
}
