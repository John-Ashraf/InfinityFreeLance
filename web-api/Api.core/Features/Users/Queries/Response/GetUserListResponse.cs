namespace Api.Core.Features.Users.Queries.Response
{
    public class GetUserListResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Title { get; set; }
        public byte[]? Photo { get; set; }

    }
}
