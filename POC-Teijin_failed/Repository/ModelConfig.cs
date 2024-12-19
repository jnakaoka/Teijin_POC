using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POC_Teijin.Repository
{
    public class ModelConfig : IEntityTypeConfiguration<Sensores_old>
    {
        public void Configure(EntityTypeBuilder<Sensores_old> builder)
        {
            builder.ToTable("Sensores");
            builder.HasKey(s => s.Id);
        }
    }
}
