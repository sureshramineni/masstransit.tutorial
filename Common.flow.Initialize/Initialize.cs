using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.flow.Initialize
{
    public partial class Initialize<TMessage>
        where TMessage : class, new()
    {
        public TMessage Message { get; set; }
        private readonly ILogger<Initialize.Initialize<TMessage>> _logger;
        public Initialize(ILogger<Initialize.Initialize<TMessage>> logger)
        {
            _logger = logger;
        }
    }
}
