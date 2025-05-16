using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;

namespace Sec.Market.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;

            _productService = productService;
        }

        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("id");

            if (userId == null)
                return RedirectToAction("SignIn", "User", new { returnurl = HttpContext.Request.GetDisplayUrl()});

            return View(await _orderService.ObtenirSelonUser(userId.Value));
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public async Task<ActionResult> Create(int id)
        {
            var userId = HttpContext.Session.GetInt32("id");

            if (userId == null)
                return RedirectToAction("SignIn", "User", new { returnurl = HttpContext.Request.GetDisplayUrl() });

            var product = await _productService.Obtenir(id);

            var orderData = new OrderData
            {
                ProductId = product.Id,
                Product = product,
                UserId = userId.ToString()
            };

            return View(orderData);
        }

        // POST: OrderController/Create
        [HttpPost]
        public async Task<ActionResult> Create(OrderData orderData)
        {

            if (ModelState.IsValid)
            {
                
              await _orderService.Ajouter(orderData);
              return RedirectToAction(nameof(Index));
            }
           
            return View(orderData);
            
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
       
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
       
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
