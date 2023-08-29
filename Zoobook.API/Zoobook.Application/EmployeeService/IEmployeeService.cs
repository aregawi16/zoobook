using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobook.Domain.Model;

namespace Zoobook.Application.EmployeeService
{
    public interface IEmployeeService
    {
        Task<IReadOnlyList<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task AddRangeAsync(IList<Employee> employees);
        Task UpdateAsync(Employee employee, Employee exEmployee);
        Task RemoveAsync(int id);
        Task RemoveRange(IList<int> ids);

    }
}
