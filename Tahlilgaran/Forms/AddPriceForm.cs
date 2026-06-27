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
    public partial class AddPriceForm : Form
    {
        private OrderForm _parent;
        private int _orderID;
        public AddPriceForm(OrderForm orderForm)
        {
            InitializeComponent();
            _parent = orderForm;
            Setup();
        }

        public void SetOrderID(int orderID)
        {
            _orderID = orderID; 
        }

        private void Setup()
        {
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "عنوان"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "هزینه",
                ValueType = typeof(decimal)
            });


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Price")
            {
                string value = e.FormattedValue.ToString();

                if (!decimal.TryParse(value, out _) && value != "")
                {
                    MessageBox.Show("هزینه باید به صورت عدد باشد");
                    e.Cancel = true;
                }
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object value = row.Cells["Price"].Value;

                if (value != null && decimal.TryParse(value.ToString(), out decimal price))
                {
                    total += price;
                }
            }

            lblPrice.Text = $"{total} تومان";
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotal();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotal();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<OrderPrice> orderPrices = new List<OrderPrice>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                OrderPrice orderPrice = new OrderPrice()
                {
                    OrderID = _orderID,
                    Price = Convert.ToDecimal(row.Cells["Price"].Value),
                    Title = row.Cells["Name"].Value.ToString()
                };

                orderPrices.Add(orderPrice);
            }

            using var db = new AppDBContext();

            decimal total = 0;

            try
            {
                db.AddRange(orderPrices);
                total = orderPrices.Sum(x => x.Price);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
            finally
            {
                MessageBox.Show("اطلاعات با موفقیت ثبت شد");
                _parent.FinishDone(_orderID, total);
                _parent.Update();
                this.Close();
            }
        }
    }
}
