using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Una.sale
{
    public class Connection
    {
        private const string CONNECTION = "server=localhost;database=PAH;uid=root;pwd=root";
        public MySqlConnection conn;

        public Connection()
        {
            this.conn = new MySqlConnection(CONNECTION);
        }

        public void openConnection()
        {
            this.conn.Open();
        }

        public void closeConnection()
        {
            this.conn.Close();
            this.conn.Dispose();
        }

        public void selectExample()
        {
            string stm = "SELECT * FROM PRODUTO";
            MySqlCommand cmd = new MySqlCommand(stm, this.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetInt32(0) + " : "
                    + rdr.GetString(1) + " : "
                    + rdr.GetString(2) + " : "
                    + rdr.GetString(rdr.GetOrdinal("ID")) + " : "
                );
            }
        }

        public void insertExample()
        {
            string stm = "INSERT INTO PRODUTO (COD_BAR, NOME, VR_UNIT, DESCRICAO) VALUES (@0, @1, @2, @3)";
            MySqlCommand cmd = new MySqlCommand(stm, this.conn);
            cmd.Parameters.Add(new MySqlParameter("0", 5));
            cmd.Parameters.Add(new MySqlParameter("1", "TESTE INSERT"));
            cmd.Parameters.Add(new MySqlParameter("2", 5.55));
            cmd.Parameters.Add(new MySqlParameter("3", "tes"));
            cmd.ExecuteNonQuery();
        }
    }
}
