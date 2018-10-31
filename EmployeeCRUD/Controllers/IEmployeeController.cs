using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmployeeCRUD.Controllers
{
    interface IEmployeeController
    {
         void SaveEmployee(Employee emp);
         DataTable GetAllEmployees();

         Employee GetEmployeeById(int EmployeeID);

         void DeleteEmployeeById(int EmployeeID);

    }
}
