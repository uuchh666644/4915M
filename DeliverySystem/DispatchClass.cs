using Dispatch_Processing_System;
using MySql.Data.MySqlClient;
using Student_Management_System;
using System;
using System.Data;

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
        if (command.ExecuteNonQuery() == 1)
        {
            connect.closeConnect();
            return true;
        }
        else
        {
            connect.closeConnect();
            return false;
        }
    }

    internal string CompletedDispatchCount()
    {
        throw new NotImplementedException();
    }

    internal string PendingDispatchCount()
    {
        throw new NotImplementedException();
    }

    internal string TodayDispatchCount()
    {
        throw new NotImplementedException();
    }

    // 获取所有送货单
    public DataTable GetDispatchList()
    {
        MySqlCommand command = new MySqlCommand("SELECT * FROM `deliveries`", connect.getconnection);
        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        DataTable table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    // 添加送货单项
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
        if (command.ExecuteNonQuery() == 1)
        {
            connect.closeConnect();
            return true;
        }
        else
        {
            connect.closeConnect();
            return false;
        }
    }
}
