using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Banco_MVP_MySQL_.Models
{
    internal class CadastroUsuarioM
    {
        private int id;
        private string nome;
        private string senha;
        private int saldo;

        public int Id
        {
            get { return id; }
            set { id = value; }

        }
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
        public int Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public bool cadastrarUsuario()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string insert = "INSERT INTO usuario (nome, senha, saldo) VALUES (@Nome, @Senha, @Saldo);";

                    using (MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@Nome", Nome);
                        comandoSql.Parameters.AddWithValue("@Senha", Senha);
                        comandoSql.Parameters.AddWithValue("@Saldo", Saldo = 0);

                        comandoSql.ExecuteNonQuery();

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método cadastrarUsuario: " + ex.Message);
                return false;
            }
        }

        public bool nomeUsuarioExiste()
        {
            using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
            {
                MysqlConexaoBanco.Open();

                string query = "SELECT COUNT(*) FROM usuario WHERE nome = @Nome";

                MySqlCommand comandoSql = new MySqlCommand(query, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@Nome", Nome);

                int count = Convert.ToInt32(comandoSql.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool adicionarSaldo()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string update = "update usuario set saldo = @Saldo where id = @Id;";
                    using (MySqlCommand comandoSql = new MySqlCommand(update, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@Saldo", Saldo);
                        comandoSql.Parameters.AddWithValue("@Id", Id);

                        comandoSql.ExecuteNonQuery();

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método adicionarSaldo: " + ex.Message);
                return false;
            }
        }
    }
}