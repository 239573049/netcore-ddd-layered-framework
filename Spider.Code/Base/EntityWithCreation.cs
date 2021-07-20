using System;

namespace Spider.Core.Base
{
    public class EntityWithCreation : IHaveCreation
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}