using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.PhoneBook;

namespace DataLayer.Mapping
{
   public class PhoneBookMapping:EntityTypeConfiguration<PhoneBook>
    {
        public PhoneBookMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
            Property(w => w.PostalCode).HasMaxLength(20);
        }
    }
}
