﻿using LIT.Smabu.Domain.Exceptions;
using LIT.Smabu.Domain.InvoiceAggregate.Specifications;
using LIT.Smabu.Domain.OfferAggregate.Specifications;
using LIT.Smabu.Domain.SeedWork;

namespace LIT.Smabu.Domain.CustomerAggregate.Services
{
    public class DeleteCustomerService(IAggregateStore aggregateStore)
    {
        public async Task DeleteAsync(CustomerId id)
        {
            await CheckInvoices(id);
            await CheckOffers(id);

            var customer = await aggregateStore.GetByAsync(id);
            customer.Delete();
            await aggregateStore.DeleteAsync(customer);
        }

        private async Task CheckOffers(CustomerId id)
        {
            var offers = await aggregateStore.ApplySpecification(new OffersByCustomerIdSpec(id));
            if (offers.Any())
            {
                throw new DomainException("Es sind bereits Angebote verknüpft.", id);
            }
        }

        private async Task CheckInvoices(CustomerId id)
        {
            var invoices = await aggregateStore.ApplySpecification(new InvoicesByCustomerIdSpec(id));
            if (invoices.Any())
            {
                throw new DomainException("Es sind bereits Rechnungen verknüpft.", id);
            }
        }
    }
}
