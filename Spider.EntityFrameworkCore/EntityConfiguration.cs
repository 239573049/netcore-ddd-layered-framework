using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Spider.Core.Base;

namespace Spider.EntityFrameworkCore
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}
