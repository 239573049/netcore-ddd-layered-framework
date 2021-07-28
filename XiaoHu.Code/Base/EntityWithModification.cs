﻿using System;

namespace XiaoHu.Core.Base
{
    public class EntityWithModification : IHaveModification
    {
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}