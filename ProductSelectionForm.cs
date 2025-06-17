using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace afterservice
{
    public partial class ProductSelectionForm : Form
    {
        private string connStr = "server=localhost;database=afterservice;uid=root;password=;";
        public DeliveryOrderData OrderData = new DeliveryOrderData();

        public ProductSelectionForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void ProductSelectionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadProducts()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT prodID, prodname, Quantity FROM productinventry";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewProducts.DataSource = dt;
                    dataGridViewProducts.ClearSelection();

                    dataGridViewProducts.ReadOnly = true;
                    dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewProducts.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load product: " + ex.Message);
            }
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!string.IsNullOrEmpty(textBoxQuantity.Text) && !int.TryParse(textBoxQuantity.Text, out value))
            {
                MessageBox.Show("Please enter a valid number");
                textBoxQuantity.Clear();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product");
                return;
            }
            int qty;
            if (!int.TryParse(textBoxQuantity.Text, out qty) || qty <= 0)
            {
                MessageBox.Show("Please enter the correct quantity");
                textBoxQuantity.Focus();
                return;
            }

            string productName = dataGridViewProducts.CurrentRow.Cells["prodname"].Value.ToString();

            OrderData.Product = productName;
            OrderData.Quantity = qty;

            CustomerInfoForm infoForm = new CustomerInfoForm(OrderData);
            this.Hide();
            var result = infoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            deliveryStaffMenu form = new deliveryStaffMenu();
            this.Hide();
            form.Show();
        }
    }
}