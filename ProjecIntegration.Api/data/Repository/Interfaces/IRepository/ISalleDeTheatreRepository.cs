namespace data.Interfaces.IRepository
{
    public interface ISalleDeTheatreRepository : IRepository<SalleDeTheatre>
    {
        void AddRepresentationToSalle(int Idsalle,Representation Addrepresentation);
        void DeleteRepresentationToSalle(int Idsalle, int  idRepresentation);

        Task<IEnumerable<SalleDeTheatre>> GetByIdComplexe(int idComplexe);
        
        void AddPieceToSalle(int idSalle,Piece piece);
        void DeletePieceToSalle(int idSalle,int idPiece);
    }
}
