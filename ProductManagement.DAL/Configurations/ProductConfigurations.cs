using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.DAL.Models;

namespace ProductManagement.DAL.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.HasOne(o => o.Order)
               .WithMany(p => p.Products);

        builder.ToTable(p =>
        {
            p.HasCheckConstraint("CK_Product_Price_NonNegative", "Price >= 0");
            p.HasCheckConstraint("CK_Product_Stock_NonNegative", "Stock >= 0");
        });

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(p => p.Description)
               .IsRequired()
               .HasMaxLength(500); 
    }
}
