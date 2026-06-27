namespace Tahlilgaran.Forms
{
    partial class AddOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrderForm));
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.txbDevice = new System.Windows.Forms.TextBox();
            this.txbProblems = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbName
            // 
            this.txbName.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbName.Location = new System.Drawing.Point(516, 34);
            this.txbName.Name = "txbName";
            this.txbName.PlaceholderText = "نام";
            this.txbName.Size = new System.Drawing.Size(239, 51);
            this.txbName.TabIndex = 0;
            this.txbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbPhone
            // 
            this.txbPhone.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbPhone.Location = new System.Drawing.Point(265, 34);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.PlaceholderText = "شماره تماس";
            this.txbPhone.Size = new System.Drawing.Size(239, 51);
            this.txbPhone.TabIndex = 1;
            this.txbPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPhone_KeyPress);
            // 
            // txbDevice
            // 
            this.txbDevice.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbDevice.Location = new System.Drawing.Point(12, 34);
            this.txbDevice.Name = "txbDevice";
            this.txbDevice.PlaceholderText = "دستگاه";
            this.txbDevice.Size = new System.Drawing.Size(239, 51);
            this.txbDevice.TabIndex = 2;
            this.txbDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbProblems
            // 
            this.txbProblems.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbProblems.Location = new System.Drawing.Point(12, 118);
            this.txbProblems.Multiline = true;
            this.txbProblems.Name = "txbProblems";
            this.txbProblems.PlaceholderText = "مشکلات";
            this.txbProblems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbProblems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbProblems.Size = new System.Drawing.Size(743, 287);
            this.txbProblems.TabIndex = 3;
            this.txbProblems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.Location = new System.Drawing.Point(12, 431);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(743, 71);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(776, 540);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbProblems);
            this.Controls.Add(this.txbDevice);
            this.Controls.Add(this.txbPhone);
            this.Controls.Add(this.txbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddOrderForm";
            this.Text = "تعمیرات/افزودن";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddOrderForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbName;
        private TextBox txbPhone;
        private TextBox txbDevice;
        private TextBox txbProblems;
        private Button btnAdd;
    }
}