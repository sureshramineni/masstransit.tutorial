using Common.DB;
using Common.flow.Allocate;
using Common.flow.Initialize;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.flow.Construct
{
    public partial class Constructor<TMessage, TConstructed>
    {
        public Guid CorrelationId { get; set; }

        private async Task<Response<CacheCreated>> Allocate(TMessage message,
            ConsumeContext<ConstructEnvelope> context,
            CancellationToken token)
        {
            var allocateMessage = AllocateEnvelope.Create(message);
            var allocateResponse = await _allocateClient
                .GetResponse<CacheCreated>(allocateMessage)
                .ConfigureAwait(false);
            await OnAllocated(allocateResponse, token)
                .ConfigureAwait(false);
            return allocateResponse;

        }

        private async Task<Response<CacheUpdated>> Initialize(TMessage message,
            ConsumeContext<ConstructEnvelope> context,
            CancellationToken token)
        {
            var initializeMessage = InitializeEnvelope.Create(message);
            var initializeResponse = await _initializeClient
                .GetResponse<CacheUpdated>(initializeMessage)
                .ConfigureAwait(false);
            await OnInitialized(initializeResponse, token)
                .ConfigureAwait(false);
            return initializeResponse;

        }

        private Task OnInitialized(
            Response<CacheUpdated> initializeResponse,
            CancellationToken token)
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnAllocated(
            Response<CacheCreated> allocateResponse,
            CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
