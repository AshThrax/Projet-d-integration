using Stripe.Checkout;

namespace WebApi.ApiService.PaymentService
{
    public interface IPaymentService
    {
        Session CreateSession(int ticketNumber, int price,PieceDto getPiece);
    }
}
