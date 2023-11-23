﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Command :BaseEntity
    {
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }   
        public USER User { get; set; }
        public int IdUser { get; set; } 

    }
}
