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
using Banco_MVP_MySQL_.Views;
using System.Globalization;

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
        public NumericUpDown nupIdTransferencia;
        public NumericUpDown nupValorTransferencia;
        public Button BtnTransferir;
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
        public PrincipalForm(int idUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1280, 720);
            modelLogin = new LoginUsuarioM();
            model = new PrincipalModel();
            presenter = new PrincipalP(this, model);
            presenter.idUsuario = idUsuario;
            txtMoney.KeyPress += TxtMoney_KeyPress;
        }

        private void TxtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números, vírgula e o backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Permite apenas uma vírgula
            if (e.KeyChar == ',' && txtMoney.Text.Contains(","))
            {
                e.Handled = true;
            }

            // Impede que o usuário insira uma vírgula no início
            if (txtMoney.Text.Length == 0 && e.KeyChar == ',')
            {
                e.Handled = true;
            }
        }

        private void txtMoney_Leave(object sender, EventArgs e)
        {
            // Formata o texto como valor monetário ao sair da TextBox
            if (decimal.TryParse(txtMoney.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                txtMoney.Text = result.ToString("N2", CultureInfo.InvariantCulture).Replace('.', ',');
            }
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
            idTranferencia = Convert.ToInt32(nupIdTransferencia.Value);
            ValorTranferencia = Convert.ToInt32(nupValorTransferencia.Value);
            if (presenter.receber())
            {
                if (presenter.tranferencia())
                {
                    presenter.LerUsuario();
                    lblSaldo.Text = "R$: " + Convert.ToString(Saldo);
                    MessageBox.Show("Valor transferido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao receber");
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
            if(pnlEditarUsuario.Visible == false)
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