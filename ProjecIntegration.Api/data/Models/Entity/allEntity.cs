/*
namespace ProjecIntegration.Api.Models.Entitye.
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedTime { get; set; }
    }
    public class Command : BaseEntity
    {

        public string AuthId { get; set; }
        public int NombreDePlace { get; set; }
        //------represnetation
        public Representation Representation { get; set; }
        public int IdRepresnetation { get; set; }


    }
    public class Complexe : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<SalleDeTheatre> SalleDeTheatres { get; set; }
        public Entreprise Entreprise { get; set; }
        public int EntrepriseID { get; set; }
    }
    public class Entreprise : BaseEntity
    {
        public string Nom { get; set; }
        public string Adress { get; set; }
        public List<Complexe> Complexes { get; set; }
    }
    public class Piece : BaseEntity
    {
        public string Titre { get; set; }
        public TimeSpan Duree { get; set; }
        public string Description { get; set; }
        public List<Representation> Representations { get; set; }

    }
    public class Representation : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Seance { get; set; }
        //------salle de theatre
        public SalleDeTheatre SalleDeTheatre { get; set; }
        public int IdSalledeTheatre { get; set; }
        public Piece Piece { get; set; }
        public int IdPiece { get; set; }
        //-----commande/reservation
        public List<Command> Commands { get; set; }
    }
    public class SalleDeTheatre : BaseEntity
    {

        public string Name { get; set; }

        public int PlaceMax { get; set; }

        public int PlaceCurrent { get; set; }

        public int complexeId { get; set; }
        public Complexe Complexe { get; set; }

        public List<Representation> Representations { get; set; }

    }
}
*/