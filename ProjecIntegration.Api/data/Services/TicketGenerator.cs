using Domain.Entity.TheatherEntity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTO;

namespace DataInfraTheather.Services
{
    public static class TicketGenerator
    {
        public static List<TicketDto> GetTicketUser(int ticketNumber,string PieceTitle,string salleName,DateTime representationtime)
        {
           
            List<TicketDto> value = Enumerable.Range(0, ticketNumber)//génére le nombre de ticket requis
                                  .Select(_ => new TicketDto
                                  {
                                      Titre = PieceTitle,
                                      SalleName = salleName,
                                      Representation = representationtime.ToString()
                                  }).ToList();
            return value;
        }
    }
}
