namespace PersonalBloggingPlatformAPI.Domain.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; } = null!;
        public List<Article>? Articles { get; set; }
    }
}
