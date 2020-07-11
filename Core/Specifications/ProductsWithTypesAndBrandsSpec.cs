using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpec()
        {
            AddInclueExpr(x => x.ProductBrand);
            AddInclueExpr(x => x.ProductType);
        }

        public ProductsWithTypesAndBrandsSpec(int id) 
            : base(x => x.Id == id)
        {
            AddInclueExpr(x => x.ProductBrand);
            AddInclueExpr(x => x.ProductType);
            
        }
    }
}