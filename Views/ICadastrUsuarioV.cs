using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_MVP_MySQL_
{
    internal interface ICadastroUsuarioV
    {
        string Nome { get; }
        string Senha { get; }

        string SenhaConfirmada { get; }

        void ExibirMensagem(string mesangem);
    }
}
