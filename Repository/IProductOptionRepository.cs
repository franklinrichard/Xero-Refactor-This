using RefactorThis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactorThis.Repository
{
    public interface IProductOptionRepository
    {

        List<ProductOption> GetOptions(Guid productId);


        ProductOption GetOption(Guid productId, Guid id);

        List<ProductOption> GetOption();

        void CreateOption(Guid productId, ProductOption option);

        void UpdateOption(Guid id, ProductOption option);

        void DeleteOption(Guid id);
    }
}
