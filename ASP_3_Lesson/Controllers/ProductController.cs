using ASP_3_Lesson.Entities;
using ASP_3_Lesson.Models;
using ASP_3_Lesson.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASP_3_Lesson.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllByKey();
            var ProductVM = new ProductViewModel
            {
                Products = result
            };
            return View(ProductVM);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int myid)
        {
            var product = await _productService.GetById(myid);
            var vm = new ProductUpdateViewModel
            {
                Product = product
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateViewModel vm)
        {
            _productService.Update(vm.Product);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Delete(int myid)
        {
            var product = await _productService.GetById(myid);
            _productService.Delete(product);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel vm)
        {
            await _productService.Add(vm.Product);
            return RedirectToAction("index");
        }
    }
}

