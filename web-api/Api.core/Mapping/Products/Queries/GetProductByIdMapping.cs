using Api.Core.Features.Products.Queries.Response;
using Api.Data.Entities.Tables;

namespace Api.Core.Mapping.Products
{
    public partial class ProductProfile
    {
        void GetProductByIdMapping()
        {
            _ = CreateMap<Product, GetProductByIdResponse>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(x => x.Photos, opt => opt.MapFrom(src => src.Photos))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(x => x.NameAr, opt => opt.MapFrom(src => src.NameAr));

        }
    }
}
