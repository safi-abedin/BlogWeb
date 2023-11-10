using Autofac;
using Blog.Web.Models.Domain;

namespace Blog.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Tag>().As<IBLogPost>();
        }
    }
}
