using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Numer = number;
            Type = type;
        }

        public string Numer { get; set; }
        public EDocumentType Type { get; private set; }
    }
}
