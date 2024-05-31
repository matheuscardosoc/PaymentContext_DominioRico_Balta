using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor

    [TestMethod]
    public void DeveRetornarErroQuandoCNPJEhInvalido() //ShouldReturnErrorWhenCNPJIsInvalid
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void DeveRetornarSucessoQuandoCNPJEhValido() //ShouldReturnSuccessWhenCNPJIsValid
    {
        var doc = new Document("42262946000176", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }

    [TestMethod]
    public void DeveRetornarErroQuandoCPFEhInvalido() //ShouldReturnErrorWhenCPFIsInvalid
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow("42933491036")]
    [DataRow("42933491036")]
    [DataRow("31029650080")]
    public void DeveRetornarSucessoQuandoCPFEhValido(string cpf) //ShouldReturnSuccessWhenCPFIsValid
    {
        var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}