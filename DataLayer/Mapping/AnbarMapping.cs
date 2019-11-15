using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Anbar;

namespace DataLayer.Mapping
{
    class AnbarMapping:EntityTypeConfiguration<Anbar>
    {
        public AnbarMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
        }
    }
}
