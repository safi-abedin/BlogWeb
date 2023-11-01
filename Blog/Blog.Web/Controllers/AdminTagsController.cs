using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private AplicationDbContext _aplicationDbContext { get; }
        public AdminTagsController(AplicationDbContext aplicationDbContext) 
        {
            _aplicationDbContext = aplicationDbContext;
        }

        

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            //Mapping AddTagRequest to tag model
            var data = new Tag
            {

                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };
            _aplicationDbContext.Tags.Add(data);
            return View();
        }
    }
}
