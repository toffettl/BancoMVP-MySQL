using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Models
{
    internal class LoginUsuarioM
    {
        private int id;
        private string nome;
        private string senha;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool confirmarLogin()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();
                    string query = "SELECT COUNT(*) FROM usuario WHERE nome = @Nome AND senha = @Senha";
                    MySqlCommand comandoSql = new MySqlCommand(query, MysqlConexaoBanco);
                    comandoSql.Parameters.AddWithValue("@Nome", Nome);
                    comandoSql.Parameters.AddWithValue("@Senha", Senha);

                    Console.WriteLine($"Nome: {Nome}, Senha: {Senha}");

                    int count = Convert.ToInt32(comandoSql.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return false;
            }
        }

        public int receberId()
        {
            int idUsuario = 0;
            using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
            {
                MysqlConexaoBanco.Open();

                string insert = "SELECT idUsuario FROM usuario WHERE nome = @Nome and senha = @Senha";

                using (MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                {
                    comandoSql.Parameters.AddWithValue("@Nome", Nome);
                    comandoSql.Parameters.AddWithValue("@Senha", Senha);

                    idUsuario = Convert.ToInt32(comandoSql.ExecuteScalar());
                }
            }

            return idUsuario;
        }
    }
}