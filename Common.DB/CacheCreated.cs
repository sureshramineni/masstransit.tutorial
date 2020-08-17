using MassTransit;
using System;

namespace Common.DB
{
    public class CacheCreated : CorrelatedBy<Guid?>
    {
        public Guid? CorrelationId { get; set; } 
    }
}
