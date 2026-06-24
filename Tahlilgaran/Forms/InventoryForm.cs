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

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddInventoryForm addInventoryForm = new AddInventoryForm(this);
            addInventoryForm.Show();
            this.Hide();
        }


        public void UpdateData()
        {
            using var db = new AppDBContext();

            var res = db.Inventories.ToList();

            dataGridView1.DataSource = res;
            dataGridView1.Columns["InventoryID"].HeaderText = "کد کالا";
            dataGridView1.Columns["Title"].HeaderText = "عنوان";
            dataGridView1.Columns["Count"].HeaderText = "تعداد";
            dataGridView1.Columns["Price"].HeaderText = "قیمت";
            dataGridView1.Columns["Description"].HeaderText = "توضیحات";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["InventoryID"].Value);

            using var db = new AppDBContext();

            var res = db.Inventories.FirstOrDefault(x => x.InventoryID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            AddInventoryForm editInventoryForm = new AddInventoryForm(this);
            editInventoryForm.Text = "انبار/ویرایش";
            editInventoryForm.editMode = true;
            editInventoryForm.SetUpdateValue(res);
            editInventoryForm.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["InventoryID"].Value);

            using var db = new AppDBContext();

            try
            {
                var res = db.Inventories.FirstOrDefault(x => x.InventoryID == id);
                db.Remove(res);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("خطا در حذف اطلاعات");
            }
            finally
            {
                MessageBox.Show("کالا با موفقیت حذف شد");
            }
            UpdateData();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["InventoryID"].Value);

            using var db = new AppDBContext();

            var res = db.Inventories.FirstOrDefault(x => x.InventoryID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            if (res.Count <= 0)
            {
                MessageBox.Show("کالا موجود نیست");
            }
            else
            {
                try
                {
                    res.Count -= 1;
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
                    MessageBox.Show("فروش ثبت شد");
                    UpdateData();
                }
            }
        }
    }
}
