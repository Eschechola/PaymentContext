using Flunt.Notifications;
using System;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        //public List<string> Notifications { get; private set; }

        //public void AddNotification(string notification)
        //{
            //Notifications.Add(notification);
        //}
    }
}
