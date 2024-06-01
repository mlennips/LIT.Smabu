﻿namespace LIT.Smabu.Domain.SeedWork
{
    public abstract record BusinessNumber(long Value) : SimpleValueObject<long>(Value)
    {
        private const string TempText = "TEMP";
        public abstract string ShortForm { get; }
        public abstract int Digits { get; }
        protected virtual int TemporaryValue { get; } = 0;
        public bool IsTemporary => Value == TemporaryValue;
        public string Long => $"{ShortForm}-{(IsTemporary ? TempText : ConvertValueToFormattedString())}";

        private string ConvertValueToFormattedString()
        {
            return Value.ToString(new string('0', Digits));
        }
    }
}
