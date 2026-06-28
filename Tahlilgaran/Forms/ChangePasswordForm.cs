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
using Tahlilgaran.Utility;

namespace Tahlilgaran.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private Form _parent;
        private Admin _admin;
        public ChangePasswordForm(Form parent)
        {
            InitializeComponent();
           _parent = parent;
        }

        public void SetAdmin(Admin admin)
        {
            _admin = admin;
            txbName.Text = admin.Username;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string username = txbName.Text;
            string password = txbPassword.Text;
            string repass = txbRePass.Text;

            if (password.Length == 0)
            {
                MessageBox.Show("رمز عبور را وارد کنید");
                return;
            }

            if (password != repass)
            {
                MessageBox.Show("رمزعبور و تکرار آن یکسان نیست");
                return;
            }

            _admin.Username = username;
            _admin.Password = PasswordHasher.HashPassword(password);

            using var db = new AppDBContext();

            try
            {
                db.Update(_admin);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("خطا در ثبت اطلاعات");
            }
            finally
            {
                MessageBox.Show("اطلاعات شما با موفقیت ثبت شد");
                _parent.Show();
                this.Close();
            }
        }

        private void ChangePasswordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }
    }
}
