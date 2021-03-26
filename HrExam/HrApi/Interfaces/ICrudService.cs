
using System.Collections.Generic;
using System.Threading.Tasks;
using HrApi.Models;

namespace HrApi.Interfaces
{
    public interface ICrudService
    {
        Employee GetEmployee(int id);

        Task<IEnumerable<Employee>>  SearchEmployee(string search);

        void SaveEmployee(Employee employee);

        void EditEmployee(Employee employee);

        void DeleteEmployee(int id);

    }
}
