namespace Api.Core.Features.NewsFeatures.Queries.Responses
{
    public class SingleNewsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Content { get; set; }
        public string ContentAr { get; set; }
        public string Photo { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
