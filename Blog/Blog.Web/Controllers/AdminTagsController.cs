using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly AplicationDbContext _aplicationDbContext;
        private readonly IBLogPost _bLogPost;
        private readonly ILogger<AdminTagsController> _logger;

        public AdminTagsController(AplicationDbContext aplicationDbContext,
                    IBLogPost bLogPost,ILogger<AdminTagsController> logger) 
        {
            _aplicationDbContext = aplicationDbContext;
            _bLogPost = bLogPost;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            _logger.LogInformation("Admin trying to create a Tag");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            //Mapping AddTagRequest to tag model its call model binding
            var data = new Tag
            {
                Name = tag.Name,
                DisplayName = tag.DisplayName,
            };
            _aplicationDbContext.Tags.Add(data);
            _aplicationDbContext.SaveChanges();
            return View(new Tag());
        }
    }
}
