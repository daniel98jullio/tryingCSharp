using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Una.sale
{
    public class MysqlConnection
    {
        public MysqlConnection()
        {
            var mDataSet = new DataSet();
            MySqlConnection bdConn = new MySqlConnection("server=localhost;database=PAH;uid=root;pwd=root");
            bdConn.Open();

            /*MySqlCommand a = bdConn.CreateCommand();
            a.CommandText = "SELECT id FROM PRODUTO;";

            MySqlDataReader reader = a.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.ToString());
            }*/

            string stm = "SELECT * FROM PRODUTO";
            MySqlCommand cmd = new MySqlCommand(stm, bdConn);
            string version = Convert.ToString(cmd.ExecuteScalar());
            Console.WriteLine("MySQL version : {0}", version);

            /*MySqlDataReader rdr = cmd.ExecuteReader();
            List<string>items=new List<string>();

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0) + " : "
                    + rdr.GetString(1) + " : "
                    + rdr.GetString(2) + " : "
                    objReader.GetString(objReader.GetOrdinal("Column1"));
                );
                list.add
            }*/

            var ds = new DataSet();
            var da = new MySqlDataAdapter(stm, bdConn);
            da.Fill(ds, "PRODUTO");
            var c = ds.Tables["PRODUTO"];

        }
    }
}
