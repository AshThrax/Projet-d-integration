using Blazor.UI.Data.ModelViews.Theater;

namespace Blazor.UI.Data.Services.CartService
{
    public interface ICartService
    {
        //event Action OnChange;
        Task AddToCart(AddCommandDto item);
        Task<AddCommandDto> GetCartItems();
        Task EmptyCart();
    }
}
