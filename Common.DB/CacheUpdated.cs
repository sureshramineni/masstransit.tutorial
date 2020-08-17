using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DB
{
    public class CacheUpdated : CorrelatedBy<Guid?>
    {
        public Guid? CorrelationId { get; set; }
    }
}
