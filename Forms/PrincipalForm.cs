﻿using Banco_MVP_MySQL_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Banco_MVP_MySQL_.Presenters;
using Banco_MVP_MySQL_.Views;

namespace Banco_MVP_MySQL_.Forms
{
    public partial class PrincipalForm : Form, IPrincipalV
    {
        private readonly LoginUsuarioM modelLogin;
        private readonly PrincipalP presenter;
        private readonly PrincipalModel model;
        public int idUsuario;

        public string Nome => txtEditarNome.Text;
        public string Senha => txtSenhaEditar.Text;
        public string NovaSenha => txtNovaSenha.Text;
        public string ConfirmarNovaSenha => txtConfirmarNovaSenha.Text;
        public int saldo;

        public TextBox txtEditarNome;
        public TextBox txtSenhaEditar;
        public Button btnEditarNome;
        public Label lblId;
        public TextBox txtNovaSenha;
        public TextBox txtConfirmarNovaSenha;
        public Button btnEditarSenha;
        public Label lblSaldo;
        public PrincipalForm(int idUsuario)
        {
            InitializeComponent();
            modelLogin = new LoginUsuarioM();
            model = new PrincipalModel();
            presenter = new PrincipalP(this, model);
            presenter.idUsuario = idUsuario;
            txtEditarNome = new TextBox();
            presenter.receberSaldo();
            Controls.Add(txtEditarNome);

            txtSenhaEditar = new TextBox()
            {
                Location = new Point(300,300),
                Text = "Senha"
            };
            Controls.Add(txtSenhaEditar);

            btnEditarNome = new Button()
            {
                Location = new Point(30,60),
                Text = "Editar nome"
            };
            Controls.Add(btnEditarNome);
            btnEditarNome.Click += EditarNome;

            txtNovaSenha = new TextBox()
            {
                Location= new Point(200,0),
                Text = "Nova senha"
            };
            Controls.Add(txtNovaSenha);

            txtConfirmarNovaSenha = new TextBox()
            {
                Location = new Point(200, 50),
                Text = "Confirmar nova senha"
            };
            Controls.Add(txtConfirmarNovaSenha);

            btnEditarSenha = new Button()
            {
                Location = new Point(200, 70),
                Text = "Mudar senha"
            };
            Controls.Add(btnEditarSenha);
            btnEditarSenha.Click += EditarSenha;

            lblId = new Label()
            {
                Location = new Point(300,50),
                Text = "Id do usuario: " + Convert.ToString(idUsuario)
            };
            Controls.Add(lblId);

            lblSaldo = new Label()
            {
                Location = new Point(200, 100),
                Text = Convert.ToString(saldo) // Inicializando com um valor padrão
            };
            Controls.Add(lblSaldo);

        }

        private void EditarNome(object sender, EventArgs e)
        {
            if (presenter.editarNome())
            {
                MessageBox.Show("Nome editado com sucesso!");
            }
            else
            {
                return;
            }
        }

        private void EditarSenha(object sender, EventArgs e)
        {
            if (presenter.editarSenha())
            {
                MessageBox.Show("Senha editada com sucesso!");
            }else
            {
                return;
            }
        }
    }
}