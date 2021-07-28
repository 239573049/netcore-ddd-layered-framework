using System;

namespace Spider.Core.Base
{
    public interface IHaveCreation : IHaveCreatedTime
    {
        Guid? CreatedBy { get; set; }
    }

    public interface IHaveCreatedTime
    {
        DateTime? CreatedTime { get; set; }
    }
}