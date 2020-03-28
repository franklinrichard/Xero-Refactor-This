using RefactorThis.Models;
using System;
using System.Collections.Generic;

namespace RefactorThis.Services
{
    public interface IProductService
    {
        Product LoadProducts(Guid id);
        void DeleteProduct(Guid id);
        void UpdateProduct(Guid id,Product product);
        List<Product> LoadProducts();
        void Save(Product product);
    }
}