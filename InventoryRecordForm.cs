using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace afterservice
{
    public partial class InventoryRecordForm : Form
    {
        string connStr = "server=localhost;database=afterservice;uid=root;password=;";

        public InventoryRecordForm()
        {
            InitializeComponent();
            LoadRecords();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        // 新增
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "INSERT INTO inwardrecord (Dateti, ItemName, Quantity, Supplier, price) VALUES (@d, @name, @q, @sup, @p)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@name", txtItemName.Text);
                cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@sup", txtSupplier.Text);
                cmd.Parameters.AddWithValue("@p", float.Parse(txtPrice.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully！");
                LoadRecords();
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM inwardrecord WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(txtItemName.Text))
                    sql += " AND ItemName LIKE @name";
                if (!string.IsNullOrWhiteSpace(txtSupplier.Text))
                    sql += " AND Supplier LIKE @sup";
                if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
                    sql += " AND Quantity = @q";
                if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                    sql += " AND price = @p";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(txtItemName.Text))
                    cmd.Parameters.AddWithValue("@name", "%" + txtItemName.Text + "%");
                if (!string.IsNullOrWhiteSpace(txtSupplier.Text))
                    cmd.Parameters.AddWithValue("@sup", "%" + txtSupplier.Text + "%");
                if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
                    cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text));
                if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                    cmd.Parameters.AddWithValue("@p", float.Parse(txtPrice.Text));

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void LoadRecords()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM inwardrecord";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int inID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["inID"].Value);
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "DELETE FROM inwardrecord WHERE inID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", inID);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully！");
                LoadRecords();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int inID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["inID"].Value);
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "UPDATE inwardrecord SET Dateti=@d, ItemName=@name, Quantity=@q, Supplier=@sup, price=@p WHERE inID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@name", txtItemName.Text);
                cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@sup", txtSupplier.Text);
                cmd.Parameters.AddWithValue("@p", float.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@id", inID);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Success！");
                LoadRecords();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var row = dataGridView1.CurrentRow;
            if (row.Cells["Dateti"].Value != null)
                dateTimePicker1.Value = DateTime.TryParse(row.Cells["Dateti"].Value.ToString(), out var dt)
                    ? dt
                    : DateTime.Now;
            txtItemName.Text = row.Cells["ItemName"].Value?.ToString() ?? "";
            txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
            txtSupplier.Text = row.Cells["Supplier"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["price"].Value?.ToString() ?? "";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}