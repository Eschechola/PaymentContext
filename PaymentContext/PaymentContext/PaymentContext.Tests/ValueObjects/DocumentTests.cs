using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor
        // Escrever testes e fazer falhar
        // Fazer os testes passarem
        // Refatora o código
        
        // CNPJ
        
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);

            //verifica se o cnpj passado é invalido
            //variável Invalid => Flunt
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("12345678900987", EDocumentType.CNPJ);

            //verifica se o cnpj passado é valido
            //variável Valid => Flunt
            Assert.IsTrue(doc.Valid);
        }


        //CPF

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
            
        }

        //testar multiplos cpfs
        [TestMethod]
        [DataTestMethod]
        [DataRow("12345678909")]
        [DataRow("12345678909")]
        [DataRow("12345678909")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
