using Autofac;
using Blog.Web.Areas.Admin.Models;

namespace Blog.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Tag>().As<IBlogPost>();
        }
    }
}
