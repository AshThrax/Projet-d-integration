namespace Domain.Entity.TheatherEntity
{
    public class Complexe : BaseEntity
    {

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Adress { get; set; }=string.Empty;
        public List<SalleDeTheatre>? SalleDeTheatres { get; set; }
        public List<Catalogue>? Catalogue { get; set; }
        //public Entreprise Entreprise { get; set; }
        //public int EntrepriseID { get; set; }
    }
}
