using System.Data.Entity.ModelConfiguration;
using DataLayer.Models.Settings;

namespace DataLayer.Mapping
{
    class AppSettingMapping : EntityTypeConfiguration<AppSetting>
    {
        public AppSettingMapping()
        {
            HasKey(w => w.Guid);
            Property(w => w.DateSabt).HasMaxLength(15);
        }
    }
}
