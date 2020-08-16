using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MassTransit;
using MassTransit.Azure.ServiceBus;
using MassTransit.Azure.ServiceBus.Core;
using Common;

[assembly: FunctionsStartup(typeof(masstransit.azurefunctions.Startup))]
namespace masstransit.azurefunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddScoped<SubmitOrderFunctions>()
                .AddMassTransitForAzureFunctions(cfg =>
                {
                    cfg.AddConsumer<FlightOrderConsumer>();
                    //cfg.AddConsumer<SendMessageConsumer>();

                }, busconfig =>
                {
                    busconfig.PrefetchCount = 10;
                    busconfig.AutoStart = true;
                    busconfig.EnableDeadLetteringOnMessageExpiration = true;
                });
        }
    }
}
