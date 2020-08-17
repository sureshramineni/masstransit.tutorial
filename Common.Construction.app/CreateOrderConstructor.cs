using Architecture.foundation.Construction.app.Interface;
using Common.flow.Allocate;
using Common.flow.Construct;
using Common.flow.Construct.Interface;
using Common.flow.Initialize;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.foundation.Construction.app
{
    public class CreateOrderConstructor : Constructor<SubmitOrderRequest, SubmitOrderResponse>, ICreateOrderConstructor
    {
        private readonly ILogger<CreateOrderConstructor> _logger;
        public CreateOrderConstructor(
            ILogger<CreateOrderConstructor> logger,
            IRequestClient<AllocateEnvelope> allocateClient,
            IRequestClient<InitializeEnvelope> initializeClient)
            : base(logger, allocateClient, initializeClient)
        {
            _logger = logger;
        }

    }
}
