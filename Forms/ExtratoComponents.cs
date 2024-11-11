using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Banco_MVP_MySQL_.Forms
{
    internal class ExtratoComponents
    {
        FlowLayoutPanel flpExtrato;
        Label lblValorExtrato;
        Label lblNomePagante;
        Label lblNomeReceber;
        Label lblDataPagamento;
        Label lblIdPagante;
        Label lblIdReceber;

        public ExtratoComponents()
        {
            flpExtrato = new FlowLayoutPanel()
            {
                BackColor = Color.Blue,
                Size = new Size(700, 100),
                Location = new Point(500, 50)
            };

            lblValorExtrato = new Label()
            {
                Text = "teste",
            };

            lblNomePagante = new Label()
            {
                Text = "teste",
            };

            lblNomeReceber = new Label()
            {
                Text = "teste",
            };

            lblDataPagamento = new Label()
            {
                Text = "teste",
            };

            lblIdPagante = new Label()
            {
                Text = "teste",
            };

            lblIdReceber = new Label()
            {
                Text = "teste",
            };
        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(flpExtrato);
            flpExtrato.Controls.Add(lblValorExtrato);
            flpExtrato.Controls.Add(lblNomePagante);
            flpExtrato.Controls.Add(lblNomeReceber);
            flpExtrato.Controls.Add(lblDataPagamento);
            flpExtrato.Controls.Add(lblIdPagante);
            flpExtrato.Controls.Add(lblIdReceber);
        }
    }
}
