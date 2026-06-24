using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tahlilgaran.Data;
using Tahlilgaran.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tahlilgaran.Forms
{
    public partial class AddOrderForm : Form
    {
        private OrderForm _parent;
        public bool editMode = false;
        private int _orderID;
        public AddOrderForm(OrderForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void AddOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
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

        public void SetUpdateValue(Order order)
        {
            txbName.Text = order.UserName;
            txbDevice.Text = order.Device;
            txbPhone.Text = order.Phone;
            txbProblems.Text = order.Problems;
            _orderID = order.OrderID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                using var db = new AppDBContext();

                string username = txbName.Text;
                string device = txbDevice.Text;
                string phone = txbPhone.Text;
                string problems = txbProblems.Text;

                Order order = db.Orders.SingleOrDefault(x => x.OrderID == _orderID);

                if (order == null)
                {
                    MessageBox.Show("خطا در ثبت اطلاعات");
                }

                order.Problems = problems;
                order.Phone = phone;
                order.Device = device;
                order.UserName = username;

                try
                {
                    db.Update(order);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("خطا در ثبت اطلاعات");
                }
                finally
                {
                    MessageBox.Show("تعمیر با موفقیت ثبت شد");
                    _parent.Show();
                    _parent.UpdateData();
                    this.Close();
                }
            }
            else
            {
                using var db = new AppDBContext();

                string username = txbName.Text;
                string device = txbDevice.Text;
                string phone = txbPhone.Text;
                string problems = txbProblems.Text;

                Order order = new Order()
                {
                    Problems = problems,
                    Phone = phone,
                    Device = device,
                    UserName = username,
                    FinishTime = DateTime.Now,
                    IsComplete = false,
                    IsDone = false,
                    StartTime = DateTime.Now
                };

                try
                {
                    db.Add(order);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("خطا در ثبت اطلاعات");
                }
                finally
                {
                    MessageBox.Show("تعمیر با موفقیت ثبت شد");
                    _parent.Show();
                    _parent.UpdateData();
                    this.Close();
                }
            }
        }
    }
}
