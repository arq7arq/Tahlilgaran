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
    public partial class OrderForm : Form
    {
        private Form _parent;
        public OrderForm(Form parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateData()
        {
            using var db = new AppDBContext();

            var res = db.Orders.ToList();

            dataGridView1.DataSource = res.Select(x => new
            {
                x.OrderID,
                x.Device,
                x.UserName,
                x.Phone,
                x.Problems,
                x.StartTime,
                x.FinishTime
            }).ToList();

            dataGridView1.Columns["OrderID"].HeaderText = "کد تحویل";
            dataGridView1.Columns["Device"].HeaderText = "دستگاه";
            dataGridView1.Columns["UserName"].HeaderText = "نام";
            dataGridView1.Columns["Phone"].HeaderText = "شماره تماس";
            dataGridView1.Columns["Problems"].HeaderText = "مشکلات";
            dataGridView1.Columns["StartTime"].HeaderText = "زمان دریافت";
            dataGridView1.Columns["FinishTime"].HeaderText = "زمان تحویل";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id = Convert.ToInt32(row.Cells["OrderID"].Value);

                Order order = res.FirstOrDefault(x => x.OrderID == id);

                if (order.IsComplete)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (order.IsDone)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }

            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm(this);
            addOrderForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            AddOrderForm editOrderForm = new AddOrderForm(this);
            editOrderForm.Text = "تعمیرات/ویرایش";
            editOrderForm.editMode = true;
            editOrderForm.SetUpdateValue(res);
            editOrderForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            try
            {
                var res = db.Orders.FirstOrDefault(x => x.OrderID == id);
                db.Remove(res);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("خطا در حذف اطلاعات");
            }
            finally
            {
                MessageBox.Show("تعمیر با موفقیت حذف شد");
            }
            UpdateData();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }


            try
            {
                res.IsDone = true;
                db.Update(res);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
            finally
            {
                // TODO Log this on sales 
                MessageBox.Show("دستگاه اماده است");
                UpdateData();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            if (!res.IsDone)
            {
                MessageBox.Show("دستگاه هنوز اماده تحویل نیست");
            }
            else
            {
                try
                {
                    res.IsComplete = true;
                    res.FinishTime = DateTime.Now;
                    db.Update(res);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("خطا در ثبت اطلاعات");
                }
                finally
                {
                    MessageBox.Show("دستگاه به مشتری تحویل داده شد");
                    UpdateData();
                }
            }
            
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txbSearch.Text;

            using var db = new AppDBContext();

            var res = db.Orders.Where(x => x.UserName.Contains(search) || x.Phone.Contains(search) || x.Device.Contains(search)).ToList();

            dataGridView1.DataSource = res.Select(x => new
            {
                x.OrderID,
                x.Device,
                x.UserName,
                x.Phone,
                x.Problems,
                x.StartTime,
                x.FinishTime
            }).ToList();

            dataGridView1.Columns["OrderID"].HeaderText = "کد تحویل";
            dataGridView1.Columns["Device"].HeaderText = "دستگاه";
            dataGridView1.Columns["UserName"].HeaderText = "نام";
            dataGridView1.Columns["Phone"].HeaderText = "شماره تماس";
            dataGridView1.Columns["Problems"].HeaderText = "مشکلات";
            dataGridView1.Columns["StartTime"].HeaderText = "زمان دریافت";
            dataGridView1.Columns["FinishTime"].HeaderText = "زمان تحویل";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id = Convert.ToInt32(row.Cells["OrderID"].Value);

                Order order = res.FirstOrDefault(x => x.OrderID == id);

                if (order.IsComplete)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (order.IsDone)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            OrderDetail orderDetail = new OrderDetail(this);
            orderDetail.SetProblems(res.Problems);
            orderDetail.Show();
            this.Hide();
        }
    }
}
