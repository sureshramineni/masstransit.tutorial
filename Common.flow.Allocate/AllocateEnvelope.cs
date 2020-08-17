using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.flow.Allocate
{
    public partial class AllocateEnvelope : CorrelatedBy<Guid?>
    {
        public Guid? CorrelationId { get; set; }

        public static AllocateEnvelope Create<T>(T Message)
            where T : new()
         => new AllocateEnvelope
         {

         };
    }
}
