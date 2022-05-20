using AutoMapper;

namespace WebApp.Models
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductEntity, Product>().ReverseMap();
            CreateMap<ProductCreateRequest, ProductEntity>();
            CreateMap<ProductUpdateRequest, ProductEntity>();
        }
    }
}
