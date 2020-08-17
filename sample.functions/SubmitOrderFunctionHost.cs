using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Architecture.foundation.Construction.app;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace sample.functions
{
    public class SubmitOrderFunctionHost
    {
        readonly IPublishEndpoint _publishEndPoint;
        public SubmitOrderFunctionHost(IPublishEndpoint publishEndPoint)
        {
            _publishEndPoint = publishEndPoint;
        }
        [FunctionName("SubmitOrderHttp")]
        public async Task<IActionResult> NotifyOrderSubmitHttp(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest request,
                ILogger logger)
        {
            var requestbody = await new StreamReader(request.Body)
                .ReadToEndAsync()
                .ConfigureAwait(false);
            var data = JsonConvert.DeserializeObject<SubmitOrderRequest>(requestbody) ?? new SubmitOrderRequest() { OrderId = 123, OrderName = "table", OrderQuantity = 10 };
            data = new SubmitOrderRequest() { OrderId = 123, OrderName = "table", OrderQuantity = 10 };
            var id = NewId.NextGuid();
            await _publishEndPoint.Publish(data, x => x.MessageId = id)
                .ConfigureAwait(false);
            return new OkObjectResult($"Message sent with id: {id}.");
        }
    }
}
