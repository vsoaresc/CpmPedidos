using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<Produto> Get()
        {
            return DbContext.Produtos.ToList();
        }
    }
}
