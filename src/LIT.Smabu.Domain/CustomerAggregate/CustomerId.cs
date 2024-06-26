﻿using LIT.Smabu.Domain.SeedWork;

namespace LIT.Smabu.Domain.CustomerAggregate
{
    public record CustomerId(Guid Value) : EntityId<Customer>(Value);
}