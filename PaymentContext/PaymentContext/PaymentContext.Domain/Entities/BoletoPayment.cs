using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode,
            Email email,
            string boletoNumber,

            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            Address address,
            string payer,
            ValueObjects.Document document
        ) : base(paidDate, expireDate, total, totalPaid, address, payer, document)
        {
            BarCode = barCode;
            Email = email;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public Email Email { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
