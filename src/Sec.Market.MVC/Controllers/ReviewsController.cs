using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;

namespace Sec.Market.MVC.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ICustomerReviewService _customerReviewService;
       
        public ReviewsController(ICustomerReviewService customerReviewService)
        {
          _customerReviewService = customerReviewService;
        }
        
        // GET: ReviewsController
        public async Task<ActionResult> Index(int id)
        {
            ViewBag.Id = id;
            return View(await _customerReviewService.ObtenirSelonProduit(id));
        }

        // GET: ReviewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReviewsController/Create
        public ActionResult Create(int id)
        {

            return View(new CustomerReview {ProductId = id});
        }

        // POST: ReviewsController/Create
        [HttpPost]
        public async Task<ActionResult> Create(CustomerReview customerReview)
        {
              if (ModelState.IsValid)
            {
                await _customerReviewService.Ajouter(customerReview);
                return RedirectToAction(nameof(Index), new {id = customerReview.Id});
            }
            
           return View(customerReview);
            
        }

        // GET: ReviewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReviewsController/Edit/5
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

        // GET: ReviewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewsController/Delete/5
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
