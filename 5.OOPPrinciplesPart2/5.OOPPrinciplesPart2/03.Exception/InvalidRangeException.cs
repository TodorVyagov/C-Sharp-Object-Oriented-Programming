namespace ExceptionClass
{
    using System;

    public class InvalidRangeException<T> : Exception
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>
    {
        public T Start { get; private set; }
        public T End { get; private set; }

        public InvalidRangeException(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }
        public InvalidRangeException(T start, T end, string message)
            : base(message)
        {
            this.Start = start;
            this.End = end;
        }
        public InvalidRangeException(T start, T end, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
