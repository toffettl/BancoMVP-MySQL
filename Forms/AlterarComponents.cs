using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Forms
{
    internal class AlterarComponents
    {
        public TextBox txtNovoNome;
        public TextBox txtSenhaNome;
        public TextBox txtNovaSenha;
        public TextBox txtConfirmarSenha;
        public TextBox txtSenhaSenha;
        public Button btnAlterarNome;
        public Button btnAlterarSenha;

        public AlterarComponents()
        {
            txtNovoNome = new TextBox()
            {
                Location = new Point(150, 0),
                Width = 100,
                Text = "Novo nome",
            };
            txtSenhaNome = new TextBox()
            {
                Location = new Point(150, 20),
                Width = 100,
                Text = "Senha",
            };
            btnAlterarNome = new Button()
            {
                Location = new Point(150, 40),
                Width = 100,
                Text = "alterar nome",
            };
            txtNovaSenha = new TextBox()
            {
                Location = new Point(250, 0),
                Width = 100,
                Text = "Nova Senha",
            };
            txtConfirmarSenha = new TextBox()
            {
                Location = new Point(250, 20),
                Width = 100,
                Text = "Confirmar Senha",
            };
            txtSenhaSenha = new TextBox()
            {
                Location = new Point(250, 40),
                Width = 100,
                Text = "Senha",
            };
            btnAlterarSenha = new Button()
            {
                Location = new Point(250, 60),
                Width = 100,
                Text = "alterar senha",
            };
        }

        public void AddControles(Control parent)
        {
            parent.Controls.Add(txtNovoNome);
            parent.Controls.Add(txtSenhaNome);
            parent.Controls.Add(btnAlterarNome);
            parent.Controls.Add(txtNovaSenha);
            parent.Controls.Add(txtConfirmarSenha);
            parent.Controls.Add(txtSenhaSenha);
            parent.Controls.Add(btnAlterarSenha);
        }
    }
}
