﻿using Application.DTO;
using Domain.DataType;
using Domain.Entity.notificationEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.businessService
{
    public interface IAnnonceBl
    {
        Task CreateAnnonce(AddAnnonceDto addAnnonceDto);
        Task DeleteAnnonce(string annonceId);
        Task<Pagination<GetAnnonceDto>> GetAnnonces();
        Task<GetAnnonceDto> GetAnnonceById(string annonceId);
        Task UpdateAnnonce(string annonceId, UpdateAnnonceDto annonceDto);
    }
}
