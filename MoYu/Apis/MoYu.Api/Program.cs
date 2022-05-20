using Authenticates;
using Entities;
using Inject;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoYu.Api.Data;
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