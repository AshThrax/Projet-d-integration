﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.TheatherEntity
{
    public class Representation : BaseEntity
    {


        public int Prix { get; set; }
        public DateTime Seance { get; set; }
        public int PlaceMaximum { get; set; }
        public int PlaceCurrent { get; set; }
        //------salle de theatre
        [ForeignKey(nameof(SalleDeTheatre))]
        public int IdSalledeTheatre { get; set; }
     
        public SalleDeTheatre? SalleDeTheatre { get; set; }

        [ForeignKey(nameof(Piece))]
        //-----PIece
        public int IdPiece { get; set; }
        public Piece? Piece { get; set; }
        //-----commande/reservation
        public List<Command>? Commands { get; set; }
    }
}
