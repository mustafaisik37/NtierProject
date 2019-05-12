using NtierProject.Model.Option;
using NtierProject.Service.Option;
using NtierProject.UI.Areas.Admin.Models.DTO;
using NtierProject.UI.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NtierProject.UI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        CategoryService _categoryService;
        ProductService _productService;
       
        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            
        }
        public ActionResult Add()
        {
            AddProductVM model = new AddProductVM();

            model.Categories = _categoryService.GetActive();
            return View(model);

        }

        [HttpPost]
        public ActionResult Add(Product data)
        {

            _productService.Add(data);
            return Redirect("/Admin/Product/ProductList");
        }
        public ActionResult ProductList()
        {
            List<Product> model = _productService.GetActive();
            return View(model);
        }
    }
}