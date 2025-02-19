using AutoMapper;

namespace Api.Core.Mapping.Orders
{
    public partial class OrderProfile : Profile
    {
        public OrderProfile()
        {
            AddOrderMapping();
            GetOrderByIdMapping();
        }
    }
}
