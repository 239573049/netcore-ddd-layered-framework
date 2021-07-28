﻿using System;

namespace Spider.Core.Base
{
    public class EntityWithSoftDelete : IHaveDeletion
    {
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}