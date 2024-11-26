using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_MVP_MySQL_.Views
{
    internal interface ICaixaV
    {
        int IdCaixa { get; set; }
        int IdPermissao { get; set; }
        string NomeCaixa { get; set; }
        decimal SaldoCaixa { get; set; }

        void ListarCaixa();
    }
}
