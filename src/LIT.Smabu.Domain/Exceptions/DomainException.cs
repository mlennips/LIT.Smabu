﻿using LIT.Smabu.Domain.SeedWork;

namespace LIT.Smabu.Domain.Exceptions
{
    public class DomainException(string message, IEntityId? entityId = null) : Exception(BuildMessage(message, entityId))
    {
        private static string BuildMessage(string message, IEntityId? entityId)
        {
            return message + (entityId != null ? $" ({entityId.GetType().Name}: {entityId})" : "");
        }
    }
}
