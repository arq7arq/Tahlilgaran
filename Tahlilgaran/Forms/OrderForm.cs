using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tahlilgaran.Data;
using Tahlilgaran.Models;

namespace Tahlilgaran.Forms
{
    public partial class OrderForm : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private Order _printOrder;
        private Image _logo;

        private Form _parent;
        public OrderForm(Form parent)
        {
            InitializeComponent();
            _parent = parent;
            printDocument.PrintPage += PrintDocument_PrintPage;
            _logo = Properties.Resources.tahlilgaran;
            printDocument.BeginPrint += PrintDocument_BeginPrint;
        }

        public void UpdateData()
        {
            using var db = new AppDBContext();

            var res = db.Orders.ToList();

            dataGridView1.DataSource = res.Select(x => new
            {
                x.OrderID,
                x.Device,
                x.UserName,
                x.Phone,
                x.Problems,
                x.Price,
                x.StartTime,
                x.FinishTime
            }).ToList();

            dataGridView1.Columns["OrderID"].HeaderText = "کد تحویل";
            dataGridView1.Columns["Device"].HeaderText = "دستگاه";
            dataGridView1.Columns["UserName"].HeaderText = "نام";
            dataGridView1.Columns["Phone"].HeaderText = "شماره تماس";
            dataGridView1.Columns["Problems"].HeaderText = "مشکلات";
            dataGridView1.Columns["StartTime"].HeaderText = "زمان دریافت";
            dataGridView1.Columns["FinishTime"].HeaderText = "زمان تحویل";
            dataGridView1.Columns["Price"].HeaderText = "هزینه";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id = Convert.ToInt32(row.Cells["OrderID"].Value);

                Order order = res.FirstOrDefault(x => x.OrderID == id);

                if (order.IsComplete)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (order.IsDone)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }

            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void OrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm(this);
            addOrderForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            AddOrderForm editOrderForm = new AddOrderForm(this);
            editOrderForm.Text = "تعمیرات/ویرایش";
            editOrderForm.editMode = true;
            editOrderForm.SetUpdateValue(res);
            editOrderForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            try
            {
                var res = db.Orders.FirstOrDefault(x => x.OrderID == id);
                db.Remove(res);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("خطا در حذف اطلاعات");
            }
            finally
            {
                MessageBox.Show("تعمیر با موفقیت حذف شد");
            }
            UpdateData();
        }

        public void FinishDone(int id, decimal price, bool reminder)
        {
            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            try
            {
                res.IsDone = true;
                res.Price = price;
                res.Reminder = reminder;
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
                MessageBox.Show("دستگاه اماده است");
                UpdateData();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            AddPriceForm addPriceForm = new AddPriceForm(this);
            addPriceForm.SetOrderID(id);
            addPriceForm.Show();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            if (!res.IsDone)
            {
                MessageBox.Show("دستگاه هنوز اماده تحویل نیست");
            }
            else
            {
                try
                {
                    res.IsComplete = true;
                    res.FinishTime = DateTime.Now;
                    db.Update(res);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("خطا در ثبت اطلاعات");
                }
                finally
                {
                    MessageBox.Show("دستگاه به مشتری تحویل داده شد");
                    UpdateData();
                }
            }
            
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txbSearch.Text;

            using var db = new AppDBContext();

            var res = db.Orders.Where(x => x.UserName.Contains(search) || x.Phone.Contains(search) || x.Device.Contains(search)).ToList();

            dataGridView1.DataSource = res.Select(x => new
            {
                x.OrderID,
                x.Device,
                x.UserName,
                x.Phone,
                x.Problems,
                x.Price,
                x.StartTime,
                x.FinishTime
            }).ToList();

            dataGridView1.Columns["OrderID"].HeaderText = "کد تحویل";
            dataGridView1.Columns["Device"].HeaderText = "دستگاه";
            dataGridView1.Columns["UserName"].HeaderText = "نام";
            dataGridView1.Columns["Phone"].HeaderText = "شماره تماس";
            dataGridView1.Columns["Problems"].HeaderText = "مشکلات";
            dataGridView1.Columns["StartTime"].HeaderText = "زمان دریافت";
            dataGridView1.Columns["FinishTime"].HeaderText = "زمان تحویل";
            dataGridView1.Columns["Price"].HeaderText = "هزینه";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id = Convert.ToInt32(row.Cells["OrderID"].Value);

                Order order = res.FirstOrDefault(x => x.OrderID == id);

                if (order.IsComplete)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (order.IsDone)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.FirstOrDefault(x => x.OrderID == id);

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }

            OrderDetail orderDetail = new OrderDetail(this);
            orderDetail.SetProblems(res.Problems);
            orderDetail.Show();
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["OrderID"].Value);

            using var db = new AppDBContext();

            var res = db.Orders.Include(x => x.OrderPrices).FirstOrDefault(x => x.OrderID == id);

            _printOrder = res;

            if (res == null)
            {
                MessageBox.Show("خطا در دریافت اطلاعات");
            }


            using (PrintPreviewDialog preview = new PrintPreviewDialog())
            {
                preview.Document = printDocument;
                preview.Width = 1000;
                preview.Height = 700;
                preview.ShowDialog();
            }
        }

        private int _printItemIndex = 0;

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            _printItemIndex = 0;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Display;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int width = e.MarginBounds.Width;
            int pageBottom = e.MarginBounds.Bottom;

            using Font shopFont = new Font("Tahoma", 22, FontStyle.Bold);
            using Font titleFont = new Font("Tahoma", 30, FontStyle.Bold);
            using Font normalFont = new Font("Tahoma", 16);
            using Font boldFont = new Font("Tahoma", 16, FontStyle.Bold);
            using Font tableFont = new Font("Tahoma", 15);
            using Font headerFont = new Font("Tahoma", 15, FontStyle.Bold);

            using Pen borderPen = new Pen(Color.Black, 1);
            using Brush headerBrush = new SolidBrush(Color.FromArgb(235, 235, 235));

            StringFormat rtl = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            StringFormat center = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            // Outer border
            g.DrawRectangle(borderPen, x - 20, y - 20, width + 40, e.MarginBounds.Height + 20);

            // Logo
            int logoSize = 100;
            int logoX = x + (width - logoSize * 2) / 2;

            if (_logo != null)
                g.DrawImage(_logo, logoX, y, logoSize * 2, logoSize);

            y += 145;

            // Invoice title
            g.DrawString("فاکتور", titleFont, Brushes.Black,
                new RectangleF(x, y, width, 55), center);

            y += 80;

            // Customer info table
            int infoLabelWidth = 170;
            int infoHeight = 55;

            DrawCell(g, "تاریخ", boldFont, headerBrush, borderPen,
                x + width - infoLabelWidth, y, infoLabelWidth, infoHeight, center);

            DrawCell(g, DateTime.Now.ToString("yyyy/MM/dd HH:mm"), normalFont, Brushes.White, borderPen,
                x, y, width - infoLabelWidth, infoHeight, center);

            y += infoHeight;

            DrawCell(g, "شماره تماس", boldFont, headerBrush, borderPen,
                x + width - infoLabelWidth, y, infoLabelWidth, infoHeight, center);

            DrawCell(g, _printOrder.Phone, normalFont, Brushes.White, borderPen,
                x, y, width - infoLabelWidth, infoHeight, center);

            y += infoHeight;

            DrawCell(g, "نام مشتری", boldFont, headerBrush, borderPen,
                x + width - infoLabelWidth, y, infoLabelWidth, infoHeight, center);

            DrawCell(g, _printOrder.UserName, normalFont, Brushes.White, borderPen,
                x, y, width - infoLabelWidth, infoHeight, rtl);

            y += infoHeight + 40;

            // Items table
            int rowHeight = 55;
            int numberWidth = 90;
            int priceWidth = 230;
            int titleWidth = width - numberWidth - priceWidth;

            DrawCell(g, "ردیف", headerFont, headerBrush, borderPen,
                x + width - numberWidth, y, numberWidth, rowHeight, center);

            DrawCell(g, "عنوان", headerFont, headerBrush, borderPen,
                x + priceWidth, y, titleWidth, rowHeight, center);

            DrawCell(g, "قیمت (تومان)", headerFont, headerBrush, borderPen,
                x, y, priceWidth, rowHeight, center);

            y += rowHeight;

            var items = _printOrder.OrderPrices.ToList();

            int lastPageReserve = 200;

            while (_printItemIndex < items.Count)
            {
                bool isLastItem = _printItemIndex == items.Count - 1;
                int neededSpace = rowHeight;

                if (isLastItem)
                    neededSpace += lastPageReserve;

                if (y + neededSpace > pageBottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                var item = items[_printItemIndex];

                DrawCell(g, (_printItemIndex + 1).ToString(), tableFont, Brushes.White, borderPen,
                    x + width - numberWidth, y, numberWidth, rowHeight, center);

                DrawCell(g, item.Title, tableFont, Brushes.White, borderPen,
                    x + priceWidth, y, titleWidth, rowHeight, rtl);

                DrawCell(g, $"{item.Price:N0}", tableFont, Brushes.White, borderPen,
                    x, y, priceWidth, rowHeight, center);

                y += rowHeight;
                _printItemIndex++;
            }

            y += 40;

            // Total
            DrawCell(g, "هزینه کل", boldFont, headerBrush, borderPen,
                x + width - infoLabelWidth, y, infoLabelWidth, 60, center);

            DrawCell(g, $"{_printOrder.Price:N0} تومان", boldFont, Brushes.White, borderPen,
                x, y, width - infoLabelWidth, 60, center);

            y += 90;

            // Footer
            g.DrawString("با تشکر از خرید شما", normalFont, Brushes.Black,
                new RectangleF(x, y, width, 40), center);

            e.HasMorePages = false;
        }

        private void DrawCell(
    Graphics g,
    string text,
    Font font,
    Brush background,
    Pen border,
    int x,
    int y,
    int width,
    int height,
    StringFormat format)
        {
            g.FillRectangle(background, x, y, width, height);
            g.DrawRectangle(border, x, y, width, height);

            RectangleF textRect = new RectangleF(x + 10, y, width - 20, height);
            g.DrawString(text ?? "", font, Brushes.Black, textRect, format);
        }
    }
}

