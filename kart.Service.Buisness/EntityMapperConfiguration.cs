
using AutoMapper;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;

namespace kart.Service.Buisness
{
    public class EntityMapperConfiguration
    {
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperWebProfile>();
            });
        }

        public class AutoMapperWebProfile: Profile
        {
            public AutoMapperWebProfile()
            {
                CreateMap<Product, ProductResponseModel>().ReverseMap();
                CreateMap<Cart, CartResponseModel>().ReverseMap();

            }
        }
    }
}
