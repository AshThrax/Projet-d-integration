using ProjecIntegration.Api.Models;

namespace ProjecIntegration
{
    public class Complexe :BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public List<SalleDeTheatre> SalleDeTheatres { get; set; }
        //public Entreprise Entreprise { get; set; }
        //public int EntrepriseID { get; set; }
    }
}
