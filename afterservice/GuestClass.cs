using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace afterservice
{
    class GuestClass
    {
        DBconnect connect = new DBconnect();

        public bool insertOrder(string oid, DateTime oDate, string name, string email, string Phone, string request, string state)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `info`(`OrderID`, `OrderDate`, `Name`, `Email`, `Phone`,`Request`, `state`) VALUES(@oid, @odate, @name, @email, @phone, @request, @state)", connect.getconnection);

            command.Parameters.Add("@oid",MySqlDbType.VarChar).Value = oid;
            command.Parameters.Add("@odate", MySqlDbType.VarChar).Value = oDate;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = Phone;
            command.Parameters.Add("@request", MySqlDbType.VarChar).Value = request;
            command.Parameters.Add("@state", MySqlDbType.VarChar).Value = state;


            connect.openConnect();
            if(command.ExecuteNonQuery() ==1)
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
        public DataTable getGuestlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `info`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
            
            }


        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        public bool insertinrecord(string supplier, string itemname, string quantity, string price, DateTime indate)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `inwardrecord`( `Supplier`, `ItemName`, `Quantity`, `price`, `Dateti`) VALUES(@sp, @itn, @qu, @pr, @Dt)");
            command.Parameters.Add("@sp", MySqlDbType.VarChar).Value = supplier;
            command.Parameters.Add("@itn", MySqlDbType.VarChar).Value = itemname;
            command.Parameters.Add("@qu", MySqlDbType.VarChar).Value = quantity;
            command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = price;
            command.Parameters.Add("@Dt", MySqlDbType.VarChar).Value = indate;

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
        public DataTable getRecordlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `inwardrecord`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getRecordkeylist(string columnName, string keyword)
        {
            // Validate columnName against a whitelist to avoid SQL injection
            string[] validColumns = { "price", "Supplier", "Quantity", "ItemName", "Dateti", "inID" };
            if (!validColumns.Contains(columnName))
                throw new ArgumentException("Invalid column name.");

            string query = $"SELECT * FROM `inwardrecord` WHERE `{columnName}` LIKE @keyword";
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


        public bool insertorder(string gn, string pro, string phone, string email, string address, DateTime oDate)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `makeorder`(`guestname`, `product`, `phone`, `address`, `email`) VALUES (@gn, @pro, @phone, @address, @email)", connect.getconnection);

            command.Parameters.Add("@gn",MySqlDbType.VarChar).Value = gn;
            command.Parameters.Add("@pro", MySqlDbType.VarChar).Value = pro;
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@oDate", MySqlDbType.VarChar).Value = oDate;


            connect.openConnect();
            if(command.ExecuteNonQuery() ==1)
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
        public DataTable getDispathlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `makeorder`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
    }
}
