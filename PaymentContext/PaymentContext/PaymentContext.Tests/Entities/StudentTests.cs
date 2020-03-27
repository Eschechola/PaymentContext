using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Payment _payment;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            var name = new Name("Lucas", "Eschechola");
            var document = new Document("12345678901", EDocumentType.CPF);
            var email = new Email("lucas@eu.com");
            var address = new Address("Rua 1", "12", "Bairro", "Sampa", "SP", "BR", "12356700");
            _student = new Student(name, document, email);
            var payment = new PaypalPayment(email, "1224x", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, address, "Lucas", document);
            _payment = payment;

            _subscription = new Subscription(null);
            
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {

            _subscription.AddPayment(_payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {

            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadNoActiveSubscription()
        {
            _subscription.AddPayment(_payment);

            Assert.IsTrue(_student.Invalid);
        }
    }
}
