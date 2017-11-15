using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Una.sale
{
    public class MysqlConnection1
    {
        public MysqlConnection1()
        {
            MySqlConnection bdConn = new MySqlConnection("server=localhost;database=TEST;uid=root");
            bdConn.Open();

			MySqlCommand commS = new MySqlCommand("INSERT INTO PAH VALUES('teste1')", bdConn);
			commS.BeginExecuteNonQuery();
		}
    }
}
