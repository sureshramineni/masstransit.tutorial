using Common.flow.Allocate;
using Common.flow.Initialize;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.flow.Construct
{
    public partial class Constructor<TMessage, TConstructed>
        where TMessage : class, new()
        where TConstructed : class, CorrelatedBy<Guid?>, new()
    {
        private readonly ILogger<Constructor<TMessage, TConstructed>> _logger;
        private readonly IRequestClient<AllocateEnvelope> _allocateClient;
        private readonly IRequestClient<InitializeEnvelope> _initializeClient;

        protected TMessage Message { get; set; }

        public Constructor(ILogger<Constructor<TMessage, TConstructed>> logger,
            IRequestClient<AllocateEnvelope> allocateClient,
            IRequestClient<InitializeEnvelope> initializeClient)
        {
            _allocateClient = allocateClient;
            _initializeClient = initializeClient;
            _logger = logger;
        }
    }
}
