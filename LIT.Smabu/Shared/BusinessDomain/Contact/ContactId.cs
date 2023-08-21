﻿using LIT.Smabu.Shared.Common;

namespace LIT.Smabu.Shared.BusinessDomain.Contact
{
    public class ContactId : EntityId<IContact>
    {
        public ContactId(Guid value) : base(value)
        {
        }
    }
}