using MassTransit;
using System;

namespace Common.flow.Initialize
{
    public class InitializeEnvelope : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public static InitializeEnvelope Create<T>(T message)
            where T : new()
        {
            return new InitializeEnvelope
            {

            };

        }
    }
}
