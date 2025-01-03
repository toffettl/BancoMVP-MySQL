﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Models
{
    internal class PrincipalModel
    {
        private int id;
        private string nome;
        private string senha;
        private decimal saldo;
        private decimal novoSaldo;

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
        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        public decimal NovoSaldo
        {
            get { return novoSaldo; }
            set { novoSaldo = value; }
        }

        #region Alteração de nome e senha e apagar user
        public bool MudarNome()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();
                    string update = "update usuario set nome = @Nome where idUsuario = @Id;";
                    MySqlCommand comandoSql = new MySqlCommand(update, MysqlConexaoBanco);
                    comandoSql.Parameters.AddWithValue("@Nome", Nome);
                    comandoSql.Parameters.AddWithValue("@Id", Id);

                    comandoSql.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método mudarNome: " + ex.Message);
                return false;
            }
        }

        public bool MudarSenha(string novaSenha)
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();
                    string update = "update usuario set senha = @NovaSenha where idUsuario = @Id;";
                    MySqlCommand comandoSql = new MySqlCommand(update, MysqlConexaoBanco);
                    comandoSql.Parameters.AddWithValue("@NovaSenha", novaSenha);
                    comandoSql.Parameters.AddWithValue("@Id", Id);

                    comandoSql.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método mudarNome: " + ex.Message);
                return false;
            }
        }

        public bool ConfirmarSenha()
        {
            try
            {
                using (MySqlConnection mysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    mysqlConexaoBanco.Open();
                    string query = "SELECT COUNT(*) FROM usuario WHERE idUsuario = @Id AND senha = @Senha";
                    MySqlCommand comandoSql = new MySqlCommand(query, mysqlConexaoBanco);
                    comandoSql.Parameters.AddWithValue("@Id", Id);
                    comandoSql.Parameters.AddWithValue("@Senha", Senha);

                    int count = Convert.ToInt32(comandoSql.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método ConfirmarSenha: " + ex.Message);
                return false;
            }
        }
        public bool ExcluirUsuario()
        {
            try
            {
                using(MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();
                    string delete = "delete from usuario where idUsuario = @Id;";
                    MySqlCommand comandoSql = new MySqlCommand(delete, MysqlConexaoBanco);
                    comandoSql.Parameters.AddWithValue("@Id", Id);

                    comandoSql.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método excluirUsuario: " + ex.Message);
                return false;
            }
        }
        #endregion

        #region Metodos de tranferencia e recebimento
        public MySqlDataReader LerUsuario()
        {
            MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
            try
            {
                MysqlConexaoBanco.Open();

                string select = "SELECT idUsuario, nome, saldo FROM usuario WHERE idUsuario = @Id;";

                MySqlCommand comandoSql = new MySqlCommand(select, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@Id", Id);

                return comandoSql.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método lerUsuario: " + ex.Message);
                return null;
            }
        }

        public bool AtualizarSaldo()
        {
            MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
            try
            {
                MysqlConexaoBanco.Open();

                string update = "update usuario set saldo = @NovoSaldo where idUsuario = @Id;";

                MySqlCommand comandoSql = new MySqlCommand(update, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@NovoSaldo", NovoSaldo);
                comandoSql.Parameters.AddWithValue("@Id", Id);


                comandoSql.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método transferirValor: " + ex);
                return false;
            }
        }
    }
        #endregion
}
