﻿using Spider.Core.Base;
using Spider.EntityFrameworkCore.Core;
using System;

namespace Spider.EntityFrameworkCore.Repository
{
    public class MasterDbRepositoryBase<TEntity> : EfRepository<MasterDbContext, TEntity, Guid>, IMasterDbRepositoryBase<TEntity, Guid> where TEntity : Entity<Guid>
    {
        public MasterDbRepositoryBase(MasterDbContext dbContext)
            : base(dbContext)
        {

        }
    }
    public class MasterDbRepositoryBase<TEntity, TKey> : EfRepository<MasterDbContext, TEntity, TKey>, IMasterDbRepositoryBase<TEntity, TKey> where TEntity : Entity<TKey>
    {
        public MasterDbRepositoryBase(MasterDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
