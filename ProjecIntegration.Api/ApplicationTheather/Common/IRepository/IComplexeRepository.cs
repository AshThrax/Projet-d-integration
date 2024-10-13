﻿using ApplicationTheater.Common;
using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.IRepository
{
    public interface IComplexeRepository : IRepository<Complexe>
    {
        Task AddSalledeTheatre(int complexeId, SalleDeTheatre salleDeTheatre);
        Task DeletesalleDetheatre(int complexeId, int salleId);


    }
}
