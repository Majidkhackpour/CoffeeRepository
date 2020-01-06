using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Sandooq;

namespace DataLayer.Mapping
{
   public class SafeMapping : EntityTypeConfiguration<Safe>
    {
        public SafeMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.HalfCode).HasMaxLength(10);
            Property(w => w.DateSabt).HasMaxLength(15);
            Property(w => w.AmountAvalDore).HasPrecision(20, 0);
        }
    }
}
