using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Una
{
    public class MysqlConnection
    {
		static void Main(string[] args)
		{
			Console.WriteLine("pah");
			Console.ReadKey();
		}

        public MysqlConnection()
        {
            MySqlConnection bdConn = new MySqlConnection("server=localhost;database=TEST;uid=root");
            bdConn.Open();

			MySqlCommand commS = new MySqlCommand("INSERT INTO PAH VALUES('teste1')", bdConn);
			commS.BeginExecuteNonQuery();
		}



    }
}
