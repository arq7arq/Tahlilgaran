namespace Tahlilgaran.Forms
{
    partial class AddInventoryForm
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
            this.txbCount = new System.Windows.Forms.TextBox();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.txbDesc = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbName
            // 
            this.txbName.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbName.Location = new System.Drawing.Point(37, 32);
            this.txbName.Name = "txbName";
            this.txbName.PlaceholderText = "نام محصول";
            this.txbName.Size = new System.Drawing.Size(457, 57);
            this.txbName.TabIndex = 0;
            this.txbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbCount
            // 
            this.txbCount.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbCount.Location = new System.Drawing.Point(37, 126);
            this.txbCount.Name = "txbCount";
            this.txbCount.PlaceholderText = "تعداد";
            this.txbCount.Size = new System.Drawing.Size(457, 57);
            this.txbCount.TabIndex = 1;
            this.txbCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCount_KeyPress);
            // 
            // txbPrice
            // 
            this.txbPrice.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbPrice.Location = new System.Drawing.Point(37, 218);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.PlaceholderText = "قیمت";
            this.txbPrice.Size = new System.Drawing.Size(457, 57);
            this.txbPrice.TabIndex = 2;
            this.txbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPrice_KeyPress);
            // 
            // txbDesc
            // 
            this.txbDesc.AcceptsReturn = true;
            this.txbDesc.AllowDrop = true;
            this.txbDesc.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbDesc.Location = new System.Drawing.Point(37, 302);
            this.txbDesc.Multiline = true;
            this.txbDesc.Name = "txbDesc";
            this.txbDesc.PlaceholderText = "توضیحات";
            this.txbDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbDesc.Size = new System.Drawing.Size(457, 253);
            this.txbDesc.TabIndex = 3;
            this.txbDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.Location = new System.Drawing.Point(37, 584);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(457, 81);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(538, 686);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbDesc);
            this.Controls.Add(this.txbPrice);
            this.Controls.Add(this.txbCount);
            this.Controls.Add(this.txbName);
            this.Name = "AddInventoryForm";
            this.Text = "انبار/افزودن";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddInventoryForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbName;
        private TextBox txbCount;
        private TextBox txbPrice;
        private TextBox txbDesc;
        private Button btnAdd;
    }
}