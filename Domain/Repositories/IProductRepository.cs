using Domain.Entity;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> GetProduct(ulong companyPrefix, ulong itemReference);
    }
}
