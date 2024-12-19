using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace POC_Teijin.Repository
{
    public class ModelConfig : IEntityTypeConfiguration<Sensores>
    {
        public void Configure(EntityTypeBuilder<Sensores> builder)
        {
            builder.ToTable("Sensores");
            builder.HasKey(s => s.Id);
        }
    }
}
