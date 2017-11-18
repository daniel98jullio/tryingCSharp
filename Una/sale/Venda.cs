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

    public class VendaProdutoEntity
    {
        public int id { get; set; }
        public int codBar { get; set; }
        public string nome { get; set; }
        public double quant { get; set; }
        public double vrUnit { get; set; }
        public double vrDesc { get; set; }
        public double vrTot { get; set; }
    }

    public class Venda
    {
        private Connection connection;

        private const string SELECT_ALL = "SELECT * FROM VENDA;";
        private const string SELECT_COD_BAR = "SELECT * FROM VENDA WHERE COD_BAR = @0;";
        private const string SELECT_MAX_ID = "SELECT MAX(ID) AS ID FROM VENDA;";
        private const string INSERT = "INSERT INTO VENDA (ID, COD_BAR, QUANT, VR_DESC, VR_TOT) VALUES (@0, @1, @2, @3, @4);";
        private const string UPDATE = "UPDATE VENDA SET QUANT = @0 WHERE ID = @1;";
        private const string DELETE = "DELETE FROM VENDA WHERE ID = @0;";
        private const string REPORT_CUMPOM_FISCAL = "SELECT V.ID AS ID_VENDA, V.COD_BAR, P.NOME, V.QUANT, P.VR_UNIT, V.VR_DESC, V.VR_TOT FROM VENDA V, PRODUTO P WHERE V.COD_BAR = P.COD_BAR AND V.ID = @0 ORDER BY V.ID;";

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

        public void insert(int id, int codBar, double qt, double vrDesc, double vrTot) {
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", id));
            cmd.Parameters.Add(new MySqlParameter("1", codBar));
            cmd.Parameters.Add(new MySqlParameter("2", Math.Round(qt, 2)));
            cmd.Parameters.Add(new MySqlParameter("3", Math.Round(vrDesc, 2)));
            cmd.Parameters.Add(new MySqlParameter("4", Math.Round(vrTot, 2)));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

        public void update(double qt, int id) {
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", Math.Round(qt, 2)));
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

        public int nextId()
        {
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(SELECT_MAX_ID, this.connection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            VendaEntity entity = new VendaEntity();
            while (rdr.Read())
            {
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
            }
            this.connection.closeConnection();

            return entity.id + 1;
        }

        public List<VendaProdutoEntity> cupomFiscal(int idVenda)
        {
            this.connection.openConnection();
            List<VendaProdutoEntity> vendaList = new List<VendaProdutoEntity>();
            MySqlCommand cmd = new MySqlCommand(REPORT_CUMPOM_FISCAL, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", idVenda));
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                VendaProdutoEntity entity = new VendaProdutoEntity();
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID_VENDA"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.nome = rdr.GetString(rdr.GetOrdinal("NOME"));
                entity.quant = rdr.GetDouble(rdr.GetOrdinal("QUANT"));
                entity.vrUnit = rdr.GetDouble(rdr.GetOrdinal("VR_UNIT"));
                entity.vrDesc = rdr.GetDouble(rdr.GetOrdinal("VR_DESC"));
                entity.vrTot = rdr.GetDouble(rdr.GetOrdinal("VR_TOT"));
                vendaList.Add(entity);
            }
            this.connection.closeConnection();
            return vendaList;
        }
    }
}
