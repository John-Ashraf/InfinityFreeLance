using Api.Core.Features.Orders.Commands.Models;
using Api.Data.Entities.Tables;



namespace Api.Core.Mapping.Orders
{
    public partial class OrderProfile
    {
        void AddOrderMapping()
        {
            _ = CreateMap<AddOrderCommand, Order>()
                .ForMember(x => x.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(x => x.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(x => x.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.Size, opt => opt.MapFrom(src => src.size))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.Notes, opt => opt.MapFrom(src => src.Notes));
        }
    }
}
