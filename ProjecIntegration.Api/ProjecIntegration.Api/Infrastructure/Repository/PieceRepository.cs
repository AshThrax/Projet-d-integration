﻿using Microsoft.EntityFrameworkCore;
using ProjecIntegration.Api.Application.Common.Interfaces.IRepository;
using ProjecIntegration.Api.infrastructure.Persistence;
using ProjecIntegration.Api.infrastructure.Repository;
using ProjecIntegration.Api.Models.Entity;

namespace ProjecIntegration.Api.Infrastructure.Repository
{
    public class PieceRepository : Repository<Piece>, IPieceRepository
    {
        private readonly ApplicationDbContext _context;
        public PieceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void AddRepresentation(int idPiece, Representation represnetation)
        {
           var piece= _context.Pieces.FirstOrDefault(x =>x.Id==idPiece);
            if (piece!=null) 
            {
                if (piece.Representations == null)
                {
                    piece.Representations = new List<Representation>();
                }
                piece.Representations.Add(represnetation);
                _context.SaveChanges();
            }
        }

        public void DeleteRepresnetation(int idPiece, int idrepresentation)
        {
            var piece = _context.Pieces.FirstOrDefault(x => x.Id == idPiece);
            if (piece != null)
            {
                var representationDelete = piece.Representations.FirstOrDefault(cx =>cx.Id==idrepresentation);
                piece.Representations.Remove(representationDelete);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Piece>> GetPieceByComplexe(int idComplexe)
        {
            var salle = await _context.SalleDeTheatres
                .Include(c =>c.Pieces)
                .Where(c => c.complexeId == idComplexe).FirstOrDefaultAsync();
            IEnumerable<Piece> pieces = salle.Pieces;

           
            return pieces;
        }
    }
}
