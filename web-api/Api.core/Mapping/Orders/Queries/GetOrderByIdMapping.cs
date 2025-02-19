using Api.Core.Features.Orders.Queries.Responses;
using Api.Data.Entities.Tables;

namespace Api.Core.Mapping.Orders
{
    public partial class OrderProfile
    {
        void GetOrderByIdMapping()
        {
            _ = CreateMap<Order, GetSingleOrderResponse>()
                 .ForMember(x => x.ProductId, opt => opt.MapFrom(src => src.ProductId))
                 .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(x => x.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(x => x.Size, opt => opt.MapFrom(src => src.Size))
                .ForMember(x => x.PicsCustom, opt => opt.MapFrom(src => src.PicsCustom))
                .ForMember(x => x.Notes, opt => opt.MapFrom(src => src.Notes));
        }
    }
    /*
      public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public DateTime Date { get; set; }

        public string Size { get; set; } // Assuming sizes are stored as a comma-separated string

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

        public List<string> PicsCustom { get; set; } = new List<string>();
     */
}
