using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace afterservice
{
    public partial class DeliveryOrderForm : Form
    {
        private string connStr = "server=localhost;database=afterservice;uid=root;password=;";
        public DeliveryOrderData OrderData = new DeliveryOrderData();
        private Timer timerDateTime = new Timer();
        private Label labelEmailWarning = new Label();

        public DeliveryOrderForm()
        {
            InitializeComponent();
            LoadProducts();

            timerDateTime.Interval = 1000;
            timerDateTime.Tick += TimerDateTime_Tick;
            timerDateTime.Start();
            UpdateDateTime();
            labelEmailWarning.AutoSize = true;
            labelEmailWarning.ForeColor = System.Drawing.Color.Red;
            labelEmailWarning.Text = "Email must contain '@'";
            labelEmailWarning.Visible = false;
            labelEmailWarning.Location = new System.Drawing.Point(textBoxEmail.Left, textBoxEmail.Bottom + 2);
            groupBoxCustomerInformationGroupbox.Controls.Add(labelEmailWarning);
            textBoxName.TextChanged += textBoxName_TextChanged;
            textBoxPhone.TextChanged += textBoxPhone_TextChanged;
            textBoxEmail.TextChanged += textBoxEmail_TextChanged;
            buttonConfirm.Click += buttonConfirm_Click;
            buttonClear.Click += buttonClear_Click;
            buttonBack.Click += buttonBack_Click;
            dataGridViewProducts.CellEndEdit += dataGridViewProducts_CellEndEdit;
            dataGridViewProducts.CellValueChanged += dataGridViewProducts_CellValueChanged;
            dataGridViewProducts.CellValidating += dataGridViewProducts_CellValidating;
        }

        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            labelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void LoadProducts()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string sql = "SELECT prodID, prodname, Quantity, price FROM productinventry";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (!dt.Columns.Contains("OrderQuantity"))
                    dt.Columns.Add("OrderQuantity", typeof(int));

                foreach (DataRow row in dt.Rows)
                    row["OrderQuantity"] = 0;

                dataGridViewProducts.DataSource = dt;
                dataGridViewProducts.ReadOnly = false;
                dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewProducts.MultiSelect = true;
                dataGridViewProducts.Columns["OrderQuantity"].ReadOnly = false;
                dataGridViewProducts.Columns["prodID"].ReadOnly = true;
                dataGridViewProducts.Columns["prodname"].ReadOnly = true;
                dataGridViewProducts.Columns["Quantity"].ReadOnly = true;
                dataGridViewProducts.Columns["price"].ReadOnly = true;
            }
            UpdateTotal();
        }

        private void dataGridViewProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "OrderQuantity")
            {
                var row = dataGridViewProducts.Rows[e.RowIndex];
                int stock = 0, qty = 0;
                int.TryParse(row.Cells["Quantity"].Value?.ToString(), out stock);
                int.TryParse(row.Cells["OrderQuantity"].Value?.ToString(), out qty);

                if (qty < 0)
                {
                    MessageBox.Show("Quantity must be at least 1.");
                    row.Cells["OrderQuantity"].Value = 0;
                }
                else if (qty > stock)
                {
                    MessageBox.Show($"Not enough stock! Only {stock} left.");
                    row.Cells["OrderQuantity"].Value = stock;
                }
                UpdateTotal();
            }
        }

        private void dataGridViewProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "OrderQuantity")
                UpdateTotal();
        }

        private void dataGridViewProducts_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "OrderQuantity")
            {
                int val;
                if (!int.TryParse(e.FormattedValue.ToString(), out val))
                {
                    MessageBox.Show("Please enter a valid number.");
                    e.Cancel = true;
                }
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            DataTable dt = (DataTable)dataGridViewProducts.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                int qty = 0;
                decimal price = 0;
                int.TryParse(row["OrderQuantity"].ToString(), out qty);
                decimal.TryParse(row["price"].ToString(), out price);
                total += qty * price;
            }
            labelTotal.Text = $"Total: ${total:0.00}";
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            if (!Regex.IsMatch(textBoxName.Text, pattern))
            {
                MessageBox.Show("Only English letters and spaces are allowed in the name.");
                textBoxName.Text = Regex.Replace(textBoxName.Text, @"[^a-zA-Z\s]", "");
                textBoxName.SelectionStart = textBoxName.Text.Length;
            }
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[\d+]*$";
            if (!Regex.IsMatch(textBoxPhone.Text, pattern))
            {
                MessageBox.Show("Only numbers and + are allowed in the phone.");
                textBoxPhone.Text = Regex.Replace(textBoxPhone.Text, @"[^\d+]", "");
                textBoxPhone.SelectionStart = textBoxPhone.Text.Length;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) && !textBoxEmail.Text.Contains("@"))
            {
                labelEmailWarning.Visible = true;
            }
            else
            {
                labelEmailWarning.Visible = false;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewProducts.DataSource;
            OrderData.Items = new List<OrderItem>();
            foreach (DataRow row in dt.Rows)
            {
                int orderQty = 0, invenQty = 0;
                int.TryParse(row["OrderQuantity"].ToString(), out orderQty);
                int.TryParse(row["Quantity"].ToString(), out invenQty);
                if (orderQty > 0)
                {
                    if (orderQty > invenQty)
                    {
                        MessageBox.Show($"Not enough stock for {row["prodname"]}. Only {invenQty} left.");
                        return;
                    }
                    string prodName = row["prodname"].ToString();
                    decimal price = 0;
                    decimal.TryParse(row["price"].ToString(), out price);

                    OrderData.Items.Add(new OrderItem
                    {
                        ProductName = prodName,
                        Quantity = orderQty,
                        Price = price
                    });
                }
            }
            if (OrderData.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one product, and quantity must be at least 1.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Name, Phone, and Email are required.");
                return;
            }
            if (!Regex.IsMatch(textBoxName.Text, @"^[a-zA-Z\s]*$"))
            {
                MessageBox.Show("Only English letters and spaces are allowed in the name.");
                return;
            }
            if (!Regex.IsMatch(textBoxPhone.Text, @"^[\d+]*$"))
            {
                MessageBox.Show("Only numbers and + are allowed in the phone.");
                return;
            }
            if (!textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email must contain '@'.");
                labelEmailWarning.Visible = true;
                return;
            }

            OrderData.CustomerName = textBoxName.Text.Trim();
            OrderData.Address = textBoxAddress.Text.Trim();
            OrderData.Phone = textBoxPhone.Text.Trim();
            OrderData.Email = textBoxEmail.Text.Trim();

            OrderRepository.Orders.Add(OrderData);

            MessageBox.Show("Order created! You can review it in the order list.");
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewProducts.Rows)
                row.Cells["OrderQuantity"].Value = 0;
            textBoxName.Clear();
            textBoxPhone.Clear();
            textBoxEmail.Clear();
            textBoxAddress.Clear();
            labelTotal.Text = "Total: $0.00";
            labelEmailWarning.Visible = false;
        }

        // 返回
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
