using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Anbar;

namespace DataLayer.Mapping
{
    class AnbarGroupMapping:EntityTypeConfiguration<AnbarGroup>
    {
        public AnbarGroupMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
        }
    }
}
