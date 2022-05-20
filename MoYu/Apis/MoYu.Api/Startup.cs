using Authenticates;
using Entities;
using Microsoft.AspNetCore.Http.Features;
using MoYu.Api.Data;
using MoYu.Common.Combats;
using MoYu.Service.Combats;
using MoYu.WorkerService;
using ODataControllers;
using ReheeCmf.AdminPages;
using ReheeCmf.Frameworks;

namespace MoYu.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<FormOptions>(options =>
      {
        options.MultipartBodyLengthLimit = long.MaxValue;
      });
      
      services.DetaultSetUpCmf<ApplicationDbContext, ReheeCmfBaseUser, RegisterDTO>(Configuration, typeof(Program));

     
      services.AddCors();
      services.AddSingleton<IAttackService, AttackService>();
      services.AddHostedService<Worker>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider sp)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();

      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        //app.UseReverseProxyHttpsEnforcer();
      }
     
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCors(cors => cors
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
        );
      app.UseStatusCodePages(async context =>
      {
        await Task.CompletedTask;

        if (context.HttpContext.Response.StatusCode == 401)
        {
          //context.HttpContext.Response.Redirect("/");
        }
        if (context.HttpContext.Response.StatusCode == 404)
        {
          context.HttpContext.Response.Redirect("/");
        }
      });
      
      //app.UseODataRouteDebug();

      //app.UseODataQueryRequest();




      // Add the OData Batch middleware to support OData $Batch
      //app.UseODataBatching();

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();


      app.UseEndpoints(endpoints =>
      {
        endpoints.ODataController(sp);
        endpoints.UseCmfAdmin(true);
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();

      });
    }
  }
}
