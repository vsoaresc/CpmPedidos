using CpmPedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface
{
    public interface IProdutoRepository
    {
        dynamic Get();
        dynamic Search(string text, int pagina);
        dynamic Detail(int? id);
        dynamic Imagens(int? id);


    }
}
