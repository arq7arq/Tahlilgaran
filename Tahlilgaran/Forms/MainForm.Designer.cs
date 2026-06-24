namespace Tahlilgaran.Forms
{
    partial class MainForm
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
            this.pcbInventory = new System.Windows.Forms.PictureBox();
            this.pcbWorkshop = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbWorkshop)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbInventory
            // 
            this.pcbInventory.Image = global::Tahlilgaran.Properties.Resources.inventory;
            this.pcbInventory.Location = new System.Drawing.Point(45, 58);
            this.pcbInventory.Name = "pcbInventory";
            this.pcbInventory.Size = new System.Drawing.Size(316, 284);
            this.pcbInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbInventory.TabIndex = 0;
            this.pcbInventory.TabStop = false;
            // 
            // pcbWorkshop
            // 
            this.pcbWorkshop.Image = global::Tahlilgaran.Properties.Resources.project_management;
            this.pcbWorkshop.Location = new System.Drawing.Point(445, 65);
            this.pcbWorkshop.Name = "pcbWorkshop";
            this.pcbWorkshop.Size = new System.Drawing.Size(280, 277);
            this.pcbWorkshop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbWorkshop.TabIndex = 1;
            this.pcbWorkshop.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(164, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "انبار";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(492, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 54);
            this.label2.TabIndex = 3;
            this.label2.Text = " تعمیرات";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(803, 447);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcbWorkshop);
            this.Controls.Add(this.pcbInventory);
            this.Name = "MainForm";
            this.Text = "صغحه اصلی";
            ((System.ComponentModel.ISupportInitialize)(this.pcbInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbWorkshop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pcbInventory;
        private PictureBox pcbWorkshop;
        private Label label1;
        private Label label2;
    }
}