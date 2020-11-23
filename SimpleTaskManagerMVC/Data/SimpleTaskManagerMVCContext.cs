using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTaskManagerMVC.Models;

namespace SimpleTaskManagerMVC.Data
{
    public class SimpleTaskManagerMVCContext : DbContext
    {
        public SimpleTaskManagerMVCContext (DbContextOptions<SimpleTaskManagerMVCContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleTaskManagerMVC.Models.SimpleTask> SimpleTask { get; set; }
    }
}
