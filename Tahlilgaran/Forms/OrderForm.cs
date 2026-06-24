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
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }
    }
}
