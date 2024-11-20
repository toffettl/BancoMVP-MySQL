using Banco_MVP_MySQL_.Models;
using Banco_MVP_MySQL_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_MVP_MySQL_.Presenters
{
    internal class CaixaP
    {
        private readonly ICaixaV view;
        private readonly CaixaModel model;
        public int idUsuario;

        public CaixaP(ICaixaV view, CaixaModel model)
        {
            this.view = view;
            this.model = model;
        }
        public int GerarId()
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(10000000, 100000000);
            return numeroAleatorio;
        }

        public void CadastrarCaixa()
        {
            model.IdCaixa = GerarId();
            model.NomeCaixa = view.NomeCaixa;
            model.SaldoCaixa = model.SaldoCaixa;
            model.FkIdUsuario = idUsuario;
            if (model.CadastrarCaixa())
            {
                MessageBox.Show("Caixa cadastrada com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar a toalha!");
            }
        }
    }
}
