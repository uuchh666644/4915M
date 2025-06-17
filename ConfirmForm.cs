using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace afterservice
{
    public partial class ConfirmForm : Form
    {
        private DeliveryOrderData OrderData;

        public ConfirmForm(DeliveryOrderData data)
        {
            InitializeComponent();
            OrderData = data;
            ShowOrderData();
        }

        private void ShowOrderData()
        {
            labelProduct.Text = $"Product：{OrderData.Product}";
            labelQuantity.Text = $"Quantity：{OrderData.Quantity}";
            labelName.Text = $"CustomerName：{OrderData.CustomerName}";
            labelAddress.Text = $"Address：{OrderData.Address}";
            labelPhone.Text = $"Phone：{OrderData.Phone}";
            labelEmail.Text = $"Email：{OrderData.Email}";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order Confirmed!\nThank you!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            ((Form)previewDialog).WindowState = FormWindowState.Maximized;
            previewDialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float y = 100;
            float left = 100;
            float lineHeight = 25;
            Font printFont = new Font("Arial", 12);

            e.Graphics.DrawString("Order Confirmation", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, left, y);
            y += lineHeight * 2;

            e.Graphics.DrawString(labelProduct.Text, printFont, Brushes.Black, left, y); y += lineHeight;
            e.Graphics.DrawString(labelQuantity.Text, printFont, Brushes.Black, left, y); y += lineHeight;
            e.Graphics.DrawString(labelName.Text, printFont, Brushes.Black, left, y); y += lineHeight;
            e.Graphics.DrawString(labelAddress.Text, printFont, Brushes.Black, left, y); y += lineHeight;
            e.Graphics.DrawString(labelPhone.Text, printFont, Brushes.Black, left, y); y += lineHeight;
            e.Graphics.DrawString(labelEmail.Text, printFont, Brushes.Black, left, y); y += lineHeight;
        }

        // 以下 label 點擊事件通常可刪除或留空
        private void labelProduct_Click(object sender, EventArgs e) { }
        private void labelQuantity_Click(object sender, EventArgs e) { }
        private void labelName_Click(object sender, EventArgs e) { }
        private void labelAddress_Click(object sender, EventArgs e) { }
        private void labelPhone_Click(object sender, EventArgs e) { }
        private void labelEmail_Click(object sender, EventArgs e) { }
    }
}