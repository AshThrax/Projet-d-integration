namespace WebApi.Application.DTO
{
 
        public class TicketDto : BaseDto
        {
            public string? Titre { get; set; }
            public string? Representation { get; set; }
            public string? Piecetitle { get; set; }
            public string? SalleName { get; set; }
            public int CommandId { get; set; }
        
        }
}
