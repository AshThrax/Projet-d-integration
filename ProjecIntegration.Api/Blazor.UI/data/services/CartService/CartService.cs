using Blazor.UI.Data.ModelViews.Theater;
using Blazored.LocalStorage;

namespace Blazor.UI.Data.Services.CartService
{
    public class CartService :ICartService
    {
      private readonly ILocalStorageService _localStorageService;

        public CartService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

       // public event Action OnChange;

        public async Task AddToCart(AddCommandDto item)
        {
          
           await _localStorageService.SetItemAsync("command",item);
               // OnChange.Invoke();
        }
        public async Task<AddCommandDto> GetCartItems()
        {
            var cart =await _localStorageService.GetItemAsync<AddCommandDto>("command");
            if (cart == null)
            {
                return new AddCommandDto();
            }
            return cart;
        }
        public async Task EmptyCart()
        {
              await  _localStorageService.RemoveItemAsync("command");
              //  OnChange.Invoke();
        }
    }
}
