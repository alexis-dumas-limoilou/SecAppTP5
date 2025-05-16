using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sec.Market.API.Data;
using Sec.Market.API.Entites;
using Sec.Market.API.Interfaces;

namespace Sec.Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _OrderRepository;

        private readonly IPaiementRepository _paiementRepository;

        private readonly IPaiementService _paiementService;

        public OrdersController(IOrderRepository OrderRepository, IPaiementService paiementService, IPaiementRepository paiementRepository)
        {
            _OrderRepository = OrderRepository;
            _paiementRepository = paiementRepository;
            _paiementService = paiementService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int userId)
        {
            return await _OrderRepository.GetOrdersByUser(userId);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
          
         
            var order = await _OrderRepository.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

           await _OrderRepository.UpdateOrder(order);

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderData orderData)
        {

            var order = new Order
            {
                Date = orderData.Date,
                Price = orderData.Price,
                ProductId = orderData.ProductId,
                UserId = int.Parse(orderData.UserId),
                Quantity = orderData.Quantity,
                ShippingAdress = orderData.ShippingAdress,
            };

            var card = new Card
            {
                Number = orderData.CardNumber,
                Owner = orderData.CardOwner,
                SecurityCode = orderData.CardSecurityCode,
                Type = orderData.CardType,
                UserId = int.Parse(orderData.UserId),
                ExpirationDate = orderData.CardExpirationDate
            };

            if (_paiementService.Pay(card))
            {
                var saveCard = await _paiementRepository.GetCardByNumberAndUser(orderData.CardNumber, orderData.UserId);

                if (saveCard == null)
                await _paiementRepository.InsertCard(card);

                await _OrderRepository.InsertOrder(order);

                return CreatedAtAction("GetOrder", new { id = order.Id }, order);
            }

            return Problem("Echec du paiement");

        }

       
    }
}
