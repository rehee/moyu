using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoYu.Entities.Characters;
using MoYu.Entities.Items.Equipments;
using ReheeCmf.DBContext;

namespace MoYu.Api.Data
{
  public class ApplicationDbContext : ReheeCMFDBContext<ReheeCmfBaseUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
  }
}