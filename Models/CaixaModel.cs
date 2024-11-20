using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        private int saldoCaixa;
        private int fkIdUsuario;
        private int fkIdCaixa;

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
        public int SaldoCaixa
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

        public bool CadastrarCaixa()
        {
            try
            {
                using(MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor))
                {
                    MysqlConexaoBanco.Open();

                    string insert = $"INSERT INTO caixa (idCaixa, nomeCaixa) VALUES (@idCaixa, @nomeCaixa);" +
                                    $"INSERT INTO usuarioCaixa (fkIdUsuario, fkIdCaixa) VALUES (@fkIdUsuario, @fkIdCaixa);";

                    using(MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@idCaixa", IdCaixa);
                        comandoSql.Parameters.AddWithValue("@nomeCaixa", nomeCaixa);
                        comandoSql.Parameters.AddWithValue("@fkIdUsuario", FkIdUsuario);
                        comandoSql.Parameters.AddWithValue("@fkIdCaixa", FkIdCaixa);

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
    }
}
