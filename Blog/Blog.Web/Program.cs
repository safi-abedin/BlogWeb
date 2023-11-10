using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blog.Web;
using Blog.Web.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


//Serilog Configuration
builder.Host.UseSerilog((ctx, lc) => lc
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration)
);

try
{
    //Autofac Configuration 
    builder.Host.UseServiceProviderFactory(x => new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(x =>
    {
        x.RegisterModule(new WebModule());
    });


    // Add services to the container.
    builder.Services.AddControllersWithViews();


    builder.Services.AddDbContext<AplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnectionString"))
    );

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch(Exception ex)
{
    Log.Information(ex, "something went Wrong");
}
finally
{
    Log.CloseAndFlush();
}


