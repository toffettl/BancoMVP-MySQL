using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Forms
{
    internal class TransferenciaComponents
    {
        public TextBox txtId;
        public TextBox txtValor;
        public Button btnTransferir;
        public Label lblSaldo;

        public TransferenciaComponents()
        {
            txtValor = new TextBox()
            {
                Location = new Point(0, 0),
                Width = 100,
                Text = "00,00",
            };
            txtId = new TextBox()
            {
                Location = new Point(0, 20),
                Width = 100,
                Text = "ID",
            };
            btnTransferir = new Button()
            {
                Location = new Point(0, 40),
                Width = 100,
                Text = "transferir",
            };
            lblSaldo = new Label()
            {
                Location = new Point(10, 65),
                Text = "transferir",
            };
        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(txtValor);
            parent.Controls.Add(txtId);
            parent.Controls.Add(btnTransferir);
            parent.Controls.Add(lblSaldo);
        }
       
    }
}
