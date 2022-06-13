using CpmPedidos.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CpmPedidos.Interface;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : AppBaseController
    {
        public ProdutoController(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return rep.Get();
        }
    }
}
