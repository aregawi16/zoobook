using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobook.Domain.Model;

namespace Zoobook.Infrastracture.Context
{
    public class ZoobookContext : DbContext
    {
        public ZoobookContext()
        {
        }

        public ZoobookContext(DbContextOptions<ZoobookContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
