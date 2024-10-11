using Blazor.UI.Data.ModelViews.Publication;
using Blazor.UI.Data.ModelViews.Theater;

using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Blazor.UI.Data.Services.Pdf
{
    public interface IPdfService
    {
        string CreateDocument(UserDto user,SalleDeTheatreDto salle,RepresentationDto representation, PieceDto Piece,List<SiegeDto> SiegeList );
    }
    /// <summary>
    /// générate a pdf with the ticket of the user 
    /// </summary>
    public class PdfService : IPdfService
    {
        public string CreateDocument(UserDto user, SalleDeTheatreDto salle, RepresentationDto representation, PieceDto Piece, List<SiegeDto> SiegeList)
        {
            return "";
        }
    }
}
