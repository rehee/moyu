using Entities;
using Microsoft.AspNetCore.Identity;
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
      var sword = new WeaponBaseBluePrint()
      {
        WeaponType = EnumWeaponType.Sword,
        WeaponHand = EnumWeaponHand.OneHand,
        AttackSpeed = 1.2m,
        Name = "单手剑"
      };
      context.Add(sword);
      await context.SaveChangesAsync();
      foreach (var s in sword.Weapons.ToArray())
      {
        switch (s.Material)
        {
          case EnumItemMaterial.Normal:
            s.Name = "单手剑";
            s.DamageMin = 1;
            s.DamageMax = 6;
            s.QualityLevel = 1;
            break;
          case EnumItemMaterial.Extend:
            s.Name = "扩展单手剑";
            s.DamageMin = 12;
            s.DamageMax = 24;
            s.QualityLevel = 24;
            break;
          case EnumItemMaterial.Elite:
            s.Name = "精英单手剑";
            s.DamageMin = 36;
            s.DamageMax = 48;
            s.QualityLevel = 48;
            break;
        }
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
