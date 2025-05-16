using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;

namespace Sec.Market.MVC.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var catalog = new CatalogModelView
            {
                Products = await _productService.ObtenirSelonFiltre(null)
            };
            return View(catalog);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CatalogModelView ca)
        {

            ca.Products = await _productService.ObtenirSelonFiltre(ca.FilterText);
            
            return View(ca);
        }

        public async Task<IActionResult> Liste()
        {
            return View(await _productService.ObtenirSelonFiltre(null));
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Ajouter(product);
                return RedirectToAction(nameof(Liste));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.Obtenir(id.Value);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Ajouter(product);
                return RedirectToAction(nameof(Liste));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.Obtenir(id.Value);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Product product)
        {

            await _productService.Supprimer(product.Id);
            return RedirectToAction(nameof(Liste));
        }
           
    }
}
