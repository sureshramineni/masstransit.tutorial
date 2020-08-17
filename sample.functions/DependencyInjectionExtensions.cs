using Architecture.foundation.Construction.app;
using Common.flow.Allocate;
using Common.flow.Initialize;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.ExtensionsDependencyInjectionIntegration.MultiBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace sample.functions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollectionConfigurator CongfigureCreateProductConstruct(this IServiceCollectionConfigurator config)
        {
            config.AddConsumer<CreateOrderConstructor>();
            config.AddRequestClient<AllocateEnvelope>();
            config.AddRequestClient<InitializeEnvelope>();
            return config;
        }

        public static IServiceCollection ConfigureApp(this IServiceCollection self)
        {
            self.ConfigureCreateOrderConstructor(
                config => config.CreateRequestClient<AllocateEnvelope>(),
                config => config.CreateRequestClient<InitializeEnvelope>());
            return self;
        }
    }
}
