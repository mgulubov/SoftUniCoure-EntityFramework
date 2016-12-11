using AutoMapper;

namespace ProductShop.Services.AutoMapper
{
    using Models;
    using DTO;

    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<User, UserDto>();
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<Category, CategoryDto>();
            });
        }
    }
}
