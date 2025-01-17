﻿using OrganWeb.Areas.Ecommerce.Models.Vendas;
using OrganWeb.Areas.Ecommerce.Models.ViewsBanco;
using OrganWeb.Areas.Sistema.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OrganWeb.Areas.Sistema.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VendasController : Controller
    {
        private VwPedido pedido = new VwPedido();
        private PedidoAnuncio pedidoAnuncio = new PedidoAnuncio();
        private VwVenda venda = new VwVenda();

        public async Task<ActionResult> Index(int? pagep, int? pagev)
        {
            int pagepedido = pagep ?? 1;
            int pagevenda = pagev ?? 1;
            var select = new ViewVendas
            {
                Pedidos = await pedido.GetPedidosAnunciante(pagepedido),
                Vendas = await venda.GetVendasAnunciante(pagevenda)
            };
            return View(select);
        }

        public async Task<ActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venda = await venda.GetByID(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        public async Task<ActionResult> Pedido(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido = await pedido.GetByID(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        public async Task<ActionResult> AceitarPedido(int? idPedido)
        {
            if (idPedido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido = await pedido.GetByID(idPedido);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        [HttpPost, ActionName("AceitarPedido")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CriarVenda(Pedido pedido)
        {
            pedido.Status = 2;
            pedido.Update(pedido);
            await pedido.Save();

            //TODO: criar venda aqui

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> RecusarPedido(int? idPedido)
        {
            if (idPedido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido = await pedido.GetByID(idPedido);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RecusarPedido(Pedido pedido)
        {
            pedido.Status = 9;
            pedido.Update(pedido);
            await pedido.Save();
            return View();
        }
    }
}