using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Customer;

namespace DataLayer.Mapping
{
   public class CustomersMapping : EntityTypeConfiguration<Customers>
    {
        public CustomersMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
            Property(w => w.Code).HasMaxLength(10);
            Property(w => w.Amount_AvalDore).HasPrecision(20, 0);
            Property(w => w.PostalCode).HasMaxLength(20);
            Property(w => w.Half_Code).HasMaxLength(10);
            Property(w => w.HadeEtebar).HasPrecision(20, 0);
            Property(w => w.DateBirth).HasMaxLength(15);
            Property(w => w.SubCode).HasMaxLength(10);
        }
    }
}
