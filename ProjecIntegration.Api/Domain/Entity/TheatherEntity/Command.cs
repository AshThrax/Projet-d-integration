namespace Domain.Entity.TheatherEntity
{
    public class Command : BaseEntity
    {

        public string? AuthId { get; set; }
        public int NombreDePlace { get; set; }
        //------represnetation
        public Representation? Representation { get; set; }
        public int IdRepresentation { get; set; }


    }
}
