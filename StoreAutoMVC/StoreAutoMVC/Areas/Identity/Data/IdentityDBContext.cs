using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreAutoMVC.Areas.Identity.Data;
using StoreAutoMVC.Models;

namespace StoreAutoMVC.Entity;
public class IdentityDBContext : IdentityDbContext<User>
{
    public IdentityDBContext(DbContextOptions<IdentityDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
