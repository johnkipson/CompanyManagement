using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBusinessLayer.Entities
{
    public class BOProject
    {
        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        public int DepartmentId { get; set; }
        public int StatusId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
