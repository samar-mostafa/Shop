using AutoMapper;
using Shop.Entities.Models;
using Shop.Entities.ViewModels;

namespace Shop.Web.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductVM,Product>().ReverseMap();
        }
    }
}
