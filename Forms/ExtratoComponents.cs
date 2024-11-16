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
        public ExtratoComponents()
        {
            flpExtrato = new FlowLayoutPanel()
            {
                BackColor = Color.Red,
                Size = new Size(700, 200),
                Location = new Point(500, 50),
                AutoScroll = true,
            };
        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(flpExtrato);
        }

        public void AddPainel(decimal saldoExtrato, string nomePagante, string nomeReceber, DateTime dataPagamento, int idPagante,int idReceber, bool recebeu)
        {
            Color teste;
            if(recebeu == true)
            {
                 teste = Color.LightGreen;
            }
            else
            {
                 teste = Color.Red;
            }

            Panel pnlExtrato = new Panel();
            pnlExtrato = new Panel()
            {
                BackColor = Color.White,
                Size = new Size(700, 100),
                Location = new Point(500, 50)
            };

            Label lblValorExtrato = new Label()
            {
                Text = Convert.ToString(saldoExtrato),
                ForeColor = teste,
                Location = new Point(0, 0),
                Size = new Size(60, 30),

            };

            Label lblNomePagante = new Label()
            {
                Text = nomePagante,
                Location = new Point(60, 0),
                Size = new Size(60, 30),
            };

            Label lblNomeReceber = new Label()
            {
                Text = nomeReceber,
                Location = new Point(120, 0),
                Size = new Size(60, 30),
            };

            Label lblDataPagamento = new Label()
            {
                Text = Convert.ToString(dataPagamento),
                Location = new Point(180, 0),
                Size = new Size(60, 30),
            };

            Label lblIdPagante = new Label()
            {
                Text = Convert.ToString(idPagante),
                Location = new Point(240, 0),
                Size = new Size(60, 30),
            };

            Label lblIdReceber = new Label()
            {
                Text = Convert.ToString(idReceber),
                Location = new Point(300, 0),
                Size = new Size(60, 30),
            };

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
