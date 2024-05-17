﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.TheatherEntity
{
    public class SalleDeTheatre : BaseEntity
    {

        public string Name { get; set; }=string.Empty;  

        public int PlaceMax { get; set; }
        [ForeignKey(nameof(Complexe))]
        public int ComplexeId { get; set; }
        public Complexe? Complexe { get; set; }

        public List<Representation>? Representations { get; set; }
 

    }
}
