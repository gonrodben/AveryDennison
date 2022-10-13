using Domain.Entity;
using Domain.Repositories;

namespace Persistence
{
    public class ProductRepository : IProductRepository
    {
        Dictionary<string, Product> _products;
        public ProductRepository()
        {
            _products = new Dictionary<string, Product>();
        }

        public async Task AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Parameter value [product] can not be null");

            var key = BuildKey(product.CompanyPrefix, product.ItemReference);

            if (_products.ContainsKey(key))
                throw new InvalidOperationException($"Product with reference: {product.ItemReference} and company prefix: {product.CompanyPrefix} already exists");

            await Task.Run(() => _products.Add(key, product));
        }

        public async Task<Product> GetProduct(ulong companyPrefix, ulong itemReference)
        {
            var key = BuildKey(companyPrefix, itemReference);

            var result = await Task.Run(() =>
                _products.ContainsKey(key) ? _products[key] : null
            );
            return result;
        }

        private string BuildKey(ulong companyPrefix, ulong itemReference)
        {
            return $"{companyPrefix}|{itemReference}";
        }
    }
}
