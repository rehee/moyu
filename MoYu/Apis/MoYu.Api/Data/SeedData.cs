using Entities;
using Microsoft.AspNetCore.Identity;
using MiniExcelLibs;
using Modules;
using MoYu.Common.Items;
using MoYu.Entities.BluePrints.Equips.Weapons;
using System;

namespace MoYu.Api.Data
{
  public class SeedData : IDisposable
  {
    private readonly ApplicationDbContext context;
    private readonly RoleManager<IdentityRole> rm;
    private readonly UserManager<ReheeCmfBaseUser> um;
    private readonly IServiceProvider sp;

    public SeedData(ApplicationDbContext context, RoleManager<IdentityRole> rm, UserManager<ReheeCmfBaseUser> um, IServiceProvider sp)
    {
      this.context = context;
      this.rm = rm;
      this.um = um;
      this.sp = sp;
    }

    public void Dispose()
    {
      context.Dispose();
      rm.Dispose();
      um.Dispose();
    }

    public async Task InitData()
    {
      await InitRoleAndDefaultAdmin();
      await InitWeapon();
    }
    public async Task InitWeapon()
    {
      var rootFolder = Directory.GetCurrentDirectory();
      var file = $"{rootFolder}/Data/DataInput.xlsm";
      var weaponBases = MiniExcel.Query<WeaponBaseBluePrint>(file, "WeaponBase").ToArray();
      var weapons = MiniExcel.Query<WeaponBluePrint>(file, "Weapon").ToArray();
      foreach (var w in weaponBases)
      {
        context.Add(w);
      }
      await context.SaveChangesAsync();

      var wps = context.WeaponBluePrints.ToArray();
      foreach (var wp in wps)
      {
        var wpInput = weapons.Where(b => wp.BaseWeapon.Name == b.BaseName && b.Material == wp.Material).FirstOrDefault();
        if(wpInput == null)
        {
          continue;
        }
        wp.Name = wpInput.Name;
        wp.DamageMin = wpInput.DamageMin;
        wp.DamageMax = wpInput.DamageMax;
        wp.Durability = wpInput.Durability;
        wp.QualityLevel = wpInput.QualityLevel;
      }

      await context.SaveChangesAsync();

    }

    public async Task InitRoleAndDefaultAdmin()
    {
      var r = await rm.CreateAsync(new IdentityRole()
      {
        Name = "Admin"
      });
      var u = new ReheeCmfBaseUser()
      {
        UserName = "u1",
        Email = "u1@u1.com"
      };
      var users = await um.CreateAsync(u, "Password123!");
      var addRoles = await um.AddToRoleAsync(u, "Admin");
      foreach (var module in ModuleOption.GetModuleBases(sp))
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
}
