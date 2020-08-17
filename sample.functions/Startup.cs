using MassTransit;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(sample.functions.Startup))]
namespace sample.functions
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddScoped<SubmitOrderFunctionHost>()
                .ConfigureApp()
            .AddMassTransitForAzureFunctions(cfg => cfg.CongfigureCreateProductConstruct()
              , busconfig =>
             {
                 busconfig.AutoStart = true;
                 busconfig.EnableDeadLetteringOnMessageExpiration = true;
                 var provider = builder.Services.BuildServiceProvider();
                 busconfig.ConfigureEndpoints(provider);
             });
        }
    }
}
