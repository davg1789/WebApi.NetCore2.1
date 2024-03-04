using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroWebApi.Data.SqlServer.Extension
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
