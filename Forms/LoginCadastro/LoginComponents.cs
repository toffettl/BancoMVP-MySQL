using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Forms.LoginCadastro
{
    internal class LoginComponents
    {
        public TextBox TxtTransferencia { get; private set; }

        public LoginComponents()
        {
            TxtTransferencia = new TextBox();

            TxtTransferencia.Location = new System.Drawing.Point(10, 30);
            TxtTransferencia.Width = 200;
        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(TxtTransferencia);
        }
    }
}
