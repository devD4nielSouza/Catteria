//using Microsoft.AspNetCore.Mvc;
//using Catteria.Application.ViewModels;
//using Catteria.Application.DTOs;
//using System;
//using System.Collections.Generic;

//namespace Catteria.UI.Controllers
//{
//    public class OrderDetailsController : Controller
//    {
//        // Rota: /OrderDetails
//        public IActionResult Index()
//        {
//            // 1. Criamos os dados do usuário puxando o e-mail dinamicamente
//            var userSimulado = new UserDto
//            {
//                Id = "12",
//                Email = "graziella.santos@email.com" // Aqui simula o e-mail do usuário logado
//            };

//            // 2. Criamos o pedido usando as propriedades exatas do seu OrderDto (Id, Date, TotalValue, Status, IdUser)
//            var orderSimulado = new OrderDto
//            {
//                Id = 4829,
//                Date = DateTime.Now,
//                Status = "Preparando",
//                IdUser = 12,
//                TotalValue = 48.30m
//            };

//            // 3. Criamos a lista de itens usando as propriedades exatas do seu OrderItemDto (IdProduct, Quantity, UnitPrice)
//            // Aqui simula os produtos que o usuário adicionou no carrinho
//            var itensSimulados = new List<OrderItemDto>
//            {
//                new OrderItemDto { IdProduct = 101, Quantity = 2, UnitPrice = 14.90m }, // Cappuccino
//                new OrderItemDto { IdProduct = 204, Quantity = 1, UnitPrice = 18.50m }  // Croissant
//            };

//            // 4. Juntamos tudo na ViewModel que a tela espera
//            var viewModel = new OrderDetailsViewModel
//            {
//                User = userSimulado,
//                Order = orderSimulado,
//                ItemsOrder = itensSimulados,
//                Total = orderSimulado.TotalValue,
//                status = orderSimulado.Status
//            };

//            return View("~/Views/Order/OrderDetails.cshtml", viewModel);
//        }
//    }
//}