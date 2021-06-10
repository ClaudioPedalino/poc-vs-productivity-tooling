using System;
using System.Collections.Generic;
using System.Text;

namespace poc_vs_tooling.Core.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
