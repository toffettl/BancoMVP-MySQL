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
        Panel pnlExtrato;
        Label lblValorExtrato;
        Label lblNomePagante;
        Label lblNomeReceber;
        Label lblDataPagamento;
        Label lblIdPagante;
        Label lblIdReceber;

        public ExtratoComponents(decimal saldoExtrato, string nomePagante, string nomeReceber, DateTime dataPagamento, int idPagante, int idReceber)
        {
            flpExtrato = new FlowLayoutPanel()
            {
                BackColor = Color.Red,
                Size = new Size(700, 200),
                Location = new Point(500, 50)
            };

            pnlExtrato = new Panel()
            {
                BackColor = Color.Blue,
                Size = new Size(700, 100),
                Location = new Point(500, 50)
            };

            lblValorExtrato = new Label()
            {
                Text = Convert.ToString(saldoExtrato),
            };

            lblNomePagante = new Label()
            {
                Text = nomePagante,
            };

            lblNomeReceber = new Label()
            {
                Text = nomeReceber,
            };

            lblDataPagamento = new Label()
            {
                Text = Convert.ToString(dataPagamento),
            };

            lblIdPagante = new Label()
            {
                Text = Convert.ToString(idPagante),
            };

            lblIdReceber = new Label()
            {
                Text = Convert.ToString(idReceber),
            };


        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(flpExtrato);
        }

        public void AddPainel()
        {
            flpExtrato.Controls.Add(pnlExtrato);
            pnlExtrato.Controls.Add(lblValorExtrato);
            pnlExtrato.Controls.Add(lblNomePagante);
            pnlExtrato.Controls.Add(lblNomeReceber);
            pnlExtrato.Controls.Add(lblDataPagamento);
            pnlExtrato.Controls.Add(lblIdPagante);
            pnlExtrato.Controls.Add(lblIdReceber);
        }
    }
}
