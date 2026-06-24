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
using Tahlilgaran.Utility;

namespace Tahlilgaran.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using var db = new AppDBContext();

            string username = txbUsername.Text;
            string password = txbPassword.Text;

            var res = db.Admins.FirstOrDefault(a => a.Username == username);

            if (res == null || !PasswordHasher.VerifyPassword(password, res.Password))
            {
                MessageBox.Show("نام کاربری یا رمزعبور استباه است.");
            }
            else
            {
                var Main = new MainForm();
                Main.Show();
                this.Hide();
            }

        }
    }
}
