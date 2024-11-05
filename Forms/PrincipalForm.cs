using Banco_MVP_MySQL_.Forms.LoginCadastro;
using Banco_MVP_MySQL_.Models;
using Banco_MVP_MySQL_.Presenters;
using Banco_MVP_MySQL_.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Forms
{
    public partial class PrincipalForm : Form, IPrincipalV
    {
        private readonly LoginUsuarioM modelLogin;
        private readonly PrincipalP presenter;
        private readonly PrincipalModel model;
        public int idUsuario;

        public string Nome
        {
            get;
            set;
        }
        public string Senha => txtSenhaEditar.Text;
        public string NovaSenha => txtNovaSenha.Text;
        public string ConfirmarNovaSenha => txtConfirmarNovaSenha.Text;
        public decimal Saldo { get; set; }
        public decimal ValorTranferencia { get; set; }
        public int idTranferencia { get; set; }

        public TextBox txtEditarNome;
        public TextBox txtSenhaEditar;
        public TextBox txtSenhaEditarNome;
        public Button btnEditarNome;
        public Label lblId;
        public TextBox txtNovaSenha;
        public TextBox txtConfirmarNovaSenha;
        public Button btnEditarSenha;
        public Label lblSaldo;
        public Panel pnlMenu;
        public Panel pnlInicio;
        public Panel pnlSaldo;
        public Label lblpnlSaldo;
        public Panel pnlDadosUsuario;
        public Label lblNomeUsuario;
        public Button btnCopiarId;
        public Button btnabrirTransferencia;
        public Panel pnlTransferencia;
        public Button btnEditarUsuario;
        public Panel pnlEditarUsuario;

        private TransferenciaComponents transferenciaComponents;
        public PrincipalForm(int idUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1280, 720);
            modelLogin = new LoginUsuarioM();
            model = new PrincipalModel();
            presenter = new PrincipalP(this, model);
            presenter.idUsuario = idUsuario;
            presenter.LerUsuario();

            transferenciaComponents = new TransferenciaComponents();
            transferenciaComponents.AddControles(this);
            transferenciaComponents.btnTransferir.Click += Transferir;
            transferenciaComponents.lblSaldo.Text = Convert.ToString(Saldo);
        }

        private void RemoverSetas(NumericUpDown numericUpDown) //remove os controles do numericDropDown
        {
            numericUpDown.Controls[0].Visible = false;
        }
        private void EditarNome(object sender, EventArgs e)
        {
            if (presenter.EditarNome())
            {
                MessageBox.Show("Nome editado com sucesso!");
                Nome = txtEditarNome.Text;
            }
            else
            {
                return;
            }
        }

        private void EditarSenha(object sender, EventArgs e)
        {
            if (presenter.EditarSenha())
            {
                MessageBox.Show("Senha editada com sucesso!");
            }
            else
            {
                return;
            }
        }

        private void Transferir(object sender, EventArgs e)
        {
            idTranferencia = Convert.ToInt32(transferenciaComponents.txtId.Text);
            ValorTranferencia = Convert.ToDecimal(transferenciaComponents.txtValor.Text);
            if (presenter.tranferencia())
            {
                if (presenter.receber())
                {
                    presenter.LerUsuario();
                    //lblSaldo.Text = "R$: " + Convert.ToString(Saldo);
                    MessageBox.Show("Valor transferido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao receberdas");
                }
            }
            else
            {
                MessageBox.Show("Erro ao transferir!");
            }
        }

        private void CopiarId(object sender, EventArgs e)
        {
            Clipboard.SetText(Convert.ToString(presenter.idUsuario));
        }

        private void AbrirTransferencia(object sender, EventArgs e)
        {
            pnlInicio.Visible = false;
            pnlTransferencia.Visible = true;
        }
        private void AbrirEditar(object sender, EventArgs e)
        {
            if (pnlEditarUsuario.Visible == false)
            {
                pnlEditarUsuario.Visible = true;
                pnlInicio.Visible = false;
                pnlEditarUsuario.Controls.Add(btnEditarUsuario);
                btnEditarUsuario.Location = new Point(0, 100);
            }
            else
            {
                pnlDadosUsuario.Controls.Add(btnEditarUsuario);
                pnlInicio.Visible = true;
                btnEditarUsuario.Location = new Point(10, 160);
                pnlEditarUsuario.Visible = false;
            }
        }
    }
}
