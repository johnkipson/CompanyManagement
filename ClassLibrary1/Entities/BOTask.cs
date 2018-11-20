using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBusinessLayer.Entities
{
    public class BOTask
    {
        public int TaskId { get; set; }
        public int StatusId { get; set; }
        public string TaskTittle { get; set; }
        public string TaskDescription { get; set; }
    }
}
