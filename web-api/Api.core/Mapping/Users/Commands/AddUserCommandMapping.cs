using Api.Core.Features.Users.Commands.Models;
using Api.Data.Entities.Identity;

namespace Api.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void AddUserMapping()
        {
            _ = CreateMap<AddUserCommand, AppUser>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FullName))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Photo, opt => opt.MapFrom(x => x.Photo))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber));


        }
    }
}
