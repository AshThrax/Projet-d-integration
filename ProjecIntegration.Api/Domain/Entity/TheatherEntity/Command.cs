using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.TheatherEntity
{
    public class Command : BaseEntity
    {

        public string? AuthId { get; set; }
        public int NombreDePlace { get; set; }
        //------represnetation
        [ForeignKey(nameof(Representation))]
        public int IdRepresentation { get; set; }
        public Representation? Representation { get; set; }


    }
}
