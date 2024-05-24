using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTheather.DTO
{
    public class CatalogueDto :BaseDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int ComplexeId { get; set; }
    }
    public class AddCatalogueDto 
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int ComplexeId { get; set; }
    }
    public class UpdateCatalogueDto : BaseDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int ComplexeId { get; set; }
    }
}
