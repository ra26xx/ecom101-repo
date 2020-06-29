using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<List<ProductType>> GetAllProductTypesAsync();
        Task<List<ProductBrand>> GetAllProductBrandsAsync();
    }
}