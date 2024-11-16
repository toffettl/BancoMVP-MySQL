using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_MVP_MySQL_.Views
{
    internal interface IExtratoV
    {
        int idExtrato { get; set; }
        decimal saldoExtrato { get; set; }
        string nomePagante { get; set; }
        string nomeReceber { get; set; }
        DateTime dataPagamento { get; set; }
        int fkIdPagante { get; set; }
        int fkIdReceber { get; set; }
        bool recebeu { get; set; }

        void ListarExtrato();
    }
}
