using Banco_MVP_MySQL_.Models;
using Banco_MVP_MySQL_.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Forms.LoginCadastro
{
    public partial class CadastroForm : Form, ICadastroUsuarioV
    {
        private readonly CadastroUsuarioP presenter;
        private readonly CadastroUsuarioM model;

        public CadastroForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            model = new CadastroUsuarioM();
            presenter = new CadastroUsuarioP(this, model);
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            presenter.CadastrarUsuario();
        }

        public string Nome => txtNomeCadastro.Text;
        public string Senha => txtSenhaCadastro.Text;
        public string SenhaConfirmada => txtConfirmarSenha.Text;

        public void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();
        }
    }
}