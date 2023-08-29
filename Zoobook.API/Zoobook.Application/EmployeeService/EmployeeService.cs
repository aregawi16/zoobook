using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobook.Domain.Model;

namespace Zoobook.Application.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            return await _unitOfWork.employeeRepository.GetAllAsync();
        }
        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _unitOfWork.employeeRepository.GetByIdAsync(id);
        }
        public async Task<Employee> AddAsync(Employee entity)
        {
            var e = await _unitOfWork.employeeRepository.AddAsync(entity);
            return e;

        }

        public async Task AddRangeAsync(IList<Employee> entities)
        {
            await _unitOfWork.employeeRepository.AddRangeAsync(entities);

        }

        public async Task UpdateAsync(Employee entity)
        {
            _unitOfWork.employeeRepository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            await _unitOfWork.employeeRepository.RemoveAsync(id);
        }

        public async Task RemoveRange(IList<int> ids)
        {
            _unitOfWork.employeeRepository.RemoveRange(ids);
        }

    }

}
