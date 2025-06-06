using System.Windows.Forms;

public partial class MainForm : Form
{
    DBconnect connect = new DBconnect();

    private void button_dispatch_Click(object sender, EventArgs e)
    {
        showSubmenu(panel_dispatchSubmenu);
    }

    #region DispatchSubmenu
    private void button_createDispatch_Click(object sender, EventArgs e)
    {
        openChildForm(new CreateDispatchForm());
        hideSubmenu();
    }

    private void button_manageDispatch_Click(object sender, EventArgs e)
    {
        openChildForm(new ManageDispatch());
        hideSubmenu();
    }

    private void button_printDispatch_Click(object sender, EventArgs e)
    {
        openChildForm(new PrintDispatch());
        hideSubmenu();
    }
    #endregion

    private void button_receipt_Click(object sender, EventArgs e)
    {
        showSubmenu(panel_receiptSubmenu);
    }

    #region ReceiptSubmenu
    private void button_recordReceipt_Click(object sender, EventArgs e)
    {
        openChildForm(new RecordReceiptForm());
        hideSubmenu();
    }

    private void button_manageReceipt_Click(object sender, EventArgs e)
    {
        openChildForm(new ManageReceipt());
        hideSubmenu();
    }
    #endregion

    public DataTable GetReceiptList()
    {
        MySqlCommand command = new MySqlCommand("SELECT * FROM `receipts`", connect.getconnection);
        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }
}
