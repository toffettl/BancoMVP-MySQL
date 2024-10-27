using Banco_MVP_MySQL_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Forms
{
    public partial class PrincipalForm : Form
    {
        private readonly LoginUsuarioM model;
        public int idUsuario;

        public PrincipalForm(int idUsuario)
        {
            InitializeComponent();
            model = new LoginUsuarioM();
            this.idUsuario = idUsuario;
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(idUsuario);
        }
    }
}