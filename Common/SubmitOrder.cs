using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface SubmitOrder
    {
        string OrderId { get; }
        DateTime OrderDate { get; }
        decimal OrderAmount { get; }
    }
}
