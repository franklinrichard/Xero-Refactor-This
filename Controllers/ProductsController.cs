using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RefactorThis.Models;
using RefactorThis.Services;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductOptionService _productOptionService;

        public ProductsController(IProductService productService, IProductOptionService productOptionService)
        {
            _productService = productService;
            _productOptionService = productOptionService;
        }
        
        [HttpGet]
        public List<Product> Get()
        {
            return _productService.LoadProducts();
        }
        
        [HttpGet]
        [Route("{id}/product")]
        public Product Get(Guid id)
        {
             return _productService.LoadProducts(id);
        }

        [HttpPost]
        public void Post(Product product)
        {
            _productService.Save(product);
        }

        [HttpPut("{id}")]
        public  void Update(Guid id, Product product)
        {
            _productService.UpdateProduct(id,product);
           
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _productService.DeleteProduct(id);
        }

        [HttpGet("{productId}/options")]
        public List<ProductOption> GetOptions(Guid productId)
        {
            return _productOptionService.GetOptions(productId);
            //return new ProductOptions(productId);
        }

        [HttpGet("{productId}/options/{id}")]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            var option = new ProductOption(id);
            if (option.IsNew)
                throw new Exception();

            return option;
        }

        [HttpPost("{productId}/options")]
        public void CreateOption(Guid productId, ProductOption option)
        {
            option.ProductId = productId;
            option.Save();
        }

        [HttpPut("{productId}/options/{id}")]
        public void UpdateOption(Guid id, ProductOption option)
        {
            var orig = new ProductOption(id)
            {
                Name = option.Name,
                Description = option.Description
            };

            if (!orig.IsNew)
                orig.Save();
        }

        [HttpDelete("{productId}/options/{id}")]
        public void DeleteOption(Guid id)
        {
            var opt = new ProductOption(id);
            opt.Delete();
        }
    }
}