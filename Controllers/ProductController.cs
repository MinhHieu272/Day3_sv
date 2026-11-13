using Microsoft.AspNetCore.Mvc;
using Day3_sv.Models;
using Day3_sv.Services;

namespace Day3_sv.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        // Khởi tạo ProductService
        public ProductController()
        {
            _service = new ProductService();
        }

        // GET: ProductController
        // Tìm kiếm và phân trang
        public IActionResult Index([FromQuery] ProductSearchModel search)
        {
            var (products, totalPages) = _service.Search(
                search.Keyword,
                search.Page,
                search.PageSize
            );

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = search.Page;
            ViewBag.Search = search;

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductController/Create/5
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _service.Create(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            bool updated = _service.Update(product);

            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            bool result = _service.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
