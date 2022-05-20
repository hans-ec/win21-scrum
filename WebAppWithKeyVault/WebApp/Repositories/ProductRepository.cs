using AutoMapper;
using WebApp.Models;

namespace WebApp.Repositories
{
    public interface IProduct
    {
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> GetListAsync(int take = 0);
    }

    public class ProductRepository : GenericRepository<ProductEntity>, IProduct
    {
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Product> GetAsync(int id)
        {
            return _mapper.Map<Product>(await ReadAsync(id));
        }

        public async Task<List<Product>> GetListAsync(int take = 0)
        {
            if(take > 0)
                return _mapper.Map<List<Product>>(await ReadListAsync(take));
            
            return _mapper.Map<List<Product>>(await ReadListAsync());
        }
    }
}
