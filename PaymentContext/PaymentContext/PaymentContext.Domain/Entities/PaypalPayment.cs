using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(
            Email email,
            string transactionCode,

            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            Address address,
            string payer,
            ValueObjects.Document document
        ) : base(paidDate, expireDate, total, totalPaid, address, payer, document)
        {
            Email = email;
            TransactionCode = transactionCode;
        }

        public Email Email { get; private set; }
        public string TransactionCode { get; private set; }
    }
}
