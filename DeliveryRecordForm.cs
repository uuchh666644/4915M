using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Printing;

namespace afterservice
{
    public partial class DeliveryRecordForm : Form
    {
        string connStr = "server=localhost;database=afterservice;uid=root;password=;";

        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private DataTable currentTable;

        public DeliveryRecordForm()
        {
            InitializeComponent();
            LoadRecords();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            printDocument1.PrintPage += PrintDocument1_PrintPage;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "INSERT INTO makeorder (guestname, product, phone, address, email, status) VALUES (@name, @prod, @phone, @addr, @email, 'Pending')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", textBoxGuestName.Text);
                cmd.Parameters.AddWithValue("@prod", textBoxProduct.Text);
                cmd.Parameters.AddWithValue("@phone", int.Parse(textBoxPhone.Text));
                cmd.Parameters.AddWithValue("@addr", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added delivery record successfully!");
                LoadRecords();
            }
        }

        private void LoadRecords()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM makeorder";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                currentTable = dt;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int orderID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["orderID"].Value);
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "DELETE FROM makeorder WHERE orderID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", orderID);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted delivery record successfully!");
                LoadRecords();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int orderID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["orderID"].Value);
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "UPDATE makeorder SET guestname=@name, product=@prod, phone=@phone, address=@addr, email=@email WHERE orderID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", textBoxGuestName.Text);
                cmd.Parameters.AddWithValue("@prod", textBoxProduct.Text);
                cmd.Parameters.AddWithValue("@phone", int.Parse(textBoxPhone.Text));
                cmd.Parameters.AddWithValue("@addr", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@id", orderID);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated delivery record successfully!");
                LoadRecords();
            }
        }

        private void buttonDispatch_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int orderID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["orderID"].Value);
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "UPDATE makeorder SET status='Dispatched' WHERE orderID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", orderID);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order dispatched successfully!");
                LoadRecords();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var row = dataGridView1.CurrentRow;
            textBoxOrderID.Text = row.Cells["orderID"].Value?.ToString() ?? "";
            textBoxGuestName.Text = row.Cells["guestname"].Value?.ToString() ?? "";
            textBoxProduct.Text = row.Cells["product"].Value?.ToString() ?? "";
            textBoxPhone.Text = row.Cells["phone"].Value?.ToString() ?? "";
            textBoxAddress.Text = row.Cells["address"].Value?.ToString() ?? "";
            textBoxEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a delivery record to print.");
                return;
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var row = dataGridView1.CurrentRow;
            int x = 100, y = 100, lineHeight = 30;
            Font font = new Font("Arial", 12);

            e.Graphics.DrawString("Delivery Note", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, x, y);
            y += lineHeight * 2;

            e.Graphics.DrawString("Order ID: " + (row.Cells["orderID"].Value?.ToString() ?? ""), font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Customer: " + (row.Cells["guestname"].Value?.ToString() ?? ""), font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Product: " + (row.Cells["product"].Value?.ToString() ?? ""), font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Phone: " + (row.Cells["phone"].Value?.ToString() ?? ""), font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Address: " + (row.Cells["address"].Value?.ToString() ?? ""), font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Email: " + (row.Cells["email"].Value?.ToString() ?? ""), font, Brushes.Black, x, y); y += lineHeight;
            if (row.Cells["status"] != null)
                e.Graphics.DrawString("Status: " + (row.Cells["status"].Value?.ToString() ?? ""), font, Brushes.Black, x, y);
        }
    }
}