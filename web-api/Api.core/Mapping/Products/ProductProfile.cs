using AutoMapper;

namespace Api.Core.Mapping.Products
{
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            GetProductByIdMapping();
        }
    }
}
