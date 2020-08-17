using Architecture.foundation.Construction.app.Interface;
using Common.flow.Allocate;
using Common.flow.Initialize;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Architecture.foundation.Construction.app
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection ConfigureCreateOrderConstructor(
            this IServiceCollection self,
            Func<IServiceProvider, IRequestClient<AllocateEnvelope>> allocateFactory,
            Func<IServiceProvider, IRequestClient<InitializeEnvelope>> initializeFactory)
            => self.AddTransient(allocateFactory)
            .AddTransient(initializeFactory)
            .AddScoped<ICreateOrderConstructor, CreateOrderConstructor>();
    }
}

