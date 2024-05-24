using System.ComponentModel.DataAnnotations;

namespace ApplicationTheather.DTO
{
    public class BaseDto
    {
        
        public int? Id { get; set; }
        public DateTime? AddedTime { get; set; } = DateTime.Now;
    }
}
