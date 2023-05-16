using System.Net;
using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Shared.Models;
using Session = Stripe.Checkout.Session;

namespace CrossplatformHW.Server.Services.PaymentService;

public interface IPaymentService
{
    Session CreateCheckoutSession(HttpContext context, List<CartItem> cart);
    Task<HttpStatusCode> CreateWebHookAsync(HttpContext context);
    Task<string> AddPaymentProfileAsync(User user);
    Task UpdatePaymentProfileAsync(Guid userId);
    Task DeletePaymentProfileAsync(Guid userId);
}