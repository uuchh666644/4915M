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
    public partial class ProductionForm : Form
    {

        GuestClass guest = new GuestClass();

        string connStr = "server=localhost;database=afterservice;uid=root;password=;";
        public ProductionForm()
        {
            InitializeComponent();
            LoadProduction();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "INSERT INTO production (prodName, quantity, startDate, endDate, status) VALUES (@n, @q, @s, @e, @st)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", txtProdName.Text);
                cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@s", dtStart.Value);
                cmd.Parameters.AddWithValue("@e", dtEnd.Value);
                cmd.Parameters.AddWithValue("@st", cmbStatus.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added successfully！");
                LoadProduction();
            }
        }

        private void LoadProduction()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT * FROM production";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int prodID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["prodID"].Value);
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "DELETE FROM production WHERE prodID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", prodID);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted successfully！");
                LoadProduction();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            int prodID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["prodID"].Value);
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "UPDATE production SET prodName=@n, quantity=@q, startDate=@s, endDate=@e, status=@st WHERE prodID=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", txtProdName.Text);
                cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@s", dtStart.Value);
                cmd.Parameters.AddWithValue("@e", dtEnd.Value);
                cmd.Parameters.AddWithValue("@st", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@id", prodID);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Success！");
                LoadProduction();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            txtProdName.Text = dataGridView1.CurrentRow.Cells["prodName"].Value.ToString();
            txtQuantity.Text = dataGridView1.CurrentRow.Cells["quantity"].Value.ToString();
            dtStart.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["startDate"].Value);
            dtEnd.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["endDate"].Value);
            cmbStatus.Text = dataGridView1.CurrentRow.Cells["status"].Value.ToString();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}