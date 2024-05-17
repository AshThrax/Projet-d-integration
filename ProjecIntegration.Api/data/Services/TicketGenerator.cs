using ApplicationTheather.DTO;
using Domain.Entity.TheatherEntity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
