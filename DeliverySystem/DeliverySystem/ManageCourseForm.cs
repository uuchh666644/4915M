using System;
using System.Windows.Forms;
using System.Data;

namespace Dispatch_Processing_System
{
    public partial class ManageDispatch : Form
    {
        DispatchClass dispatch = new DispatchClass();

        public ManageDispatch()
        {
            InitializeComponent();
        }

        private void ManageDispatch_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void showTable()
        {
            DataGridView_dispatch.DataSource = dispatch.GetDispatchList();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            DateTime dispatchDate = dateTimePicker_dispatch.Value;
            string customer = textBox_customer.Text;
            string address = textBox_address.Text;

            if (dispatch.InsertDispatch(dispatchDate, customer, address))
            {
                showTable();
                MessageBox.Show("Delivery order added successfully");
            }
            else
            {
                MessageBox.Show("Addition failed");
            }
        }

        // Other methods...
    }
}