using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tahlilgaran.Forms
{
    public partial class PrintOptionsForm : Form
    {

        private readonly ComboBox cmbPaper = new ComboBox();
        private readonly ComboBox cmbPagesPerSheet = new ComboBox();
        private readonly CheckBox chkLandscape = new CheckBox();
        private readonly CheckBox chkPrinterDialog = new CheckBox();

        public string PaperName => cmbPaper.SelectedItem?.ToString() ?? "A4";
        public int PagesPerSheet => cmbPagesPerSheet.SelectedIndex == 1 ? 2 : 1;
        public bool Landscape => chkLandscape.Checked;
        public bool OpenPrinterDialog => chkPrinterDialog.Checked;

        public PrintOptionsForm()
        {
            Text = "تنظیمات چاپ";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;
            ClientSize = new Size(360, 230);
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;

            Label lblPaper = new Label { Text = "اندازه کاغذ", Left = 220, Top = 25, Width = 110 };
            cmbPaper.Left = 30;
            cmbPaper.Top = 20;
            cmbPaper.Width = 170;
            cmbPaper.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaper.Items.AddRange(new object[] { "A4", "A5" });
            cmbPaper.SelectedIndex = 0;

            Label lblPages = new Label { Text = "چیدمان", Left = 220, Top = 70, Width = 110 };
            cmbPagesPerSheet.Left = 30;
            cmbPagesPerSheet.Top = 65;
            cmbPagesPerSheet.Width = 170;
            cmbPagesPerSheet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPagesPerSheet.Items.AddRange(new object[] { "۱ صفحه در هر برگ", "۲ صفحه کنار هم" });
            cmbPagesPerSheet.SelectedIndex = 0;

            chkLandscape.Text = "چاپ افقی";
            chkLandscape.Left = 30;
            chkLandscape.Top = 110;
            chkLandscape.Width = 170;

            chkPrinterDialog.Text = "نمایش تنظیمات پرینتر";
            chkPrinterDialog.Left = 30;
            chkPrinterDialog.Top = 140;
            chkPrinterDialog.Width = 200;

            Button btnOk = new Button
            {
                Text = "تایید",
                DialogResult = DialogResult.OK,
                Left = 190,
                Top = 180,
                Width = 75
            };

            Button btnCancel = new Button
            {
                Text = "انصراف",
                DialogResult = DialogResult.Cancel,
                Left = 105,
                Top = 180,
                Width = 75
            };

            cmbPagesPerSheet.SelectedIndexChanged += (_, __) =>
            {
                if (PagesPerSheet == 2)
                    chkLandscape.Checked = true;
            };

            Controls.AddRange(new Control[]
            {
            lblPaper,
            cmbPaper,
            lblPages,
            cmbPagesPerSheet,
            chkLandscape,
            chkPrinterDialog,
            btnOk,
            btnCancel
            });

            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }
    }
}
