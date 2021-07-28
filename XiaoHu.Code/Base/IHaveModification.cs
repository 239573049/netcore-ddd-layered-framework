using System;

namespace XiaoHu.Core.Base
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