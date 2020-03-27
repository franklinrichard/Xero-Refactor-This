using RefactorThis.Models;
//using RefactorThis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactorThis.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Items { get; private set; }

        public ProductRepository()
        {

        }



        public List<Product> LoadProducts()
        {

            Items = new List<Product>();
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"select id from Products";

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var id = Guid.Parse(rdr.GetString(0));
                Items.Add(new Product(id));
            }
            return Items;
        }

        public void saveProduct(Product product)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = product.IsNew
                ? $"insert into Products (id, name, description, price, deliveryprice) values ('{product.Id}', '{product.Name}', '{product.Description}', {product.Price}, {product.DeliveryPrice})"
                : $"update Products set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}' collate nocase";

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

