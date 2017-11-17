using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Una.sale
{
    public class VendaEntity
    {
        public int id { get; set; }
        public int codBar { get; set; }
        public double quant { get; set; }
        public double vrDesc { get; set; }
        public double vrTot { get; set; }
    }

    public class Venda
    {
        private Connection connection;

        private const string SELECT_ALL = "SELECT * FROM VENDA;";
        private const string SELECT_COD_BAR = "SELECT * FROM VENDA WHERE COD_BAR = @0;";
        private const string INSERT = "INSERT INTO VENDA (COD_BAR, QUANT, VR_DESC, VR_TOT) VALUES (@0, @1, @2, @3);";
        private const string UPDATE = "UPDATE VENDA SET QUANT = @0 WHERE ID = @1;";
        private const string DELETE = "DELETE FROM VENDA WHERE ID = @0;";

        public Venda(Connection conn)
        {
            this.connection = conn;
        }

        public List<VendaEntity> busca()
        {
            this.connection.openConnection();
            List<VendaEntity> vendaList = new List<VendaEntity>();
            MySqlCommand cmd = new MySqlCommand(SELECT_ALL, this.connection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                VendaEntity entity = new VendaEntity();
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.quant = rdr.GetDouble(rdr.GetOrdinal("QUANT"));
                entity.vrDesc = rdr.GetDouble(rdr.GetOrdinal("VR_DESC"));
                entity.vrTot = rdr.GetDouble(rdr.GetOrdinal("VR_TOT"));
                vendaList.Add(entity);
            }
            this.connection.closeConnection();
            return vendaList;
        }

        public List<VendaEntity> busca(int codBar) {
            this.connection.openConnection();
            List<VendaEntity> vendaList = new List<VendaEntity>();
            MySqlCommand cmd = new MySqlCommand(SELECT_COD_BAR, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", codBar));
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                VendaEntity entity = new VendaEntity();
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.quant = rdr.GetDouble(rdr.GetOrdinal("QUANT"));
                entity.vrDesc = rdr.GetDouble(rdr.GetOrdinal("VR_DESC"));
                entity.vrTot = rdr.GetDouble(rdr.GetOrdinal("VR_TOT"));
                vendaList.Add(entity);
            }
            this.connection.closeConnection();
            return vendaList;
        }

        public void insert(int codBar, double qt, double vrDesc, double vrTot) {
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", codBar));
            cmd.Parameters.Add(new MySqlParameter("1", qt));
            cmd.Parameters.Add(new MySqlParameter("2", vrDesc));
            cmd.Parameters.Add(new MySqlParameter("3", vrTot));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

        public void update(double qt, int id) {
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", qt));
            cmd.Parameters.Add(new MySqlParameter("1", id));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

        public void delete(int id) {
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", id));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }
    }
}
