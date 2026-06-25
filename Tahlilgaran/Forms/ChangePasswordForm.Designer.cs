namespace Tahlilgaran.Forms
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbRePass = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbName
            // 
            this.txbName.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbName.Location = new System.Drawing.Point(57, 59);
            this.txbName.Name = "txbName";
            this.txbName.PlaceholderText = "نام کاربری";
            this.txbName.Size = new System.Drawing.Size(378, 51);
            this.txbName.TabIndex = 0;
            this.txbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbPassword.Location = new System.Drawing.Point(57, 168);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.PlaceholderText = "رمزعبور";
            this.txbPassword.Size = new System.Drawing.Size(378, 51);
            this.txbPassword.TabIndex = 1;
            this.txbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbRePass
            // 
            this.txbRePass.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbRePass.Location = new System.Drawing.Point(57, 278);
            this.txbRePass.Name = "txbRePass";
            this.txbRePass.PasswordChar = '*';
            this.txbRePass.PlaceholderText = "تکرار رمزعبور";
            this.txbRePass.Size = new System.Drawing.Size(378, 51);
            this.txbRePass.TabIndex = 2;
            this.txbRePass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirm.Location = new System.Drawing.Point(57, 407);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(378, 105);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "ثبت";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(485, 572);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txbRePass);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbName);
            this.Name = "ChangePasswordForm";
            this.Text = "ChangePasswordForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChangePasswordForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbName;
        private TextBox txbPassword;
        private TextBox txbRePass;
        private Button btnConfirm;
    }
}