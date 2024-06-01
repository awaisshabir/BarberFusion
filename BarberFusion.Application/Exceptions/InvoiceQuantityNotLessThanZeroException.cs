namespace BarberFusion.Application.Exceptions
{
    public class InvoiceQuantityNotLessThanZeroException : Exception
    {
        public InvoiceQuantityNotLessThanZeroException(string message) : base(message) { }
    }
}
