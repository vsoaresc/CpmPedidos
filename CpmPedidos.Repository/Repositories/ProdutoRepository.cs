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

        public dynamic Get()
        {
            return DbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.Categoria.Nome,
                    Imagens = x.Imagens.Select(i => new
                    {
                        i.Id,
                        i.Nome,
                        i.NomeArquivo
                    })
                })
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public dynamic Search(string text, int pagina)
        {
            var produtos = DbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina)
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.Categoria.Nome,
                    Imagens = x.Imagens.Select(i => new
                    {
                        i.Id,
                        i.Nome,
                        i.NomeArquivo
                    })
                })
                .OrderBy(x => x.Nome)
                .ToList();

            var qtdeProdutos = DbContext.Produtos
                .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
                .Count();

            var qtdePaginas = (qtdeProdutos / TamanhoPagina);

            if (qtdePaginas < 1)
            {
                qtdePaginas = 1;
            }

            return new {produtos , qtdePaginas };

        }

        public dynamic Detail(int? id)
        {
            return DbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Codigo,
                    x.Descricao,
                    x.Preco,
                    Categoria = new {
                        x.Categoria.Id,
                        x.Categoria.Nome
                    },
                    Imagens = x.Imagens.Select(i => new
                    {
                        i.Id,
                        i.Nome,
                        i.NomeArquivo
                    })
                })
                .FirstOrDefault();
        }

        public dynamic Imagens(int? id)
        {
            return DbContext.Produtos
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .SelectMany(x => x.Imagens, (produto, imagem)  => new
                {
                    IdProduto = produto.Id,
                    imagem.Id,
                    imagem.Nome,
                    imagem.NomeArquivo
                })
                .FirstOrDefault();
        }
    }
}
