using Authenticates;
using Entities;
using FluentEmail.Core;
using Inject;
using JWT;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules;
using MoYu.Api.Data;
using MoYu.Common;
using ODataControllers;
using ReheeCmf.AdminPages;
using ReheeCmf.Frameworks;

namespace MoYu.Api
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      PropertyInject.Provider = host.Services;
      using (var scope = host.Services.CreateScope())
      {
        using (var sd = scope.ServiceProvider.GetRequiredService<SeedData>())
        {
          await sd.InitData();

        }
        
      }
      using (var scope = host.Services.CreateScope())
      {
        
        using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
        {
          General.Affixes = context.AffixBluePrints.ToArray();
        }
      }
      host.Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}