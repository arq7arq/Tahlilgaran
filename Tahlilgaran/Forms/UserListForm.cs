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
    public partial class UserListForm : Form
    {
        private Form _parent;
        public UserListForm(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            LoadData();
        }

        private void LoadData()
        {
            using var db = new AppDBContext();

            var res = db.Orders.Select(x => new { x.UserName, x.Phone }).ToHashSet().ToList();

            dataGridView1.DataSource = res;

            dataGridView1.Columns["UserName"].HeaderText = "نام";
            dataGridView1.Columns["Phone"].HeaderText = "شماره تماس";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using var db = new AppDBContext();

            var search = txbSearch.Text;

            var res = db.Orders.Select(x => new { x.UserName, x.Phone }).Where(x => x.UserName.Contains(search) || x.Phone.Contains(search)).ToHashSet().ToList();

            dataGridView1.DataSource = res;

            dataGridView1.Columns["UserName"].HeaderText = "نام";
            dataGridView1.Columns["Phone"].HeaderText = "شماره تماس";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UserListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Show();
        }
    }
}
