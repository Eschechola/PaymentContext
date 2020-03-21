using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            AddNotifications(Name, Document, Email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToList(); } }

        public void AddSubscription(Subscription subscription)
        {
            // Se já tiver uma assinatura ativa, cancela

            // Cancela todas as outras assinaturas, 
            // e coloca essa como principal

            foreach (var sub in Subscriptions)
            {
                sub.Inactivate();
            }

            _subscriptions.Add(subscription);
        }
    }
}
