using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        private int dataPagamento;
        public int fkIdUsuario;

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
        public int DataPagamento
        {
            get { return dataPagamento; }
            set {  dataPagamento = value; }
        }
        public int FkIdUsuario
        {
            get { return fkIdUsuario; }
            set { fkIdUsuario = value; }
        }

        public bool CadastrarExtrato()
        {
            try
            {
                using (MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string insert = "INSERT INTO extrato (idExtrato, saldoExtrato, nomePagante, nomeReceber, motivo, dataPagamento, fkIdUsuario) VALUES (@IdExtrato, @SaldoExtrato, @NomePagante, @NomeReceber, @Motivo, @DataPagamento, @fkIdUsuario);";

                    using (MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@IdExtrato", IdExtrato);
                        comandoSql.Parameters.AddWithValue("@SaldoExtrato", SaldoExtrato);
                        comandoSql.Parameters.AddWithValue("@NomePagante", NomePagante);
                        comandoSql.Parameters.AddWithValue("@NomeReceber", NomeReceber);
                        comandoSql.Parameters.AddWithValue("Motivo", Motivo);
                        comandoSql.Parameters.AddWithValue("DataPagamento", DataPagamento);
                        comandoSql.Parameters.AddWithValue("FkIdUsuario", FkIdUsuario);

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
    }
}
