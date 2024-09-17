using ApplicationUser.Dto.Favorit;
using ApplicationUser.Repository;
using ApplicationUser.Service;
using AutoMapper;
using Domain.Entity.UserEntity.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Service
{
    public class FavoritService : Service<Favorit, FavoritDto, AddFavoritDto, UpdateFavoritDto>, IFavoritService
    {
        private readonly IFavoritRepository _favoriteRepository;
        public FavoritService(IFavoritRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _favoriteRepository = repository;
        }
    }
}
