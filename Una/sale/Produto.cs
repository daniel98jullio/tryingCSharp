using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Una.sale
{
    public class ProdutoEntity
    {
        public int id { get; set; }
        public int codBar { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public float vrUnit { get; set; }
    }

    public class Produto
    {
        private Connection connection;

        private const string SELECT_ALL = "SELECT * FROM PRODUTO;";
        private const string SELECT_COD_BAR = "SELECT * FROM PRODUTO WHERE COD_BAR = @0;";
        private const string SELECT_NOME = "SELECT * FROM PRODUTO WHERE NOME = @0;";
        private const string INSERT = "INSERT INTO PRODUTO (COD_BAR, NOME, DESCRICAO, VR_UNIT) VALUES (@0, @1, @2, @3);";
        private const string UPDATE = "UPDATE PRODUTO SET NOME = @0, DESCRICAO = @1, VR_UNIT = @2 WHERE ID = @3;";
        private const string DELETE = "DELETE FROM PRODUTO WHERE ID = @0;";

        public Produto(Connection conn)
        {
            this.connection = conn;
        }

        public List<ProdutoEntity> busca()
        {
            this.connection.openConnection();
            List<ProdutoEntity> produtoList = new List<ProdutoEntity>();
            MySqlCommand cmd = new MySqlCommand(SELECT_ALL, this.connection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ProdutoEntity entity = new ProdutoEntity();
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.nome = rdr.GetString(rdr.GetOrdinal("NOME"));
                entity.descricao = rdr.GetString(rdr.GetOrdinal("DESCRICAO"));
                entity.vrUnit = rdr.GetFloat(rdr.GetOrdinal("VR_UNIT"));
                produtoList.Add(entity);
            }
            this.connection.closeConnection();
            return produtoList;
        }

        public ProdutoEntity busca(int codBar)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(SELECT_COD_BAR, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", codBar));
            MySqlDataReader rdr = cmd.ExecuteReader();
            ProdutoEntity entity = new ProdutoEntity();
            while (rdr.Read())
            {
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.nome = rdr.GetString(rdr.GetOrdinal("NOME"));
                entity.descricao = rdr.GetString(rdr.GetOrdinal("DESCRICAO"));
                entity.vrUnit = rdr.GetFloat(rdr.GetOrdinal("VR_UNIT"));
            }
            this.connection.closeConnection();
            return entity;
        }

		public List<ProdutoEntity> busca(string nome)
		{
            this.connection.openConnection();
            List<ProdutoEntity> produtoList = new List<ProdutoEntity>();
            MySqlCommand cmd = new MySqlCommand(SELECT_NOME, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", nome));
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ProdutoEntity entity = new ProdutoEntity();
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.nome = rdr.GetString(rdr.GetOrdinal("NOME"));
                entity.descricao = rdr.GetString(rdr.GetOrdinal("DESCRICAO"));
                entity.vrUnit = rdr.GetFloat(rdr.GetOrdinal("VR_UNIT"));
                produtoList.Add(entity);
            }
            this.connection.closeConnection();
            return produtoList;
        }

        public void insert(int codBar, string nome, string descricao, double vrUnit)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", codBar));
            cmd.Parameters.Add(new MySqlParameter("1", nome));
            cmd.Parameters.Add(new MySqlParameter("2", descricao));
            cmd.Parameters.Add(new MySqlParameter("3", vrUnit));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

		public void update(string nome, string descricao, double vrUnit, int id)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", nome));
            cmd.Parameters.Add(new MySqlParameter("1", descricao));
            cmd.Parameters.Add(new MySqlParameter("2", vrUnit));
            cmd.Parameters.Add(new MySqlParameter("3", id));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

		public void delete(int id)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", id));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }
    }
}
