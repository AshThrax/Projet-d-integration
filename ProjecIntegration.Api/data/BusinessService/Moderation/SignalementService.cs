using ApplicationUser.Common.Repository;
using ApplicationUser.Dto;
using ApplicationUser.Dto.Signalement;
using ApplicationUser.Service;
using AutoMapper;
using Domain.Entity.PublicationEntity.Modération;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureUser.Service
{
    public class SignalementService : Service<Signalement, GetSignalementDto, AddSignalementDto, UpdateSignalementDto>, ISignalementService
    {
        private readonly ISignalementRepository _repository;
        public SignalementService(ISignalementRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
