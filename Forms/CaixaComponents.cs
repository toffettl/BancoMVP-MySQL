using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Banco_MVP_MySQL_.Forms
{
    internal class CaixaComponents
    {
        public FlowLayoutPanel flpCaixa;
        public Button btnAdicionarCaixa;
        public TextBox txtNomeCaixa;
        private readonly PrincipalForm principalForm;
        public CaixaComponents(PrincipalForm principalForm)
        {
            this.principalForm = principalForm;

            flpCaixa = new FlowLayoutPanel()
            {
                Size = new Size(700, 200),
                Location = new Point(0, 300),
                BackColor = Color.Blue,
                AutoScroll = true
            };
            btnAdicionarCaixa = new Button()
            {
                Location = new Point(720, 300),
                Size = new Size(100,50),
                Text = "Adicionar caixinha",
            };
            txtNomeCaixa = new TextBox()
            {
                Location = new Point(720, 350),
                Size = new Size(100, 50),
                Text = "Nome caixa",
            };
        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(flpCaixa);
            parent.Controls.Add(btnAdicionarCaixa);
            parent.Controls.Add(txtNomeCaixa);
        }
        public void AddCaixa(string nomeCaixa, int idBtn, decimal saldoCaixa)
        {
            Panel pnlCaixa = new Panel()
            {
                BackColor = Color.White,
                Size = new Size(600, 100),
                Location = new Point(500, 50)
            };

            Label lblNomeCaixa = new Label()
            {
                Text = nomeCaixa
            };

            TextBox txtIdPermissao = new TextBox()
            {
                Location = new Point(0, 20),
                Size = new Size(100, 50),
            };

            Button btnPermissao = new Button()
            {
                Location = new Point(0, 40),
                Size = new Size(100, 50),
                Text = "Adicionar Permissão",
                Tag = idBtn, 
            };
            TextBox txtSaldo = new TextBox()
            {
                Location = new Point(200, 20),
                Size = new Size(100, 50),
            };
            Button btnSaldo = new Button()
            {
                Location = new Point(100, 40),
                Size = new Size(100, 50),
                Text = "Adicionar dineiro",
                Tag = idBtn,
            };

            btnPermissao.Click += (sender, e) => principalForm.AddPermissao(sender, e);
            btnSaldo.Click += (sender, e) => principalForm.AddSaldoCaixa(sender, e);

            pnlCaixa.Controls.Add(lblNomeCaixa);
            pnlCaixa.Controls.Add(txtIdPermissao);
            pnlCaixa.Controls.Add(btnPermissao);
            pnlCaixa.Controls.Add(txtSaldo);
            pnlCaixa.Controls.Add(btnSaldo);
            flpCaixa.Controls.Add(pnlCaixa);
        }
    }
}
