using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Dispatch_Processing_System
{
    public class ReceiptClass
    {
        DBconnect connect = new DBconnect();

        public DataTable GetReceiptList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `receipts`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}