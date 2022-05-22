using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoYu.Entities.BluePrints.Equips.Weapons;
using ReheeCmf.DBContext;

namespace MoYu.Api.Data
{
  public class ApplicationDbContext : ReheeCMFDBContext<ReheeCmfBaseUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<WeaponBaseBluePrint> WeaponBaseBluePrints { get; set; }
    public DbSet<WeaponBluePrint> WeaponBluePrints { get; set; }
  }
}