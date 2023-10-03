﻿using LIT.Smabu.Shared.Entities.Business.CustomerAggregate;

namespace LIT.Smabu.Shared.Entities.Business.InvoiceAggregate
{
    public class InvoiceNumber : BusinessNumber
    {
        public InvoiceNumber(long value) : base(value)
        {
        }

        public override string ShortForm => "INV";

        public override int Digits => 8;

        public static InvoiceNumber CreateFirst(int year)
        {
            return new InvoiceNumber(int.Parse((year.ToString() + 1.ToString("0000"))));
        }

        public static InvoiceNumber CreateNext(InvoiceNumber lastNumber)
        {
            return new InvoiceNumber(lastNumber.Value + 1);
        }
    }
}