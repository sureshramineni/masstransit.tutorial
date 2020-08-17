using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.flow.Construct
{
    public class ConstructEnvelope : CorrelatedBy<Guid?>
    {
        public Guid? CorrelationId { get; set; }
    }
}
