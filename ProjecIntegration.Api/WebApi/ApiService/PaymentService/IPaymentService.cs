using Stripe.Checkout;

namespace WebApi.ApiService.PaymentService
{
    public interface IPaymentService
    {
        Session CreateSession(CommandDto Command);
    }
}
