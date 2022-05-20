using AutoMapper;
using WebApp.Models;

namespace WebApp.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);
    }

    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(SqlDataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var entity = _mapper.Map<ProductEntity>(product);
            return _mapper.Map<Product>(await CreateAsync(entity));
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await DeleteAsync(id);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return _mapper.Map<Product>(await ReadAsync(id));
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return _mapper.Map<List<Product>>(await ReadAsync());
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var entity = _mapper.Map<ProductEntity>(product);
            return _mapper.Map<Product>(await UpdateAsync(id, entity));
        }
    }
}
