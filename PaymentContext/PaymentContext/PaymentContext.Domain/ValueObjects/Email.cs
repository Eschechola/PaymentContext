using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string mail)
        {
            Mail = mail;
        }

        public string Mail { get; set; }
    }
}
