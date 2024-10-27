using Banco_MVP_MySQL_.Forms;
using Banco_MVP_MySQL_.Models;
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
        private readonly PrincipalForm view;
        private readonly PrincipalModel model;

        public PrincipalP(PrincipalForm view, PrincipalModel model)
        {
            this.view = view;
            this.model = model;
        }

        public bool editarNome()
        {
            model.Id = view.idUsuario;
            model.Nome = view.txtEditarNome.Text;
            model.Senha = view.txtSenhaEditar.Text;
            if (!string.IsNullOrEmpty(model.Nome) && !string.IsNullOrEmpty(model.Senha))
            {
                if (model.confirmarSenha())
                {
                    if (model.mudarNome())
                    {
                        view.nomeUsuario = view.txtEditarNome.Text;
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
            model.Id = view.idUsuario;
            model.Senha = view.txtSenhaEditar.Text;
            if (!string.IsNullOrEmpty(model.Senha))
            {
                if(view.txtNovaSenha.Text == view.txtConfirmarNovaSenha.Text)
                {
                    if (model.confirmarSenha())
                    {
                        if (model.mudarSenha(view.txtNovaSenha.Text))
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
    }
}
