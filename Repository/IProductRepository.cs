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
        List<Product> LoadProducts();
    }
}
