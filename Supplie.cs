using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace afterservice
{
    public partial class Supplie : Form
    {
        GuestClass record = new GuestClass();
        public Supplie()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button_ADD_Click(object sender, EventArgs e)
        {
            string supplier = textBox_supplier.Text;
            string iteamname = textBox_iteamname.Text;
            string quantity = textBox_quantity.Text;
            string price = textBox_price.Text;
            DateTime indate = dateTimePicker1.Value;

            if (verify())
            {
                try
                {
                    if (record.insertinrecord(supplier, iteamname, quantity, price, indate))
                    {
                        MessageBox.Show("Now the Purchase order added", "Add Purchase order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Emty  Field", "Add record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bool verify()
            {
                if ((textBox_supplier.Text == "") || (textBox_iteamname.Text == "") || (textBox_quantity.Text == "") || (textBox_price.Text == ""))
                {
                    return false;
                }
                else
                    return true;
            }



        }

        private void Supplie_Load(object sender, EventArgs e)
        {
            {
                showTable();
            }
        }
        public void showTable()
        {
            dataGridView1.DataSource = record.getRecordlist();

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_supplier.Clear();
            textBox_iteamname.Clear();
            textBox_quantity.Clear();
            textBox_price.Clear();
        }
    }
}
