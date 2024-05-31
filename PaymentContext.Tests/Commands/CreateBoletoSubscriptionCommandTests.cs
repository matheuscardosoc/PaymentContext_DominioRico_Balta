using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    // Red, Green, Refactor

    [TestMethod]
    public void DeveRetornarErroQuandoNomeEhInvalido() //ShouldReturnErrorWhenNameIsInvalid
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "ai";
        command.Validate();
        Assert.AreEqual(false, command.IsValid);
    }
}