using CompanyManagementDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMConsole
{
    class Program
    {

        DataLayer dataLayer = new DataLayer();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetAllProjects();
            program.GetAllTechnologies();
            program.GetEmployeeCountForProject(1);

            Console.Read();  
        }


        public void GetAllProjects()
        {
            List<Project> projects = dataLayer.GetAllProjects();

            foreach(Project project in projects)
            {
                Console.WriteLine("Project Name is : " + project.ProjectName);
            }


        }
        public void GetAllTechnologies()
        {
            List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
            foreach (TechnologyMaster technology in technologies)
            {
                Console.WriteLine("Technology Name is : " + technology.TechnologyName);
            }


        }
        public void GetEmployeeCountForProject(int projectID)
        {
            int employeeCount = dataLayer.GetEmployeeCountForProject(projectID);
            Console.WriteLine("Employee Count" + employeeCount);

        }
    }
}
