using Banco_MVP_MySQL_.Models;
using Banco_MVP_MySQL_.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Presenters
{
    internal class ExtratoP
    {
        private readonly IExtratoV view;
        private readonly ExtratoModel model;
        public int idUsuario;
        
        public ExtratoP(IExtratoV view, ExtratoModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void CadastrarExtrato()
        {
            model.FkIdReceber = view.fkIdReceber;
            using (MySqlDataReader reader = model.LerUsuario())
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model.NomeReceber = Convert.ToString(reader["nome"]);
                        model.SaldoExtrato = view.valorExtrato;
                        model.NomePagante = view.nomePagante;
                        model.FkIdPagante = idUsuario;
                        model.DataPagamento = DateTime.Now;
                        model.FkIdReceber = view.fkIdReceber;
                        if (!model.CadastrarExtrato())
                        {
                            MessageBox.Show("Erro ao cadastrar extrato!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível ler os dados do usuário.");
                        Console.Write(view.fkIdReceber);
                    }
                }
                else
                {
                    MessageBox.Show("Erro: reader = null");
                }
            }
        }
    }
}
