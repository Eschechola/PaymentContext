using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;


namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string mail)
        {
            Mail = mail;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Mail, "Email.Mail", "Email inválido.")
            );
        }

        public string Mail { get; set; }
    }
}
