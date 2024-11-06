using Banco_MVP_MySQL_.Forms;
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
    internal class PrincipalP
    {
        private readonly IPrincipalV view;
        private readonly PrincipalModel model;
        private readonly ExtratoModel modelExtrato;
        public int idUsuario;

        public PrincipalP(IPrincipalV view, PrincipalModel model, ExtratoModel modelextrato)
        {
            this.view = view;
            this.model = model;
            this.modelExtrato = modelextrato;
        }


        #region Editar senha e nome, apagar user
        public bool EditarNome()
        {
            model.Id = idUsuario;
            model.Nome = view.Nome;
            model.Senha = view.Senha;
            if (!string.IsNullOrEmpty(model.Nome) && !string.IsNullOrEmpty(model.Senha))
            {
                if (model.ConfirmarSenha())
                {
                    if (model.MudarNome())
                    {
                       return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Senha incorreta!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Favor, preencha todos os campos corretamente!");
                return false;
            }
        }

        public bool EditarSenha()
        {
            model.Id = idUsuario;
            model.Senha = view.Senha;
            if (!string.IsNullOrEmpty(model.Senha))
            {
                if(view.NovaSenha == view.ConfirmarNovaSenha)
                {
                    if (model.ConfirmarSenha())
                    {
                        if (model.MudarSenha(view.NovaSenha))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Senha incorreta!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Confirmação de senha errada!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Favor, preencha todos os campos corretamente!");
                return false;
            }
        }
        #endregion

        public void LerUsuario()
        {
            model.Id = idUsuario;

            using (MySqlDataReader reader = model.LerUsuario())
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        view.Saldo = Convert.ToDecimal(reader["saldo"]);
                        view.Nome = Convert.ToString(reader["nome"]);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível ler os dados do usuário.");
                }
            }
        }

        public bool tranferencia()
        {
            model.Id = idUsuario;
            model.NovoSaldo = view.Saldo - view.ValorTranferencia;
            modelExtrato.SaldoExtrato = view.ValorTranferencia;
            modelExtrato.NomePagante = view.Nome;
            modelExtrato.FkIdUsuario = idUsuario;
            if (view.Saldo >= view.ValorTranferencia)
            {
                if (model.AtualizarSaldo())
                {
                    view.Saldo = model.NovoSaldo;
                    if (modelExtrato.CadastrarExtrato())
                    {
                        MessageBox.Show("Pagamento feito com sucesso!");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Valo da tranferência inválido!");
                return false;
            }
        }
        public bool receber()
        {
            model.Id = view.idTranferencia;

            using (MySqlDataReader reader = model.LerUsuario())
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        model.NovoSaldo = Convert.ToDecimal(reader["saldo"]) + view.ValorTranferencia;
                        if (model.AtualizarSaldo())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar saldo!");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao ler saldo!");
                    return false;
                }
            }
        }
    }
}
