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
    internal class ExtratoModel
    {
        private int idExtrato;
        private decimal saldoExtrato;
        private string nomePagante;
        private string nomeReceber;
        private string motivo;
        private DateTime dataPagamento;
        private int fkIdPagante;
        private int fkIdReceber;

        public int IdExtrato
        {
            get { return idExtrato; }
            set { idExtrato = value; }
        }
        public decimal SaldoExtrato
        {
            get { return saldoExtrato; }
            set { saldoExtrato = value; }
        }
        public string NomePagante
        {
            get { return nomePagante; }
            set { nomePagante = value; }
        }
        public string NomeReceber
        {
            get { return nomeReceber; }
            set { nomeReceber = value; }
        }
        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }
        public DateTime DataPagamento
        {
            get { return dataPagamento; }
            set {  dataPagamento = value; }
        }
        public int FkIdPagante
        {
            get { return fkIdPagante; }
            set { fkIdPagante = value; }
        }
        public int FkIdReceber
        {
            get { return fkIdReceber; }
            set { fkIdReceber = value; }
        }

        public bool CadastrarExtrato()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string insert = "INSERT INTO extrato (idExtrato, saldoExtrato, nomePagante, nomeReceber, motivo, dataPagamento, fkIdPagante, fkIdReceber) VALUES (@IdExtrato, @SaldoExtrato, @NomePagante, @NomeReceber, @Motivo, @DataPagamento, @FkIdPagante, @FkIdReceber);";

                    using (MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@IdExtrato", IdExtrato);
                        comandoSql.Parameters.AddWithValue("@SaldoExtrato", SaldoExtrato);
                        comandoSql.Parameters.AddWithValue("@NomePagante", NomePagante);
                        comandoSql.Parameters.AddWithValue("@NomeReceber", NomeReceber);
                        comandoSql.Parameters.AddWithValue("@Motivo", Motivo);
                        comandoSql.Parameters.AddWithValue("@DataPagamento", DataPagamento);
                        comandoSql.Parameters.AddWithValue("@FkIdPagante", FkIdPagante);
                        comandoSql.Parameters.AddWithValue("@FkIdReceber", FkIdReceber);

                        comandoSql.ExecuteNonQuery();

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método cadastrarExtrato: " + ex.Message);
                return false;
            }
        }

        public MySqlDataReader LerUsuario()
        {
            MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
            try
            {
                MysqlConexaoBanco.Open();

                string select = "SELECT idUsuario, nome, saldo FROM usuario WHERE idUsuario = @FkIdReceber;";

                MySqlCommand comandoSql = new MySqlCommand(select, MysqlConexaoBanco);
                comandoSql.Parameters.AddWithValue("@FkIdReceber", FkIdReceber);

                return comandoSql.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método lerUsuario: " + ex.Message);
                return null;
            }
        }

        public MySqlDataReader LerExtrato()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string select = $"select idExtrato, saldoExtrato, completa, hora from tarefas where fkIdPagante = '{fkIdPagante}' OR fkIdReceber = '{fkIdReceber}';";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;

                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método localizarTarefa: " + ex.Message);
                return null;
            }
        }
    }
}
