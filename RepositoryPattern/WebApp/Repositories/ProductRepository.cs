using AutoMapper;
using WebApp.Models;

namespace WebApp.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> CreateProductAsync(ProductCreateRequest product);
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetProductAsync(int id);
        public Task<Product> UpdateProductAsync(int id, ProductUpdateRequest product);
        public Task<bool> DeleteProductAsync(int id);
    }

    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(ProductCreateRequest product)
        {
            var _entity = _mapper.Map<ProductEntity>(product);
            return _mapper.Map<Product>(await CreateAsync(_entity));
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return _mapper.Map<List<Product>>(await GetAsync());
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return _mapper.Map<Product>(await GetAsync(id));
        }

        public async Task<Product> UpdateProductAsync(int id, ProductUpdateRequest product)
        {
            var _entity = _mapper.Map<ProductEntity>(product);
            return _mapper.Map<Product>(await UpdateAsync(id, _entity));
        }
    }
}
