using System.ComponentModel.DataAnnotations;
using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Common.Models
{
    public class CategoryDto : BaseDto, IMapFrom<Category>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>();
            profile.CreateMap<CategoryDto, Category>();
        }
    }
}
