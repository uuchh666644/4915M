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
using DGVPrinterHelper;

namespace afterservice
{
    public partial class Dispatch : Form
    {
        DGVPrinter printer = new DGVPrinter();
        GuestClass dispatch = new GuestClass();
        public Dispatch()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void showTable()
        {
            dataGridView1.DataSource = dispatch.getDispathlist();

        }
        private void Dispatch_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string gn = textBox_guestname.Text;
            string pro = comboBox_product.Text;
            string phone = textBox_phone.Text;
            string email = textBox_email.Text;
            string address = textBox_address.Text;
            DateTime odate = dateTimePicker1.Value;
            MemoryStream ms = new MemoryStream();

            if (verify())
            {
                try
                {
                    if (dispatch.insertorder(gn, pro, phone, email, address, odate))
                    {
                        showTable();
                        MessageBox.Show("New request Added", "Add request", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            else
            {

                MessageBox.Show("Empty", "Add request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        bool verify()
        {
            if ((textBox_address.Text == "") || (textBox_guestname.Text == "") || (textBox_phone.Text == "") || (comboBox_product.Text == ""))
            {
                return false;
            }
            else
                return true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_email.Clear();
            textBox_address.Clear();
            textBox_guestname.Clear();
            textBox_phone.Clear();
            comboBox_product.ResetText();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            menu mu = new menu();
            this.Hide();
            mu.Show();
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            printer.Title = "Delivery";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "end";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView1);
        }
    }
}
