﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace afterservice
{
    class DBconnect
    {
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=afterservice");

            public MySqlConnection getconnection
        { 
            get
            { 
                return connect;
                
                
                
                
                }
            }
            public void openConnect()
        { 
            if(connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
            }
            public void closeConnect()
        {
            if(connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }
      }
    }

