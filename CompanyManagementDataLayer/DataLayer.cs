using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementDataLayer
{
    public class DataLayer
    {

        CMDataClassesDataContext dataContext = new CMDataClassesDataContext();

        public List<Project> GetAllProjects()
        {
            List<Project> projects = (from project in dataContext.Projects
                                      select project).ToList();
            return projects;

        }
        public List<TechnologyMaster> GetAllTechnologies()
        {
            List<TechnologyMaster> technologies = (from technology in dataContext.TechnologyMasters
                                                   select technology).ToList();
            return technologies;
        }
        public int GetEmployeeCountForProject(int projectID)
        {
            int employeeCount = (from empProject in dataContext.EmployeeProjects
                                   where empProject.ProjectId == projectID
                                   select empProject).Count();
           
            return employeeCount;
        }
    }
}
