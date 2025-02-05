using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string? Title { get; set; }
        public byte[]? Photo { get; set; }
        public string PhoneNumber { get; set; }
    }
}
