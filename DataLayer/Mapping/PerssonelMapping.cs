using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Perssonel;

namespace DataLayer.Mapping
{
   public class PerssonelMapping:EntityTypeConfiguration<Perssonel>
    {
        public PerssonelMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.Amount_AvalDore).HasPrecision(20, 0);
            Property(w => w.PostalCode).HasMaxLength(20);
            Property(w => w.ContractCode).HasMaxLength(10);
            Property(w => w.HourPrice).HasPrecision(20, 0);
            Property(w => w.HouseRight).HasPrecision(20, 0);
            Property(w => w.ChildRight).HasPrecision(20, 0);
            Property(w => w.BaseSallary).HasPrecision(20, 0);
            Property(w => w.FullSallary).HasPrecision(20, 0);
            Property(w => w.OtherSallary).HasPrecision(20, 0);
            Property(w => w.BenLaborer).HasPrecision(20, 0);
            Property(w => w.KasrPrice).HasPrecision(20, 0);
            Property(w => w.EzafePrice).HasPrecision(20, 0);
            Property(w => w.Bime).HasPrecision(20, 0);
            Property(w => w.Eydi).HasPrecision(20, 0);
        }
    }
}
