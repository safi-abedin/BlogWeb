using Blog.Web.Areas.Admin.Models;
using Blog.Web.Controllers;
using Blog.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DataAddController : Controller
    {
        public IActionResult Data()
        {
            return View();
        }

        private readonly AplicationDbContext _aplicationDbContext;
        private readonly IBlogPost _bLogPost;
        private readonly ILogger<DataAddController> _logger;

        public DataAddController (AplicationDbContext aplicationDbContext,
                    IBlogPost bLogPost, ILogger<DataAddController> logger)
        {
            _aplicationDbContext = aplicationDbContext;
            _bLogPost = bLogPost;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult AddTag()
        {
            _logger.LogInformation("Admin trying to create a Tag");
            return View();
        }

        [HttpPost]
        public IActionResult AddTAg(Tag tag)
        {
            //Mapping AddTagRequest to tag model its call model binding
            var data = new Tag
            {
                Name = tag.Name,
                DisplayName = tag.DisplayName,
            };
            _aplicationDbContext.Tags.Add(data);
            _aplicationDbContext.SaveChanges();
            return View();
        }


        [HttpGet]
        public IActionResult AddPost()
        {
            _logger.LogInformation("Admin Trying to add a post");
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(BlogPost post)
        {
            var data = new BlogPost
            {
                Heading = post.Heading,
                PageTitle = post.PageTitle,
                Content = post.Content,
                ShortDescription = post.ShortDescription,
                FeaturedImageUrl = post.FeaturedImageUrl,
                Author = post.Author,
                PublishedDate = post.PublishedDate,
                Tags = post.Tags,
                UrlHandle = post.UrlHandle,
                Visible = post.Visible
            };
            _aplicationDbContext.BlogPosts.Add(data);
            _aplicationDbContext.SaveChanges();
            return View();
        }
    }
}
