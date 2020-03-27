using RefactorThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactorThis.Repository
{
    //public class ProductRepo
    //{
    //    Product product = new Product();
    //    public ProductRepo()
    //    {
    //        product.Id = Guid.NewGuid();
    //        product.IsNew = true;
    //    }

    //    public ProductRepo(Guid id)
    //    {
    //        product.IsNew = true;
    //        var conn = Helpers.NewConnection();
    //        conn.Open();
    //        var cmd = conn.CreateCommand();
    //        cmd.CommandText = $"select * from Products where id = '{id}' collate nocase";

    //        var rdr = cmd.ExecuteReader();
    //        if (!rdr.Read())
    //            return;

    //        product.IsNew = false;
    //        product.Id = Guid.Parse(rdr["Id"].ToString());
    //        product.Name = rdr["Name"].ToString();
    //        product.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
    //        product.Price = decimal.Parse(rdr["Price"].ToString());
    //        product.DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString());
    //    }


    //    public void Save()
    //    {
    //        var conn = Helpers.NewConnection();
    //        conn.Open();
    //        var cmd = conn.CreateCommand();

    //        cmd.CommandText = product.IsNew
    //            ? $"insert into Products (id, name, description, price, deliveryprice) values ('{product.Id}', '{product.Name}', '{product.Description}', {product.Price}, {product.DeliveryPrice})"
    //            : $"update Products set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}' collate nocase";

    //        conn.Open();
    //        cmd.ExecuteNonQuery();
    //    }

    //    public void Delete()
    //    {
    //        foreach (var option in new ProductOptions(product.Id).Items)
    //            option.Delete();

    //        var conn = Helpers.NewConnection();
    //        conn.Open();
    //        var cmd = conn.CreateCommand();

    //        cmd.CommandText = $"delete from Products where id = '{product.Id}' collate nocase";
    //        cmd.ExecuteNonQuery();
    //    }
    //}
}
