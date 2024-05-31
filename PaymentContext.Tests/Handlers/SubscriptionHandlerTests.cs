using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests;

[TestClass]
public class SubscriptionHandlerTests
{
    // Red, Green, Refactor

    [TestMethod]
    public void DeveRetornarErroQuandoDocumentoExiste() //ShouldReturnErrorWhenDocumentExists
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand
        {
            // Pessoa
            FirstName = "Naruto",
            LastName = "Uzumaki",
            Document = "99999999999",
            Email = "email2@gmail.com",

            // Pagamento
            BarCode = "12345678910",
            BoletoNumber = "123",
            PaidDate = DateTime.Now,
            ExpireDate = DateTime.Now.AddMonths(1),
            Total = 10,
            TotalPaid = 10,
            Payer = "Teste",
            PayerDocument = "12345678910",
            PayerDocumentType = EDocumentType.CPF,
            PayerEmail = "teste2@gmail.com",
            Street = "Teste",
            Number = "123",
            Neighborhood = "Teste2",
            City = "Teste3",
            State = "SP",
            Country = "BR",
            ZipCode = "123"
        };

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
}