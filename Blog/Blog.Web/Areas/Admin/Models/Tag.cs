namespace Blog.Web.Areas.Admin.Models
{
    public class Tag:IBlogPost
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
