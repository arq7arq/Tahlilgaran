namespace Tahlilgaran.Forms
{
    partial class OrderDetail
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
            this.txbProblems = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbProblems
            // 
            this.txbProblems.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbProblems.Location = new System.Drawing.Point(12, 12);
            this.txbProblems.Multiline = true;
            this.txbProblems.Name = "txbProblems";
            this.txbProblems.ReadOnly = true;
            this.txbProblems.Size = new System.Drawing.Size(738, 583);
            this.txbProblems.TabIndex = 0;
            this.txbProblems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 607);
            this.Controls.Add(this.txbProblems);
            this.Name = "OrderDetail";
            this.Text = "OrderDetail";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderDetail_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txbProblems;
    }
}