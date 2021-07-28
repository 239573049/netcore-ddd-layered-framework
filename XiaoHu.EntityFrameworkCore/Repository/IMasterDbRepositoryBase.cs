using Spider.Core.Base;
using Spider.EntityFrameworkCore.Core;
using System;

namespace Spider.EntityFrameworkCore.Repository
{
    public interface IMasterDbRepositoryBase<TEntity> : IRepository<MasterDbContext, TEntity, Guid> where TEntity : Entity<Guid>
    {
        //void DeleteMany(object p);
    }

    public interface IMasterDbRepositoryBase<TEntity, TKey> : IRepository<MasterDbContext, TEntity, TKey> where TEntity : Entity<TKey> { }
}