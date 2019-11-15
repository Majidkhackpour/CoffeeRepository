using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Account;

namespace DataLayer.Mapping
{
    class AccountMapping:EntityTypeConfiguration<Account>
    {
        public AccountMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.Half_Code).HasMaxLength(10);
            Property(w => w.DateSabt).HasMaxLength(15);
            Property(w => w.Amounth).HasPrecision(20, 0);
        }
    }
}
