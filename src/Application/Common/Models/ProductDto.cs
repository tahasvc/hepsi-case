using System.ComponentModel.DataAnnotations;
using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;
using Newtonsoft.Json;

namespace Application.Common.Models
{
    public class ProductDto : BaseDto, IMapFrom<Product>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
            profile.CreateMap<ProductDto, Product>();
        }
    }
}
