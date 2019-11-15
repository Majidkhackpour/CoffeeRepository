using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Account;

namespace DataLayer.Mapping
{
    class MoeinHesabMapping:EntityTypeConfiguration<MoeinHesab>
    {
        public MoeinHesabMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.Half_Code).HasMaxLength(10);
            Property(w => w.DateSabt).HasMaxLength(15);
        }
    }
}
