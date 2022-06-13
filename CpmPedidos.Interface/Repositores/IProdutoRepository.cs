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
        List<Produto> Get();
        List<Produto> Search(string text, int pagina);
        Produto Detail(int? id);

    }
}
