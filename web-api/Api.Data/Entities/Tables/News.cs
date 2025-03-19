namespace Api.Data.Entities.Tables
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string ContentAr { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
