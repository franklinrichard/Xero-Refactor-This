using RefactorThis.Models;
using RefactorThis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactorThis.Repository
{
    public interface IProductRepository
    {
        void saveProduct(Product product);
        void DeleteProduct(Guid id);
        void UpdateProduct(Guid id, Product product);
        List<Product> LoadProducts();
        Product LoadProducts(Guid id);
    }
}
