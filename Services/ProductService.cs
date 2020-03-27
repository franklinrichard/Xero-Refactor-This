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

        public Products LoadProducts(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Product product)
        {
            //validate
            _productRepository.saveProduct(product);
        }
    }
}
