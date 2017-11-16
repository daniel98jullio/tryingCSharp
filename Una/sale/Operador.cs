using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Una.sale
{
    public class OperadorEntity
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
    }

    public class Operador
    {
        private Connection connection;

        private const string SELECT_ALL = "SELECT * FROM OPERADOR;";
        private const string SELECT_NOME = "SELECT * FROM OPERADOR WHERE NOME = @0;";
        private const string INSERT = "INSERT INTO OPERADOR (NOME, SENHA) VALUES (@0, @1);";
        private const string UPDATE = "UPDATE OPERADOR SET SENHA = @0 WHERE ID = @1;";
        private const string DELETE = "DELETE FROM OPERADOR WHERE ID = @0;";

        public Operador(Connection conn)
        {
            this.connection = conn;
        }

        public List<OperadorEntity> busca()
        {
            this.connection.openConnection();
            List<OperadorEntity> operadorList = new List<OperadorEntity>();
            MySqlCommand cmd = new MySqlCommand(SELECT_ALL, this.connection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                OperadorEntity entity = new OperadorEntity();
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.nome = rdr.GetString(rdr.GetOrdinal("NOME"));
                entity.senha = rdr.GetString(rdr.GetOrdinal("SENHA"));
                operadorList.Add(entity);
            }
            this.connection.closeConnection();
            return operadorList;
        }

        public OperadorEntity busca(string nome)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(SELECT_NOME, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", nome));
            MySqlDataReader rdr = cmd.ExecuteReader();
            OperadorEntity entity = new OperadorEntity();
            while (rdr.Read())
            {
                entity.id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                entity.nome = rdr.GetString(rdr.GetOrdinal("NOME"));
                entity.senha = rdr.GetString(rdr.GetOrdinal("SENHA"));
            }
            this.connection.closeConnection();
            return entity;
        }

		public void insert(string nome, string senha)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(INSERT, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", nome));
            cmd.Parameters.Add(new MySqlParameter("1", senha));
            cmd.ExecuteNonQuery();
            this.connection.closeConnection();
        }

		public void update(string senha, int id)
		{
            this.connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(UPDATE, this.connection.conn);
            cmd.Parameters.Add(new MySqlParameter("0", senha));
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

        public bool validaUsuario(string name, string senha) {
            return false;
        }
    }
}
