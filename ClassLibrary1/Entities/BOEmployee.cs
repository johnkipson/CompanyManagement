using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBusinessLayer.Entities
{
    public class BOEmployee
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? Dob { get; set; }
    }
}
