﻿using Banco_MVP_MySQL_.Forms;
using Banco_MVP_MySQL_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_MVP_MySQL_.Presenters
{
    internal class LoginUsuarioP
    {
        private readonly LoginForm view;
        private readonly PrincipalForm viewP;
        private readonly LoginUsuarioM model;
        public int idUsuario;

        public LoginUsuarioP(LoginForm view, LoginUsuarioM model)
        {
            this.view = view;
            this.model = model;
        }

        public bool loginUsuario()
        {
            model.Nome = view.Nome;
            model.Senha = view.Senha;
            if (!string.IsNullOrWhiteSpace(model.Nome) && !string.IsNullOrWhiteSpace(model.Senha))
            {
                if (model.confirmarLogin())
                {
                    view.ExibirMensagem("Entrou");
                    idUsuario = model.receberId();
                    return true;
                }
                else
                {
                    view.ExibirMensagem("Senha ou nome inválidos");
                    return false;
                }
            }
            else
            {
                view.ExibirMensagem("Favor, preencha os campos corretamente");
                return false;
            }
        }
    }
}