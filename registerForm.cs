using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace afterservice
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            comboBox1.Items.Add("inventory staff");
            comboBox1.Items.Add("delivery staff");
            comboBox1.Items.Add("product controller staff");
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = comboBox1.SelectedItem.ToString();  
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string username = username1.Text.Trim();
            string password = password1.Text.Trim();
            string permission = comboBox1.SelectedItem.ToString().Trim();
            if (verify())
            {
                DBconnect connect = new DBconnect();
                string query="Insert into user(username,password, permission) values (@username, @password, @permission)";
                try
                {

                    using (MySqlCommand cmd = new MySqlCommand(query, connect.getconnection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@permission", permission);
                        connect.openConnect();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Insert failed, please check your input.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Save failed："+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            bool verify()
            {
                if (username == "" || password == "")
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }

        private void registerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
