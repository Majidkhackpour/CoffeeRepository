using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Account;

namespace DataLayer.Mapping
{
    class AccountGroupMapping:EntityTypeConfiguration<AccountGroup>
    {
        public AccountGroupMapping()
        {
            HasKey(t => t.Guid);
            Property(t => t.Aouth_Code).HasMaxLength(10);
            Property(t => t.DateSabt).HasMaxLength(15);
        }
    }
}
