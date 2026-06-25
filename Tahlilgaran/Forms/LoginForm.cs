using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                var Main = new MainForm(this, res);
                Main.Show();
                this.Hide();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/arq7arq";

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
