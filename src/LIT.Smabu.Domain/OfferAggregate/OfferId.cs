﻿using LIT.Smabu.Domain.SeedWork;

namespace LIT.Smabu.Domain.OfferAggregate
{
    public record OfferId(Guid Value) : EntityId<Offer>(Value);
}
