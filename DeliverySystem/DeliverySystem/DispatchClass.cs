using Dispatch_Processing_System;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Dispatch_Processing_System
{
    class DispatchClass
    {
        DBconnect connect = new DBconnect();

        public bool InsertDispatch(DateTime dispatchDate, string customerName, string deliveryAddress)
        {
            MySqlCommand command = new MySqlCommand(
                "INSERT INTO `deliveries`(`dispatch_date`, `customer_name`, `delivery_address`) VALUES (@date, @name, @address)",
                connect.getconnection);

            command.Parameters.Add("@date", MySqlDbType.Date).Value = dispatchDate;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = customerName;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = deliveryAddress;

            connect.openConnect();
            bool result = command.ExecuteNonQuery() == 1;
            connect.closeConnect();
            return result;
        }

        public string CompletedDispatchCount()
        {
            // Count completed deliveries (status = 'completed')
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `deliveries` WHERE `status` = 'completed'", connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }

        public string PendingDispatchCount()
        {
            // Count pending deliveries (status = 'pending')
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `deliveries` WHERE `status` = 'pending'", connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }

        public string TodayDispatchCount()
        {
            // Count today's deliveries
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `deliveries` WHERE DATE(dispatch_date) = CURDATE()", connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }

        // Get all deliveries
        public DataTable GetDispatchList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `deliveries`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // Add delivery item
        public bool AddDispatchItem(int dispatchId, string productCode, string description, int quantity)
        {
            MySqlCommand command = new MySqlCommand(
                "INSERT INTO `delivery_items`(`dispatch_id`, `product_code`, `description`, `quantity`) VALUES (@id, @code, @desc, @qty)",
                connect.getconnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = dispatchId;
            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = productCode;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@qty", MySqlDbType.Int32).Value = quantity;

            connect.openConnect();
            bool result = command.ExecuteNonQuery() == 1;
            connect.closeConnect();
            return result;
        }
    }
}