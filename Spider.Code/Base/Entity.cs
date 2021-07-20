﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spider.Core.Base
{
    public abstract class Entity : Entity<Guid> { }

    public abstract class Entity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }
    }
}