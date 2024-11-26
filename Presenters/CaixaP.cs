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

        public void AddSaldo()
        {
            model.IdCaixa = view.IdCaixa;
            using (MySqlDataReader reader = model.LerCaixa())
            {
                if (reader.Read())
                {
                    int saldoAtual = Convert.ToInt32(reader["saldoCaixa"]);
                    model.NovoSaldoCaixa = saldoAtual + view.SaldoCaixa;
                    if (model.AtualizarCaixa())
                    {
                        MessageBox.Show("Saldo adicionado com sucesso!");
                        AtualizarSaldo();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar saldo!");
                    }
                }
            }
        }

        public void AtualizarSaldo()
        {
            model.FkIdUsuario = idUsuario;
            using (MySqlDataReader reader = model.LerUsuario())
            {
                if (reader.Read())
                {
                    decimal saldoAtual = Convert.ToDecimal(reader["saldo"]);
                    model.NovoSaldo = saldoAtual - view.SaldoCaixa;
                    if (model.AtualizarSaldo())
                    {
                        MessageBox.Show("Saldo adicionado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar saldo!");
                    }
                }
            }
        }
    }
}
