﻿using Banco_MVP_MySQL_.Forms.LoginCadastro;
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
    public partial class PrincipalForm : Form, IPrincipalV, IExtratoV, ICaixaV
    {
        private readonly LoginUsuarioM modelLogin;
        private readonly PrincipalP presenter;
        private readonly PrincipalModel model;
        private readonly ExtratoModel extratoModel;
        private readonly ExtratoP presenterExtrato;
        private readonly CaixaModel caixaModel;
        private readonly CaixaP presenterCaixa;

        public int idUsuario;

        public string Nome{get;  set;}
        public string Senha => alterarComponents.txtSenhaSenha.Text;
        public string NovaSenha => alterarComponents.txtNovaSenha.Text;
        public string ConfirmarNovaSenha => alterarComponents.txtConfirmarSenha.Text;
        public decimal Saldo { get; set; }
        public decimal ValorTranferencia { get; set; }
        public int idReceber { get; set; }


        public int idExtrato { get; set; }
        public decimal saldoExtrato { get; set; }
        public string nomePagante { get { return Nome; } set { Nome = value; } }
        public string nomeReceber { get; set; }
        public DateTime dataPagamento { get; set; }
        public int fkIdPagante { get; set; }
        public int fkIdReceber { get; set; }
        public bool recebeu {  get; set; }

        public string NomeCaixa { get; set; }
        public int SaldoCaixa { get; set; }
        public int IdCaixa { get; set; }
        public int IdPermissao { get; set; }

        public Label lblId;
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
        private AlterarComponents alterarComponents;
        private ExtratoComponents extratoComponents;
        private CaixaComponents caixaComponents;
        public PrincipalForm(int idUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1280, 720);
            modelLogin = new LoginUsuarioM();
            model = new PrincipalModel();
            extratoModel = new ExtratoModel();
            presenter = new PrincipalP(this, model);
            presenterExtrato = new ExtratoP(this, extratoModel);
            presenter.idUsuario = idUsuario;
            presenterExtrato.idUsuario = idUsuario;
            presenter.LerUsuario();

            transferenciaComponents = new TransferenciaComponents();
            transferenciaComponents.AddControles(this);
            transferenciaComponents.btnTransferir.Click += Transferir;
            transferenciaComponents.lblSaldo.Text = Convert.ToString(Saldo);

            alterarComponents = new AlterarComponents();
            alterarComponents.AddControles(this);
            alterarComponents.btnAlterarNome.Click += EditarNome;
            alterarComponents.btnAlterarSenha.Click += EditarSenha;
            extratoComponents = new ExtratoComponents();
            extratoComponents.AddControles(this);
            presenterExtrato.ListarExtrato();

            caixaModel = new CaixaModel();
            presenterCaixa = new CaixaP(this, caixaModel);
            presenterCaixa.idUsuario = idUsuario;
            caixaComponents = new CaixaComponents(this);
            caixaComponents.AddControles(this);
            caixaComponents.btnAdicionarCaixa.Click += AdiconarCaixa;
            presenterCaixa.ListarCaixa();
        }

        public void AddPermissao(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            IdCaixa = Convert.ToInt32(btn.Tag);
            MessageBox.Show($"IdCaixa: {IdCaixa}");

            Panel pnlCaixa = btn.Parent as Panel;
            TextBox txtIdPermissao = pnlCaixa.Controls.OfType<TextBox>().FirstOrDefault();
            IdPermissao = Convert.ToInt32(txtIdPermissao.Text);
            MessageBox.Show($"IdPermissao: {IdPermissao}");
            presenterCaixa.AddPermissao();
        }

        public void ListarCaixa()
        {
            caixaComponents.AddCaixa(NomeCaixa, IdCaixa, SaldoCaixa);
        }
        public void AdiconarCaixa(object sender, EventArgs e)
        {
            NomeCaixa = caixaComponents.txtNomeCaixa.Text;
            presenterCaixa.CadastrarCaixa();
            caixaComponents.flpCaixa.Controls.Clear();
            presenterCaixa.ListarCaixa();
        }

        public void ListarExtrato()
        {
            extratoComponents.AddPainel(saldoExtrato, nomePagante, nomeReceber, dataPagamento, fkIdPagante, fkIdReceber, recebeu);
            Console.WriteLine("Adicionando");
        }

        private void EditarNome(object sender, EventArgs e)
        {
            if (presenter.EditarNome())
            {
                MessageBox.Show("Nome editado com sucesso!");
                Nome = alterarComponents.txtNovoNome.Text;
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
            idReceber = Convert.ToInt32(transferenciaComponents.txtId.Text);
            fkIdReceber = Convert.ToInt32(transferenciaComponents.txtId.Text);
            ValorTranferencia = Convert.ToDecimal(transferenciaComponents.txtValor.Text);
            saldoExtrato = Convert.ToDecimal(transferenciaComponents.txtValor.Text);
            presenter.tranferencia();       
            presenter.receber();           
            presenter.LerUsuario();
            presenterExtrato.CadastrarExtrato();
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
