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

                    string insert = "INSERT INTO caixa (idCaixa, nomeCaixa) VALUES (@idCaixa, @nomeCaixa);";

                    using(MySqlCommand comandoSql = new MySqlCommand(insert, MysqlConexaoBanco))
                    {
                        comandoSql.Parameters.AddWithValue("@idCaixa", IdCaixa);
                        comandoSql.Parameters.AddWithValue("@nomeCaixa", nomeCaixa);

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
    }
}
