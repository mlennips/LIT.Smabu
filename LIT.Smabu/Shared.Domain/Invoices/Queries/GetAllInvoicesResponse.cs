﻿using LIT.Smabu.Domain.Shared.Common;
using LIT.Smabu.Domain.Shared.Customers;

namespace LIT.Smabu.Domain.Shared.Invoices.Queries
{
    public class GetAllInvoicesResponse
    {
        public GetAllInvoicesResponse(InvoiceId id, CustomerId customerId, CustomerNumber customerNumber, string customerName, InvoiceNumber number,
            decimal amount, Currency currency, DatePeriod performance, int fiscalYear)
        {
            Id = id;
            CustomerId = customerId;
            CustomerNumber = customerNumber;
            CustomerName = customerName;
            Number = number;
            Amount = amount;
            Currency = currency;
            Performance = performance;
            FiscalYear = fiscalYear;
        }

        public InvoiceId Id { get; }
        public CustomerId CustomerId { get; }
        public CustomerNumber CustomerNumber { get; }
        public string CustomerName { get; }
        public InvoiceNumber Number { get; }
        public decimal Amount { get; }
        public Currency Currency { get; }
        public DatePeriod Performance { get; }
        public int FiscalYear { get; }

        public static GetAllInvoicesResponse Map(Invoice invoice, Customer customer)
        {
            return new GetAllInvoicesResponse(invoice.Id, invoice.CustomerId, customer.Number, customer.Name, invoice.Number,
                invoice.Amount, invoice.Currency, invoice.PerformancePeriod, invoice.FiscalYear);
        }
    }
}