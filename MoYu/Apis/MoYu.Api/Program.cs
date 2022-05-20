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
        using (var rm = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>())
        {
          var r = await rm.CreateAsync(new IdentityRole()
          {
            Name = "Admin"
          });
        }
        using (var um = scope.ServiceProvider.GetRequiredService<UserManager<ReheeCmfBaseUser>>())
        {
          var u = new ReheeCmfBaseUser()
          {
            UserName = "u1",
            Email = "u1@u1.com"
          };
          var users = await um.CreateAsync(u, "Password123!");
          var addRoles = await um.AddToRoleAsync(u, "Admin");
          foreach (var module in ModuleOption.GetModuleBases(scope.ServiceProvider))
          {
            var adminPermissionResponse = await module.GetRoleBasedPermissionAsync("Admin", "");
            if (adminPermissionResponse.Success)
            {
              foreach (var permission in adminPermissionResponse.Content.Items)
              {
                permission.Value = "True";
              }
              var result = await module.UpdateRoleBasedPermissionAsync("Admin", adminPermissionResponse.Content, "");
            }
          }
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