using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobook.Domain.Model;

namespace Domain.IRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
