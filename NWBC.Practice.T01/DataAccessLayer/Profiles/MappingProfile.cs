using AutoMapper;
using Common.DTOs;
using DataLayer.Migration;

namespace DataAccessLayer.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryDto, Category>()
            .ForMember(dest => dest.Products, init 
                => init.MapFrom<ProductResolver>());
        
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Category, init =>
                init.MapFrom<CategoryResolver>())
            ;

        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ProductIds, opt
                => opt.MapFrom(src => src.Products.Select(p => p.Id).ToList()));

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryId, opt 
                => opt.MapFrom(src => src.Category.Id));
        
    }
    
}