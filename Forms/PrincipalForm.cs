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
        public int Saldo { get; set; }
        public int ValorTranferencia { get; set; }
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
            txtEditarNome = new TextBox()
            {
                Location = new Point(70, 50),
                Text = "Novo Nome",
                Font = new Font("Arial", 20, FontStyle.Bold),
                Size = new Size(250, 50),
            };
            presenter.lerUsuario();

            pnlMenu = new Panel()
            {
                Dock = DockStyle.Left,
                Size = new Size(280, 0),
                BackColor = ColorTranslator.FromHtml("#5A5FEE"),
            };
            Controls.Add(pnlMenu);

            pnlInicio = new Panel()
            {
                Dock = DockStyle.Right,
                Size = new Size(1000, 0),
                BackColor = ColorTranslator.FromHtml("#FFFFFF"),
                Visible = true
            };
            Controls.Add(pnlInicio);

            pnlSaldo = new Panel()
            {
                Size = new Size(400, 250),
                BackColor = ColorTranslator.FromHtml("#F1F3F5"),
                Location = new Point(70, 50),
            };
            pnlInicio.Controls.Add(pnlSaldo);

            lblSaldo = new Label()
            {
                Location = new Point(0, 20),
                Size = new Size(500, 70),
                Font = new Font("Sergoe UI", 50),
                ForeColor = ColorTranslator.FromHtml("#010101"),
                Text = "R$: " + Convert.ToString(Saldo)
            };
            pnlSaldo.Controls.Add(lblSaldo);

            lblpnlSaldo = new Label()
            {
                Location = new Point(10, 0),
                Size = new Size(150, 50),
                Font = new Font("Sergoe UI", 15, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#010101"),
                Text = "Saldo atual:"
            };
            pnlSaldo.Controls.Add(lblpnlSaldo);

            btnabrirTransferencia = new Button()
            {
                Location= new Point(0, 100),
                Text = "Transferir",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
            };
            pnlSaldo.Controls.Add(btnabrirTransferencia);
            btnabrirTransferencia.Click += AbrirTransferencia;

            pnlDadosUsuario = new Panel()
            {
                Size = new Size(450, 250),
                BackColor = ColorTranslator.FromHtml("#F1F3F5"),
                Location = new Point(500, 50),

            };
            pnlInicio.Controls.Add(pnlDadosUsuario);

            lblId = new Label()
            {
                Location = new Point(0, 100),
                Size = new Size(350, 60),
                Font = new Font("Sergoe UI", 40),
                ForeColor = ColorTranslator.FromHtml("#010101"),
                Text = "Id: " + Convert.ToString(idUsuario)
            };
            pnlDadosUsuario.Controls.Add(lblId);

            lblNomeUsuario = new Label()
            {
                Location = new Point(0, 20),
                Size = new Size(500, 70),
                Font = new Font("Sergoe UI", 50),
                ForeColor = ColorTranslator.FromHtml("#010101"),
                Text = Nome
            };
            pnlDadosUsuario.Controls.Add(lblNomeUsuario);

            btnEditarUsuario = new Button()
            {
                Text = "Editar",
                Location = new Point(10, 160),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
            };
            pnlDadosUsuario.Controls.Add(btnEditarUsuario);
            btnEditarUsuario.Click += AbrirEditar;

            pnlEditarUsuario = new Panel()
            {
                Dock = DockStyle.Right,
                Size = new Size(1000, 0),
                BackColor = ColorTranslator.FromHtml("#FFFFFF"),
                Visible = false,
            };
            Controls.Add(pnlEditarUsuario);

            txtSenhaEditar = new TextBox()
            {
                Location = new Point(70, 125),
                Text = "Senha",
                Font = new Font("Arial", 20, FontStyle.Bold),
                Size = new Size(250, 50),
            };
            pnlEditarUsuario.Controls.Add(txtSenhaEditar);

            txtSenhaEditarNome = new TextBox()
            {
                Location = new Point(500, 190),
                Text = "SENHAAAA",
                Font = new Font("Arial", 20, FontStyle.Bold),
                Size = new Size(300, 50),
            };
            pnlEditarUsuario.Controls.Add(txtSenhaEditarNome);

            btnEditarNome = new Button()
            {
                Location = new Point(30, 60),
                Text = "Editar nome",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
            };
            pnlEditarUsuario.Controls.Add(btnEditarNome);
            btnEditarNome.Click += EditarNome;

            txtNovaSenha = new TextBox()
            {
                Location = new Point(500, 50),
                Text = "Nova Senha",
                Size = new Size(250, 50),
                Font = new Font("Arial", 20, FontStyle.Bold)
            };
            pnlEditarUsuario.Controls.Add(txtNovaSenha);

            txtConfirmarNovaSenha = new TextBox()
            {
                Location = new Point(500, 125),
                Text = "Confirmar nova senha",
                Size = new Size(250, 50),
                Font = new Font("Arial", 20, FontStyle.Bold)
            };
            pnlEditarUsuario.Controls.Add(txtConfirmarNovaSenha);

            btnEditarSenha = new Button()
            {
                Location = new Point(200, 70),
                Text = "Mudar senha",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
            };
            pnlEditarUsuario.Controls.Add(btnEditarSenha);
            btnEditarSenha.Click += EditarSenha;
            pnlEditarUsuario.Controls.Add(txtEditarNome);

            btnCopiarId = new Button()
            {
                Text = "Copiar",
                Location = new Point(100, 160),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,

            };
            pnlDadosUsuario.Controls.Add(btnCopiarId);
            btnCopiarId.Click += CopiarId;

            pnlTransferencia = new Panel()
            {
                Dock = DockStyle.Right,
                Size = new Size(1000, 0),
                BackColor = ColorTranslator.FromHtml("#FFFFFF"),
                Visible = false
            };
            Controls.Add(pnlTransferencia);

            nupIdTransferencia = new NumericUpDown()
            {
                Location = new Point(50, 100),
                Size = new Size(200, 10),
                Font = new Font("Arial", 30, FontStyle.Bold),
                BorderStyle = BorderStyle.None
            };
            pnlTransferencia.Controls.Add(nupIdTransferencia);
            RemoverSetas(nupIdTransferencia);

            nupValorTransferencia = new NumericUpDown()
            {
                Location = new Point(50, 200),
                Size = new Size(150, 10),
                Font = new Font("Arial", 50, FontStyle.Bold),
                DecimalPlaces = 2,
                BorderStyle = BorderStyle.None
            };
            pnlTransferencia.Controls.Add(nupValorTransferencia);
            RemoverSetas(nupValorTransferencia);

            BtnTransferir = new Button()
            {
                Location = new Point(50, 300),
                Size = new Size(150, 50),
                Text = "Transferir",
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
            };
            pnlTransferencia.Controls.Add(BtnTransferir);
            BtnTransferir.Click += Transferir;
        }

        private void RemoverSetas(NumericUpDown numericUpDown) //remove os controles do numericDropDown
        {
            numericUpDown.Controls[0].Visible = false;
        }
        private void EditarNome(object sender, EventArgs e)
        {
            if (presenter.editarNome())
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
            if (presenter.editarSenha())
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
                    presenter.lerUsuario();
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