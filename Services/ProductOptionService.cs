using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RefactorThis.Models;
using RefactorThis.Repository;

namespace RefactorThis.Services
{
    public class ProductOptionService : IProductOptionService
    {
        private readonly IProductOptionRepository _productOptionRepository;
        public ProductOptionService(IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }
        public void CreateOption(Guid productId, ProductOption option)
        {
            _productOptionRepository.CreateOption(productId,option);
        }

        public void DeleteOption(Guid id)
        {
            _productOptionRepository.DeleteOption(id);
        }

        public ProductOption GetOption(Guid productId, Guid id)
        {
            if (_productOptionRepository.GetOption( id).IsNew)
            {
                throw new Exception();
            }
            else {
                return _productOptionRepository.GetOption( id);  
            }
            
        }

        public List<ProductOption> GetOption()
        {
            return _productOptionRepository.GetOption();
           
        }

        public List<ProductOption> GetOptions(Guid productId)
        {
            return _productOptionRepository.GetOptions(productId);
           
        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            _productOptionRepository.UpdateOption(id,option);
        }
    }
}
