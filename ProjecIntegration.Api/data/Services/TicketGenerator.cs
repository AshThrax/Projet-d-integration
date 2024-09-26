using ApplicationTheather.DTO;

namespace DataInfraTheather.Services
{
    public static class TicketGenerator
    {
        public static List<TicketDto> GetTicketUser(int ticketNumber,string PieceTitle,string salleName,int represnetationId,DateTime representationtime)
        {
            try 
            {
                List<TicketDto> value = Enumerable.Range(0, ticketNumber)//génére le nombre de ticket requis
                                      .Select(_ => new TicketDto
                                      {
                                          PieceTitre = PieceTitle,
                                          SalleName = salleName,
                                          RepresentationTime = representationtime.ToString(),   
                                          RepresentationId = represnetationId
                                      }).ToList();
                return value;
                
            }
            catch (Exception ) 
            { 
                return new List<TicketDto>();
            }
           
        }
    }
}
