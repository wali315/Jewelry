using Jewelry.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Elfie.Model.Map;
using Microsoft.EntityFrameworkCore;

namespace Jewelry.Data;

public class JewelryContext : IdentityDbContext<IdentityUser>
{
    public JewelryContext(DbContextOptions<JewelryContext> options)
        : base(options)
    {
    }

    public DbSet<UserRegMst> userRegMsts { get; set; }
    public DbSet<CatMst> catMsts { get; set; }

    public DbSet<BrandMst> brandMsts { get; set; }

    public DbSet<CertifyMst> CertifyMsts { get; set; }

    public DbSet<ProdMst> prodMsts { get; set; }

    public DbSet<GoldKrtMst> goldKrtMsts { get; set; }

    public DbSet<DimQltyMst> dimQltyMsts { get; set; }

    public DbSet<DimQltySubMst> dimQltySubMsts { get; set; }

    public DbSet<StoneQltyMst> stoneQltyMsts { get; set; }

    public DbSet<ItemDetails> itemDetails { get; set; }

    public DbSet<CartItem> cartItems { get; set; }



    public DbSet<pay> pays { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
