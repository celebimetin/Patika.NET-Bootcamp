using AutoMapper;
using Core.DtoModels;
using Data.Domain;

namespace Schema.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, UserApp>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();

            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<CategoryUpdateRequest, Category>();

            CreateMap<Product, ProductResponse>();
            CreateMap<ProductRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>();

            CreateMap<Kupon, KuponResponse>();
            CreateMap<KuponRequest, Kupon>();
        }
    }
}