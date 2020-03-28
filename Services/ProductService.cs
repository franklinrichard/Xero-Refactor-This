using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefactorThis.Models;
using RefactorThis.Repository;

namespace RefactorThis.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> LoadProducts()
        {
            return _productRepository.LoadProducts();
        }

        public void UpdateProduct(Guid id, Product product)
        {
            _productRepository.UpdateProduct(id, product);
          
        }

        public void Save(Product product)
        {
            //validate
            _productRepository.saveProduct(product);
        }

        Product IProductService.LoadProducts(Guid id)
        {
            if (_productRepository.LoadProducts(id).IsNew)
            {
                throw new Exception();
            }
            else { return _productRepository.LoadProducts(id); }
        }

       
    }
}
