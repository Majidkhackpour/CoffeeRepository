using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Sellers;

namespace DataLayer.Mapping
{
   public class SellerMapping : EntityTypeConfiguration<Seller>
    {
        public SellerMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.Amount_AvalDore).HasPrecision(20, 0);
            Property(w => w.PostalCode).HasMaxLength(20);
            Property(w => w.Half_Code).HasMaxLength(10);
        }
    }
}
