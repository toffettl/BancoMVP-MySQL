using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Models
{
    internal class CaixaModel
    {
        private int idCaixa;
        private string nomeCaixa;
        private decimal saldoCaixa;
        private int fkIdUsuario;
        private int fkIdCaixa;
        private decimal novoSaldo;
        private decimal novoSaldoCaixa;

        public int IdCaixa
        {
            get { return idCaixa; }
            set { idCaixa = value; }
        }
        public string NomeCaixa
        {
            get { return nomeCaixa; }
            set { nomeCaixa = value; }
        }
        public decimal SaldoCaixa
        {
            get { return saldoCaixa; }
            set { saldoCaixa = value; }
        }
        public int FkIdUsuario
        {
            get { return fkIdUsuario; }
            set {  fkIdUsuario = value; }
        }
        public int FkIdCaixa
        {
            get { return fkIdCaixa; }
            set { fkIdCaixa = value; }
        }
        public decimal NovoSaldo
        {
            get { return novoSaldo; }
            set { novoSaldo = value; }
        }
        public decimal NovoSaldoCaixa
        {
            get { return novoSaldoCaixa; }
            set { novoSaldoCaixa = value; }
        }

        public bool CadastrarCaixa()
        {
            try
            {
                using(MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string insert = "INSERT INTO caixa (idCaixa, nomeCaixa, saldoCaixa) VALUES (@idCaixa, @nomeCaixa, @saldoCaixa);";

                    using(MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@idCaixa", IdCaixa);
                        comandoSql.Parameters.AddWithValue("@nomeCaixa", nomeCaixa);
                        comandoSql.Parameters.AddWithValue("@saldoCaixa", 0);/

                        comandoSql.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no método: CadastrarCaixa" + ex.Message);
                return false;
            }
        }
        public bool CadastrarPermissao()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string insert = "INSERT INTO usuarioCaixa (fkIdUsuario, fkIdCaixa) VALUES (@fkIdUsuario, @fkIdCaixa);";

                    using (MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@fkIdUsuario", FkIdUsuario);
                        comandoSql.Parameters.AddWithValue("@fkIdCaixa", fkIdCaixa);

                        comandoSql.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no método: CadastrarPermissao" + ex.Message);
                return false;
            }
        }

        public MySqlDataReader VerificarPermissao()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string select = @"
            SELECT c.nomeCaixa, c.saldoCaixa, c.idCaixa
            FROM usuarioCaixa uc
            JOIN caixa c ON uc.fkIdCaixa = c.idCaixa
            WHERE uc.fkIdUsuario = @fkIdUsuario";

                MySqlCommand comandoSql = new MySqlCommand(select, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@fkIdUsuario", FkIdUsuario);

                return comandoSql.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no método VerificarPermissao: " + ex.Message);
                return null;
            }
        }

        public MySqlDataReader ListarCaixasPorUsuario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string select = @"
            SELECT c.idCaixa, c.nomeCaixa, c.saldoCaixa
            FROM caixa c
            JOIN usuarioCaixa uc ON c.idCaixa = uc.fkIdCaixa
            WHERE uc.fkIdUsuario = @fkIdUsuario";

                MySqlCommand comandoSql = new MySqlCommand(select, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@fkIdUsuario", FkIdUsuario);

                return comandoSql.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no método ListarCaixasPorUsuario: " + ex.Message);
                return null;
            }
        }

        public bool AddSaldo()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string insert = "UPDATE caixa SET saldoCaixa = @saldoCaixa WHERE idCaixa = @idCaixa;";

                    using (MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@saldoCaixa", saldoCaixa);
                        comandoSql.Parameters.AddWithValue("@idCaixa", idCaixa);

                        comandoSql.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no método: AddSaldo" + ex.Message);
                return false;
            }
        }

        public bool AtualizarSaldo()
        {
            MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
            try
            {
                MysqlConexaoBanco.Open();

                string update = "update usuario set saldo = @NovoSaldo where idUsuario = @idUsuario;";

                MySqlCommand comandoSql = new MySqlCommand(update, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@NovoSaldo", NovoSaldo);
                comandoSql.Parameters.AddWithValue("@idUsuario", fkIdUsuario);


                comandoSql.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método transferirValor: " + ex);
                return false;
            }
        }

        public MySqlDataReader LerUsuario()
        {
            MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
            try
            {
                MysqlConexaoBanco.Open();

                string select = "SELECT saldo FROM usuario WHERE idUsuario = @idUsuario;";

                MySqlCommand comandoSql = new MySqlCommand(select, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@idUsuario", fkIdUsuario);

                return comandoSql.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método lerUsuario: " + ex.Message);
                return null;
            }
        }

        public MySqlDataReader LerCaixa()
        {
            MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
            try
            {
                MysqlConexaoBanco.Open();

                string select = "SELECT saldoCaixa FROM caixa WHERE idCaixa = @idCaixa;";

                MySqlCommand comandoSql = new MySqlCommand(select, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@idCaixa", idCaixa);

                return comandoSql.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método lerUsuario: " + ex.Message);
                return null;
            }
        }

        public bool AtualizarCaixa()
        {
            MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
            try
            {
                MysqlConexaoBanco.Open();

                string update = "update caixa set saldoCaixa = @NovoSaldoCaixa where idCaixa = @idCaixa;";

                MySqlCommand comandoSql = new MySqlCommand(update, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@NovoSaldoCaixa", NovoSaldoCaixa);
                comandoSql.Parameters.AddWithValue("@idCaixa", idCaixa);


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
}
