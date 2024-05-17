﻿using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.Interfaces.IRepository
{
    public interface ISalleDeTheatreRepository : IRepository<SalleDeTheatre>
    {
        void AddRepresentationToSalle(int Idsalle, Representation Addrepresentation);
        void DeleteRepresentationToSalle(int Idsalle, int idRepresentation);

        Task<IEnumerable<SalleDeTheatre>> GetByIdComplexe(int idComplexe);

     
    }
}
