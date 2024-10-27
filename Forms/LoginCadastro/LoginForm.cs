using Banco_MVP_MySQL_.Forms;
using Banco_MVP_MySQL_.Forms.LoginCadastro;
using Banco_MVP_MySQL_.Models;
using Banco_MVP_MySQL_.Presenters;
using Banco_MVP_MySQL_.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_
{
    public partial class LoginForm : Form
    {
        private readonly LoginUsuarioP presenter;
        private readonly LoginUsuarioM model;
        public int idUsuario;
        public string Nome;
        public string Senha;
        public LoginForm()
        {
            InitializeComponent();
            model = new LoginUsuarioM();
            presenter = new LoginUsuarioP(this, model);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Nome = txtNomeLogin.Text;
            Senha = txtSenhaLogin.Text;
            if (presenter.loginUsuario())
            {
                label.Text = Convert.ToString(idUsuario);
                PrincipalForm principalForm = new PrincipalForm(presenter.idUsuario);
                principalForm.Show();
                Hide();
            }
        }
        public void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            CadastroForm cadastroForm = new CadastroForm();
            cadastroForm.Show();
            Hide();
        }
    }
}