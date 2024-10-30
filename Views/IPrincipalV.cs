using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_MVP_MySQL_.Views
{
    internal interface IPrincipalV
    {
        string Nome { get; }
        string Senha { get; }
        string NovaSenha { get; }
        string ConfirmarNovaSenha { get; }
    }
}
