using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.BankHesab;

namespace DataLayer.Mapping
{
   public class BanksMapping : EntityTypeConfiguration<Banks>
    {
        public BanksMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.HalfCode).HasMaxLength(10);
            Property(w => w.DateSabt).HasMaxLength(15);
            Property(w => w.DateEftetah).HasMaxLength(15);
            Property(w => w.AmountAvalDore).HasPrecision(20, 0);
        }
    }
}
