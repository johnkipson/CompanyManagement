using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBusinessLayer
{
    public class CMEnum
    {
        public enum Status
        {
            NotStarted = 1,
            Active = 2,
            Completed = 3,
            Delayed = 4
        }

        public enum Designation
        {
            DepartmentHead = 1,
            Manager = 2,
            Engineer = 3
        }

    }
}
