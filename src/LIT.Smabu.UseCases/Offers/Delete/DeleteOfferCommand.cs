﻿using LIT.Smabu.Domain.OfferAggregate;
using LIT.Smabu.UseCases.SeedWork;

namespace LIT.Smabu.UseCases.Offers.Delete
{
    public record DeleteOfferCommand : ICommand<bool>
    {
        public required OfferId Id { get; set; }
    }
}
