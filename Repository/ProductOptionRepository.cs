using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefactorThis.Models;

namespace RefactorThis.Repository
{
    public class ProductOptionRepository : IProductOptionRepository
    {
        public List<ProductOption> Items { get; private set; }
        public void CreateOption(Guid productId, ProductOption option)
        {
            throw new NotImplementedException();
        }

        public void DeleteOption(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductOption GetOption(Guid productId, Guid id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
