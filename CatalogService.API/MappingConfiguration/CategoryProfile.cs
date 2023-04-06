using AutoMapper;
using CatalogService.Application.ViewModels;
using CatalogService.Core;

namespace CatalogService.API.MappingConfiguration
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryViewModel, Category>();
        }
    }
}