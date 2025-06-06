using System;
using System.Windows.Forms;

public partial class ManageDispatch : Form
{
    DispatchClass dispatch = new DispatchClass();

    public ManageDispatch()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
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
            MessageBox.Show("送货单添加成功");
        }
        else
        {
            MessageBox.Show("添加失败");
        }
    }
}