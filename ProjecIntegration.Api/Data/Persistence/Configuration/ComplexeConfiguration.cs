﻿using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Persistence.Configuration
{
    public class ComplexeConfiguration: IEntityTypeConfiguration<Complexe>
    {
        public void Configure(EntityTypeBuilder<Complexe> builder) 
        {
            
        }
    }
}
