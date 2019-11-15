using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Account;

namespace DataLayer.Mapping
{
    class HesabGroupMapping:EntityTypeConfiguration<HesabGroup>
    {
        public HesabGroupMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.DateSabt).HasMaxLength(15);
        }
    }
}
