﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.ContextData
{
    class DbContextApp:DbContext
    {
        public DbSet<Donanım> Donanım { get; set; }
    }
}
