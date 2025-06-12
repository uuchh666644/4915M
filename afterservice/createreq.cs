using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using MySql.Data.MySqlClient;

namespace afterservice
{
    public partial class createreq : Form
    {
        public createreq()
        {
            InitializeComponent();

            List<string> userList = new List<string> { "au-yeungyingkit", "nghoyin", "wangchunho", "tsepokchuen" };
            comboBox2.DataSource = userList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.Load += new EventHandler(Create_Requirement_Load);
        }
        public delegate void DataSubmittedHandler();
        public event DataSubmittedHandler dataSubmitted;
        private void Create_Requirement_Load(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            string fullid = guid.ToString("N");
            using (System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(fullid));
                string shortHash = BitConverter.ToString(hash).Replace("-", "").Substring(0, 8);
                this.textBox4.Text = shortHash;
                this.textBox4.ReadOnly = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reqID = this.textBox4.Text.Trim();
            string createBy = this.comboBox2.SelectedItem?.ToString() ?? "";
            string remark = this.richTextBox1.Text.Trim();
            string productType = this.textBox3.Text.Trim();
            string cusName = this.textBox5.Text.Trim();
            string cusPhone = this.textBox1.Text.Trim();
            string cusAddress = this.textBox6.Text.Trim();
            DateTime receivingTime = this.dateTimePicker1.Value.Date;

            if (string.IsNullOrEmpty(reqID) || string.IsNullOrEmpty(createBy) || string.IsNullOrEmpty(remark) || string.IsNullOrEmpty(productType))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string connectionString = "server=localhost;database=afterservice;uid=root;password=;";

            string query = "INSERT INTO Requirements (ReqID, CreatedBy, remark, productType, ReceivingTime, cusName, cusPhone, cusAddress) " +
                "VALUES (@reqID, @createdBy, @remark, @productType, @receivingTime,@cusName,@cusPhone,@cusAddress)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reqID", reqID);
                        cmd.Parameters.AddWithValue("@createdBy", createBy);
                        cmd.Parameters.AddWithValue("@remark", remark);
                        cmd.Parameters.AddWithValue("@productType", productType);
                        cmd.Parameters.AddWithValue("@cusName", cusName);
                        cmd.Parameters.AddWithValue("@cusPhone", cusPhone);
                        cmd.Parameters.AddWithValue("@cusAddress", cusAddress);
                        cmd.Parameters.AddWithValue("@receivingTime", receivingTime);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data has been saved successfully!");
                        dataSubmitted?.Invoke();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save failed：" + ex.Message);
            }
        }
    }
}
