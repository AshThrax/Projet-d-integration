﻿using Domain.Entity.TheatherEntity;

namespace ApplicationTheather.Common.Interfaces.IRepository
{
    public interface IPieceRepository : IRepository<Piece>
    {
        void AddRepresentation(int idPiece, Representation represnetation);
        void DeleteRepresnetation(int idPiece, int idrepresentation);
        Task<IEnumerable<Piece>> GetPieceByComplexe(int idComplexe);
    }
}
