﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_MVP_MySQL_.Views
{
    internal interface IPrincipalV
    {
        string Nome { get; set; }
        string Senha { get; }
        string NovaSenha { get; }
        string ConfirmarNovaSenha { get; }
        decimal Saldo { get; set; }
        decimal ValorTranferencia { get; set; }
        int idReceber { get; set; }
    }
}
