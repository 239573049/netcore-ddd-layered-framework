﻿using System;

namespace Spider.Core.Base
{
    public interface IHaveModification : IHaveModifiedTime
    {
        Guid? ModifiedBy { get; set; }
    }

    public interface IHaveModifiedTime
    {
        DateTime? ModifiedTime { get; set; }
    }
}