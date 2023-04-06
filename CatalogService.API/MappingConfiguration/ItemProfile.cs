using AutoMapper;
using CatalogService.Application.ViewModels;
using CatalogService.Core;

namespace CatalogService.API.MappingConfiguration
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemViewModel, Item>();
            CreateMap<ItemUpdateViewModel, Item>();
        }
    }
}
