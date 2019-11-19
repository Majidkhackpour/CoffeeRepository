using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Perssonel;

namespace DataLayer.Mapping
{
   public class PerssonelGroupMapping:EntityTypeConfiguration<PerssonelGroup>
    {
        public PerssonelGroupMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
        }
    }
}
