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
    internal class CaixaP
    {
        private readonly ICaixaV view;
        private readonly CaixaModel model;
        public int idUsuario;

        public CaixaP(ICaixaV view, CaixaModel model)
        {
            this.view = view;
            this.model = model;
        }
        public int GerarId()
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(10000000, 100000000);
            return numeroAleatorio;
        }

        public void CadastrarCaixa()
        {
            int idCaixa = GerarId();
            model.IdCaixa = idCaixa;
            model.NomeCaixa = view.NomeCaixa;
            model.SaldoCaixa = model.SaldoCaixa;
            if (model.CadastrarCaixa())
            {
                model.FkIdUsuario = idUsuario;
                model.FkIdCaixa = idCaixa;
                if (model.CadastrarPermissao())
                {
                    MessageBox.Show("Caixa cadastrada com sucesso!");
                }
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar a toalha!");
            }
        }

        public void ListarCaixa()
        {
            model.FkIdUsuario = idUsuario;
            using (var reader = model.ListarCaixasPorUsuario())
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        view.NomeCaixa = reader.GetString("nomeCaixa");
                        view.IdCaixa = reader.GetInt32("idCaixa");

                        view.ListarCaixa();
                    }
                }
            }
        }

        public void AddPermissao()
        {
            model.FkIdUsuario = view.IdPermissao;
            model.FkIdCaixa = view.IdCaixa;
            if (model.CadastrarPermissao())
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro");
            }
        }
    }
}
