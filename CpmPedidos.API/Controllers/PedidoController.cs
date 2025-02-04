﻿using CpmPedidos.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CpmPedidos.Interface;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : AppBaseController
    {
        public PedidoController(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        [HttpGet]
        [Route("ticket-maximo")]
        public decimal TicketMaximo()
        {
            var rep = (IPedidoRepository)_serviceProvider.GetService(typeof(IPedidoRepository));
            return rep.TicketMaximo();
        }

        [HttpGet]
        [Route("por-cliente")]
        public dynamic PedidosClientes()
        {
            var rep = (IPedidoRepository)_serviceProvider.GetService(typeof(IPedidoRepository));
            return rep.PedidosClientes();
        }

        [HttpPost]
        [Route("")]
        public string SalvarPedido(PedidoDTO pedido)
        {
            return GetService<IPedidoRepository>().SalvarPedido(pedido);
        }
    }
}
