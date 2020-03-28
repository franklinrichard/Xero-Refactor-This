using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefactorThis.Models;

namespace RefactorThis.Repository
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        ProductOption productOption = new ProductOption();
        public List<ProductOption> Items { get; private set; }

        public void CreateOption(Guid productId, ProductOption option)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = option.IsNew
                ? $"insert into productoptions (id, productid, name, description) values ('{option.Id}', '{option.ProductId}', '{option.Name}', '{option.Description}')"
                : $"update productoptions set name = '{option.Name}', description = '{option.Description}' where id = '{option.Id}' collate nocase";

            cmd.ExecuteNonQuery();
            
        }

        public void DeleteOption(Guid id)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"delete from productoptions where id = '{id}' collate nocase";
            cmd.ExecuteReader();
            
        }

        public ProductOption GetOption( Guid id)
        {
            productOption.IsNew = true;
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"select * from productoptions where id = '{id}' collate nocase";

            var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) { productOption.IsNew = true; }

            else { 
            productOption.IsNew = false;
            productOption.Id = Guid.Parse(rdr["Id"].ToString());
            productOption.ProductId = Guid.Parse(rdr["ProductId"].ToString());
            productOption.Name = rdr["Name"].ToString();
            productOption.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
            }
            return productOption;
        }

        public List<ProductOption> GetOption()
        {
            return LoadOptions(null);
        }

        private List<ProductOption> LoadOptions(string where)
        {
            Items = new List<ProductOption>();
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"select id from productoptions {where}";

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var id = Guid.Parse(rdr.GetString(0));
                Items.Add(new ProductOption(id));
            };
            return Items;
        }

        public List<ProductOption> GetOptions(Guid productId)
        {

            Items = new List<ProductOption>();
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"select id from productoptions where productid = '{productId}' collate nocase";

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var id = Guid.Parse(rdr.GetString(0));
                Items.Add(new ProductOption(id));
            };
            return Items;
        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            bool isNew = GetOption(id).IsNew;
            if (!isNew)
            {
                option.IsNew = false;
                CreateOption(id, option);
            }
            else if (isNew)
            {
                option.IsNew = true;
                this.CreateOption(id, option);
            }
            else { throw new Exception(); }

            
            
        }
    }
}
