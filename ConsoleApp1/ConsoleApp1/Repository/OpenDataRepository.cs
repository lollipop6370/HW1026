using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1.Repository
{
    class OpenDataRepository
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yuli\Desktop\HW1026-master\ConsoleApp1\ConsoleApp1\AppData\Database1.mdf;Integrated Security=True";
            }
            set => throw new NotImplementedException();
        }

        public void Insert(OpenData item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"INSERT INTO OpenData(REGI_ID,FACT_NAME,FACT_ADDR,BNAME,ADDR_X,ADDR_Y)
                                                  VALUES              ('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')
                                                 ", newItem.REGI_ID, newItem.FACT_NAME, newItem.FACT_ADDR, newItem.BNAME, newItem.ADDR_X, newItem.ADDR_Y);

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
