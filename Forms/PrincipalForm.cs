using Banco_MVP_MySQL_.Models;
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

namespace Banco_MVP_MySQL_.Forms
{
    public partial class PrincipalForm : Form
    {
        private readonly LoginUsuarioM modelLogin;
        private readonly PrincipalP presenter;
        private readonly PrincipalModel model;
        public int idUsuario;
        public string nomeUsuario;

        public TextBox txtEditarNome;
        public TextBox txtSenhaEditar;
        public Button btnEditarNome;
        public Label lblId;
        public PrincipalForm(int idUsuario)
        {
            InitializeComponent();
            modelLogin = new LoginUsuarioM();
            model = new PrincipalModel();
            presenter = new PrincipalP(this, model);
            this.idUsuario = idUsuario;

            txtEditarNome = new TextBox();
            Controls.Add(txtEditarNome);

            txtSenhaEditar = new TextBox()
            {
                Location = new Point(0,30),
            };
            Controls.Add(txtSenhaEditar);

            btnEditarNome = new Button()
            {
                Location = new Point(30,60),
                Text = "Editar nome"
            };
            Controls.Add(btnEditarNome);
            btnEditarNome.Click += EditarNome;

            lblId = new Label()
            {
                Location = new Point(150,50),
                Text = "Id do usuario: " + Convert.ToString(idUsuario)
            };
            Controls.Add(lblId);
        }

        private void EditarNome(object sender, EventArgs e)
        {
            if (presenter.editarNome())
            {
                MessageBox.Show("Editado com sucesso!");
            }
            else
            {
                return;
            }
        }
    }
}