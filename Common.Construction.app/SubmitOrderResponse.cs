using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.foundation.Construction.app
{
    public class SubmitOrderResponse: CorrelatedBy<Guid?>
    {
        public Guid? CorrelationId { get; set; }
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int OrderQuantity { get; set; }
    }
}
