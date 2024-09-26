using ApplicationUser.Common.Repository;
using ApplicationUser.Dto.Signalement;
using ApplicationUser.Dto.SignalementType;
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
    public class SignalementTypeService : Service<SignalementType, GetSignalementTypeDto, AddSignalementTypeDto, UpdateSignalementTypeDto>, ISignalementTypeService
    {
        private readonly ISignalementTypeRepository _repository;
        public SignalementTypeService(ISignalementTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}
