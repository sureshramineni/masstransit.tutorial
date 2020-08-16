using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface OrderSubmitted
    {
        string OrderId { get; }
        DateTime OrderDate { get; }
    }
}
