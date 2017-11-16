﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Una.sale
{
    public class EstoqueEntity
    {
        public int id { get; set; }
        public float quant { get; set; }
        public int codBar { get; set; }
        public char idEntrSaid { get; set; }
    }

    public class Estoque
    {
        private Connection connection;

        private const string SELECT_ALL = "SELECT * FROM ESTOQUE;";
        private const string SELECT_COD_BAR = "SELECT * FROM ESTOQUE WHERE COD_BAR = @0;";
        private const string INSERT = "INSERT INTO ESTOQUE (COD_BAR, ID_ENTR_SAID, QUANT) VALUES (@0, @1, @2);";
        private const string UPDATE = "UPDATE ESTOQUE SET QUANT = @0 WHERE ID = @1;";
        private const string DELETE = "DELETE FROM ESTOQUE WHERE ID = @0;";

        public Estoque(Connection conn)
        {
            this.connection = conn;
        }

        public List<EstoqueEntity> busca()
        {
            this.connection.openConnection();
            List<EstoqueEntity> estoqueList = new List<EstoqueEntity>();
            MySqlCommand cmd = new MySqlCommand(SELECT_ALL, this.connection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                EstoqueEntity entity = new EstoqueEntity();
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.idEntrSaid = rdr.GetChar(rdr.GetOrdinal("ID_ENTR_SAID"));
                entity.quant = rdr.GetFloat(rdr.GetOrdinal("QUANT"));
                estoqueList.Add(entity);
            }
            this.connection.closeConnection();
            return estoqueList;
        }

        public EstoqueEntity busca(int codBar)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(SELECT_COD_BAR, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", codBar));
            MySqlDataReader rdr = cmd.ExecuteReader();
            EstoqueEntity entity = new EstoqueEntity();
            while (rdr.Read())
            {
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.codBar = rdr.GetInt32(rdr.GetOrdinal("COD_BAR"));
                entity.idEntrSaid = rdr.GetChar(rdr.GetOrdinal("ID_ENTR_SAID"));
                entity.quant = rdr.GetFloat(rdr.GetOrdinal("QUANT"));
            }
            this.connection.closeConnection();
            return entity;
        }

		public void insert(int codBar, double quant, char idEntrSaid)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", codBar));
            cmd.Parameters.Add(new MySqlParameter("1", idEntrSaid));
            cmd.Parameters.Add(new MySqlParameter("2", quant));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

		public void update(int id, double quant)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(UPDATE, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", quant));
            cmd.Parameters.Add(new MySqlParameter("1", id));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

		public void delete(int id)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(DELETE, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", id));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

        public bool Validar_Quantidade_Estoque(int codBar, double qtDesej) {
            return false;
        }

        public void Atualizar_Estoque(int codBar, double qtProd) {
            
        }

        public void relatorioQtEstoque() {
            
        }
    }
}
