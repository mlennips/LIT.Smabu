﻿using LIT.Smabu.Domain.SeedWork;

namespace LIT.Smabu.Domain.OfferAggregate.Specifications
{
    public class LastOfferSpec : Specification<Offer>
    {
        public LastOfferSpec() : base(x => true)
        {
            OrderByDescendingExpression = x => x.Number.Long;
            Take = 1;
        }
    }
}
