using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ITicketRepository:IRepository<Ticket>
    {
       IEnumerable<Ticket> GetAllbyCommandId(int CommandId);
        Ticket GetByCommandId(int CommandId,int ticketid);
    }
}
