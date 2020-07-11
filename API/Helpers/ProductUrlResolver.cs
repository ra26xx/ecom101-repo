using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductResponseDto, string>
    {
        private const string V = "ApiUrl";
        private readonly IConfiguration _config; //Microsoft.Extensions (NOT Automapper's)
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.ImageUrl))
           {
               return _config[V] + source.ImageUrl;
           }
           return null;
        }
    }
}