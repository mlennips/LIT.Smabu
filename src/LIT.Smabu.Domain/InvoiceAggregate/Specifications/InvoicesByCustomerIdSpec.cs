﻿using LIT.Smabu.Domain.CustomerAggregate;
using LIT.Smabu.Domain.InvoiceAggregate;
using LIT.Smabu.Domain.SeedWork;

namespace LIT.Smabu.Domain.OfferAggregate.Specifications
{
    public class InvoicesByCustomerIdSpec(CustomerId customerId) 
        : Specification<Invoice>(x => x.CustomerId == customerId)
    {

    }
}