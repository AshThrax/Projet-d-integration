using Blazor.UI.data.modelViews;

namespace Blazor.UI.Data.modelViews.Theater
{
    public class EntrepriseDto : Baseview
    {
        public string Nom { get; set; }
        public string Adress { get; set; }
        public List<ComplexeDto> Complexes { get; set; }
    }
}
