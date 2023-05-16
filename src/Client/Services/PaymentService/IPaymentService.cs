namespace CrossplatformHW.Client.Services.PaymentService;

public interface IPaymentService
{
    Task<string> GeneratePaymentLink();
}