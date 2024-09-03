

using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{

    internal class TerritorialUnitConfiguration : IEntityTypeConfiguration<TerritorialUnit>
    {
        public void Configure(EntityTypeBuilder<TerritorialUnit> builder)
        {

        }
    }
}

