using ApplicationUser.Dto.Favorit;
using ApplicationUser.Service;
using Auth0.ManagementApi.Models;
using Domain.Entity.UserEntity.UserDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritController : GeneriqueController<Favorit, FavoritDto, AddFavoritDto, UpdateFavoritDto>
    {
        public FavoritController(IFavoritService service) : base(service)
        {
        }
    }
}
