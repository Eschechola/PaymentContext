using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
            {
                AddNotification("FirstName", "O primeiro nome deve ser inserido");
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                AddNotification("LastName", "O primeiro nome deve ser inserido");
            }
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
