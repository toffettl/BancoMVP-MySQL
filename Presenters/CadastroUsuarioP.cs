using Banco_MVP_MySQL_.Forms.LoginCadastro;
using Banco_MVP_MySQL_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_MVP_MySQL_.Presenters
{
    internal class CadastroUsuarioP
    {
        private readonly ICadastroUsuarioV view;
        private readonly CadastroUsuarioM model;

        public CadastroUsuarioP(ICadastroUsuarioV view, CadastroUsuarioM model)
        {
            this.view = view;
            this.model = model;
        }

        public void CadastrarUsuario()
        {
            model.Nome = view.Nome;
            model.Senha = view.Senha;

            if (!string.IsNullOrWhiteSpace(model.Nome) && !string.IsNullOrWhiteSpace(model.Senha))
            {
                if (!model.nomeUsuarioExiste())
                {
                    if (view.Senha == view.SenhaConfirmada)
                    {
                        model.cadastrarUsuario();
                        view.ExibirMensagem("Usuário cadastrado com sucesso!" + model.Nome);
                    }
                    else
                    {
                        view.ExibirMensagem("Erro ao confirmar a senha!");
                    }
                }
                else
                {
                    view.ExibirMensagem("Este nome de usuário ja esta sendo usado!");
                }
            }
            else
            {
                view.ExibirMensagem("Por favor, insira um nome." + model.Nome);
            }
        }
    }
}
