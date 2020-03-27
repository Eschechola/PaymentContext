using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repository;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>
    {

        private readonly IStudentRepository _repository;

        public SubscriptionHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail fast validations
            command.Validade();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados inválidos!");
            }

            //Verificar se Documento já está cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }

            //Verificar se email já está cadastrado
            if (_repository.EmailExists(command.Mail))
            {
                AddNotification("Document", "Este Email já está em uso");
            }

            //Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Mail);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode) ;
            var _student = new Student(name, document, email);



            //Gerar as entidades
            var student = new Student(name, document, email);
            var _subscription = new Subscription(DateTime.Now.AddMonths(1));
            //var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, EDocumentType.CPF), address);

            //Aplicar as Validações


            //Salvar as informaçoes


            //Enviar email de boas vindas


            //retornar informações

            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    }
}
