﻿using LIT.Smabu.Domain.InvoiceAggregate;
using LIT.Smabu.Domain.SeedWork;
using LIT.Smabu.UseCases.SeedWork;

namespace LIT.Smabu.UseCases.Invoices.Release
{
    public class ReleaseInvoiceHandler(IAggregateStore aggregateStore) : ICommandHandler<ReleaseInvoiceCommand, InvoiceDTO>
    {
        public async Task<InvoiceDTO> Handle(ReleaseInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await aggregateStore.GetByAsync(request.Id);
            var customer = await aggregateStore.GetByAsync(invoice.CustomerId);
            var number = request.Number ?? await CreateNewNumberAsync(invoice.FiscalYear);
            invoice.Release(number, request.ReleasedOn);
            await aggregateStore.UpdateAsync(invoice);
            return InvoiceDTO.From(invoice, customer);
        }

        private async Task<InvoiceNumber> CreateNewNumberAsync(int year)
        {
            var lastNumber = (await aggregateStore.GetAllAsync<Invoice>())
                .Select(x => x.Number)
                .Where(x => !x.IsTemporary && x.Value.ToString().StartsWith(year.ToString()))
                .OrderByDescending(x => x)
                .FirstOrDefault();

            return lastNumber == null ? InvoiceNumber.CreateFirst(year) : InvoiceNumber.CreateNext(lastNumber);
        }
    }
}