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
        public int idUsuario;

        public PrincipalP(IPrincipalV view, PrincipalModel model)
        {
            this.view = view;
            this.model = model;
        }


        #region Editar senha e nome, apagar user
        public bool editarNome()
        {
            model.Id = idUsuario;
            model.Nome = view.Nome;
            model.Senha = view.Senha;
            if (!string.IsNullOrEmpty(model.Nome) && !string.IsNullOrEmpty(model.Senha))
            {
                if (model.confirmarSenha())
                {
                    if (model.mudarNome())
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

        public bool editarSenha()
        {
            model.Id = idUsuario;
            model.Senha = view.Senha;
            if (!string.IsNullOrEmpty(model.Senha))
            {
                if(view.NovaSenha == view.ConfirmarNovaSenha)
                {
                    if (model.confirmarSenha())
                    {
                        if (model.mudarSenha(view.NovaSenha))
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

        public void receberSaldo()
        {
            model.Id = idUsuario;

            using (MySqlDataReader reader = model.lerUsuario())
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        view.Saldo = Convert.ToInt32(reader["saldo"]);
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
            if (model.tranferir())
            {
                MessageBox.Show("Tranfêrencia feita com sucesso!");
                return true;
            }
            else
            {
                MessageBox.Show("Erro ao tranferir!");
                return false;
            }
        }

    }
}
