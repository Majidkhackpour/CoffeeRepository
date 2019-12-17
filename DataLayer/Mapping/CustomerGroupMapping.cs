using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Customer;

namespace DataLayer.Mapping
{
    public class CustomerGroupMapping : EntityTypeConfiguration<CustomerGroup>
    {
        public CustomerGroupMapping()
        {
            HasKey(t => t.Guid);
            Property(t => t.DateSabt).HasMaxLength(15);
        }
    }
}
