using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Forms
{
    internal class CaixaComponents
    {
        FlowLayoutPanel flpCaixa;

        public CaixaComponents()
        {
            flpCaixa = new FlowLayoutPanel()
            {
                Size = new Size(700, 200),
                Location = new Point(0, 300),
                BackColor = Color.Blue,
            };
        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(flpCaixa);
        }
    }
}
