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
        Product _product = new Product();
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

        public Product LoadProducts(Guid id)
        {
            
            _product.IsNew = true;

            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"select * from Products where id = '{id}' collate nocase";

            var rdr = cmd.ExecuteReader();
            if (!rdr.Read())
                _product.IsNew = true;

            _product.IsNew = false;
            _product.Id = Guid.Parse(rdr["Id"].ToString());
            _product.Name = rdr["Name"].ToString();
            _product.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
            _product.Price = decimal.Parse(rdr["Price"].ToString());
            _product.DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString());

            return _product;
            
        }

        public void UpdateProduct(Guid id, Product product)
        {
            bool isNew=LoadProducts(id).IsNew;
            if (!isNew)
            {
                product.IsNew = false;
                //_product = product;
                this.saveProduct(product);

            }
            else if (isNew)
            {
                product.IsNew = true;
                this.saveProduct(product);
            }
            else { throw new Exception(); }
        }
    }
}

