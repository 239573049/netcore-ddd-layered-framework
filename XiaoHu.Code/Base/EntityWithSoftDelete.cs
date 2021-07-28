﻿using System;

namespace XiaoHu.Core.Base
{
    public class EntityWithSoftDelete : IHaveDeletion
    {
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}