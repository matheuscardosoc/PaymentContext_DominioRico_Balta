using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Naruto", "Uzumaki");
        _document = new Document("37826578027", Domain.Enums.EDocumentType.CPF);
        _email = new Email("narutohokage123@gmail.com");
        _address = new Address("Rua Konoha", "1234", "Bairro do Hokage", "Vila da Folha", "Konoha", "BR", "13968000");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void DeveRetornarErroQuandoTemAssinaturaAtiva() //ShouldReturnErrorWhenHadActiveSubscription
    {
        var payment = new PayPalPayment("12345678910", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "KONOHA", _document, _address, _email);

        _subscription.AddPayment(payment);

        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void DeveRetornarErroQuandoTemAssinaturaSemPagamento() //ShouldReturnErrorWhenHadSubscriptionHasNoPayment
    {
        _student.AddSubscription(_subscription);
        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void DeveRetornarSucessoQuandoNaoTemAssinaturaAtiva() //ShouldReturnSuccessWhenHadNoActiveSubscription
    {
        var payment = new PayPalPayment("12345678910", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "KONOHA", _document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        Assert.IsTrue(_student.IsValid);
    }
}