﻿using CpmPedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface
{
    public interface ICidadeRepository
    {
        dynamic Get();
        int Criar(CidadeDTO model);
        int Alterar(CidadeDTO model);
        bool Excluir(int id);
    }
}
