using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Common;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using MassTransit.WebJobs.ServiceBusIntegration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace masstransit.azurefunctions
{
    public class SubmitOrderFunctions
    {
       
        readonly IPublishEndpoint _publishEndPoint;
        readonly IMessageReceiver _reciever;
        public SubmitOrderFunctions(IPublishEndpoint publishEndPoint, IMessageReceiver reciever)
        {
            _publishEndPoint = publishEndPoint;
            _reciever = reciever;
        }

        [FunctionName("PublishFlight")]
        public async Task<IActionResult> NotifyFlightPublished(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
        {
            await _publishEndPoint.Publish<FlightOrder>(new FlightOrder { FlightId = Guid.NewGuid(), OrderId = 1000 });
            return new OkObjectResult("Flight Published successfully");
        }

        [FunctionName(nameof(FlightOrderConsumer))]
        public async Task NotifyFlightCancellation(
           [ServiceBusTrigger(nameof(FlightOrderConsumer))] Microsoft.Azure.ServiceBus.Message message,
               CancellationToken token)
        {
            await _reciever.HandleConsumer<FlightOrderConsumer>(nameof(FlightOrderConsumer), message, token);
        }
    }
}
