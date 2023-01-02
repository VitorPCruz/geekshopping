using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productsService;

        public ProductsController(IProductService productsService)
        {
            _productsService = productsService ??
                throw new ArgumentNullException(nameof(productsService));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productsService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productsService.CreateProduct(model);

                if (response != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Update(long id)
        {
            var model = await _productsService.FindProductById(id);

            if (model != null) return View(model);

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Update(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productsService.UpdateProduct(model);

                if (response != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}