using Domain.IRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobook.Domain.Model;
using Zoobook.Infrastracture.Context;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ZoobookContext _context;

        public EmployeeRepository(ZoobookContext context) : base(context)
        {
            _context = context;
        }

    

    }
}
