using RefactorThis.Models;
using System;
using System.Collections.Generic;

namespace RefactorThis.Services
{
    public interface IProductService
    {
        Products LoadProducts(Guid id);
        List<Product> LoadProducts();
        void Save(Product product);
    }
}