

namespace Blazor.UI.Data.ModelViews.Theater
{
    public class EntrepriseDto : Baseview
    {
        public string Nom { get; set; }
        public string Adress { get; set; }
        public List<ComplexeDto> Complexes { get; set; }
    }
}
