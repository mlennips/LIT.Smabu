﻿using LIT.Smabu.Domain.SeedWork;

namespace LIT.Smabu.Domain.OrderAggregate
{
    public class Order : Entity<OrderId>
    {
        public override OrderId Id => throw new NotImplementedException();
    }
}

