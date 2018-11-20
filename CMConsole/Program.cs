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
            //program.GetAllProjects();
            //program.GetAllTechnologies();
            //program.GetEmployeeCountForProject();
            //program.GetAllEmployeesForProject();
            //program.GetAllTasksForEmployee();
            //program.GetAllTechnologyTasksForEmployee();
            //program.GetAllTechnologyProjects();
            //program.GetAllActiveTasksForProject();
            //program.GetAllTechnologiesForEmployee();
            //program.GetProjectCountForEmployee();
            //program.GetAllActiveProjectsManagedByEmployee();
            //program.GetAllDelayedTasksForEmployee();
            //program.AddProject();
            //program.AddTechnology();
            //program.AddEmployee();
            //program.AssignEmployeeToProject();
            //program.CreateTaskInProject();
            //program.AssignTechnologyToTask();
            //program.UpdateTechnologiesForTask();
            //program.DeleteEmployeeFromSystem();
            //program.DeleteTechnology();
            //program.DeleteTask();
            program.DeleteProject();


            Console.Read();
        }



        public void GetAllProjects()
        {
            try
            {
                List<Project> projects = dataLayer.GetAllProjects();

                foreach (Project project in projects)
                {
                    Console.WriteLine("Project Name is : " + project.ProjectName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public void GetAllTechnologies()
        {
            try
            {
                List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
                foreach (TechnologyMaster technology in technologies)
                {
                    Console.WriteLine("Technology Name is : " + technology.TechnologyName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetEmployeeCountForProject()
        {
            try
            {
                int projectID = 1;
                int employeeCount = dataLayer.GetEmployeeCountForProject(projectID);
                Console.WriteLine("Employee Count" + employeeCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetAllEmployeesForProject()
        {
            try
            {
                int projectID = 1;
                List<Employee> employees = dataLayer.GetAllEmployeesForProjects(projectID);
                foreach (Employee employee in employees)
                {
                    Console.WriteLine("Employee Name is : " + employee.FirstName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAllDelayedProjects()
        {
            try
            {
                List<Project> projects = dataLayer.GetAllDelayedProjects();
                foreach (Project project in projects)
                {
                    Console.WriteLine("Delayed Project Name is : " + project.ProjectName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAllProjectsForEmployee()
        {
            try
            {
                int employeeID = 1;
                List<Project> projects = dataLayer.GetAllProjectsForEmployees(employeeID);
                foreach (Project project in projects)
                {
                    Console.WriteLine("Project Name is : " + project.ProjectName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAllTasksForEmployee()
        {
            try
            {
                int employeeID = 1;
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTasksForEmployee(employeeID);
                foreach (CompanyManagementDataLayer.Task task in tasks)
                {
                    Console.WriteLine("Task Title is : " + task.TaskTittle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetAllTechnologyTasksForEmployee()
        {
            try
            {
                int technologyID = 1;
                int employeeID = 1;
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTechnologyTasksForEmployee(technologyID, employeeID);
                foreach (CompanyManagementDataLayer.Task task in tasks)
                {
                    Console.WriteLine("Task Title is : " + task.TaskTittle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAllTechnologyProjects()
        {
            try
            {
                int technologyID = 1;
                List<Project> projects = dataLayer.GetAllTechnologyProjects(technologyID);
                foreach (Project project in projects)
                {
                    Console.WriteLine("Project Name is : " + project.ProjectName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAllActiveTasksForProject()
        {
            try
            {
                int projectID = 1;
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllActiveTasksForProject(projectID);
                foreach (CompanyManagementDataLayer.Task task in tasks)
                {
                    Console.WriteLine("Active Task Title for this Project Is : " + task.TaskTittle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetAllTechnologiesForEmployee()
        {
            try
            {
                int employeeID = 1;
                List<TechnologyMaster> technologies = dataLayer.GetAllTechnologiesForEmployee(employeeID);
                foreach (TechnologyMaster technology in technologies)
                {
                    Console.WriteLine("Technology Skills for this Employee is : " + technology.TechnologyName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetProjectCountForEmployee()
        {
            try
            {
                int employeeID = 1;
                int projectCount = dataLayer.GetProjectCountForEmployee(employeeID);
                Console.WriteLine("Project Count for Employee" + projectCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetAllActiveProjectsManagedByEmployee()
        {
            try
            {
                int employeeID = 1;
                List<Project> projects = dataLayer.GetAllActiveProjectsManagedByEmployee(employeeID);
                foreach (Project project in projects)
                {
                    Console.WriteLine("Project Name is : " + project.ProjectName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllDelayedTasksForEmployee()
        {
            try
            {
                int employeeID = 1;
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllDelayedTasksForEmployee(employeeID);
                foreach (CompanyManagementDataLayer.Task task in tasks)
                {
                    Console.WriteLine("Delayed Task Title for this Employee is : " + task.TaskTittle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void AddProject()
        {
            try
            {
                Project project = new Project();
                project.ClientId = 1;
                project.DepartmentId = 1;
                project.StatusId = Convert.ToInt32(CMEnum.Status.Active);
                project.ProjectName = ".Java";
                project.StartDate = DateTime.Now;

                dataLayer.AddProject(project);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddTechnology()
        {
            try
            {
                TechnologyMaster technology = new TechnologyMaster();
                technology.TechnologyName = "C#";

                dataLayer.AddTechnology(technology);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddEmployee()
        {
            try
            {
                Employee employee = new Employee();
                employee.DepartmentId = 1;
                employee.DesignationId = Convert.ToInt32(CMEnum.Designation.DepartmentHead);
                employee.AddressId = 3;
                employee.FirstName = "John";
                employee.LastName = "kipson";
                dataLayer.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AssignEmployeeToProject()
        {
            try
            {
                int employeeID = 1;
                int projectID = 1;

                dataLayer.AssignEmployeeToProject(employeeID, projectID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void CreateTaskInProject()
        {
            try
            {
                CompanyManagementDataLayer.Task task = new CompanyManagementDataLayer.Task();
                task.TaskTittle = "ABC";
                task.StatusId = Convert.ToInt32(CMEnum.Status.Active);
                int projectID = 1;

                dataLayer.CreateTaskInProject(task, projectID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AssignTechnologyToTask()
        {
            try
            {
                int technologyID = 1;
                int taskID = 1;

                dataLayer.AssignTechnologyToTask(technologyID, taskID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateTechnologiesForTask()
        {
            try
            {
                List<int> technologyIDs = new List<int>() { 1, 2, 3 };
                int taskID = 1;

                dataLayer.UpdateTechnologiesForTask(technologyIDs, taskID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteEmployeeFromSystem()
        {
            try
            {
                int employeeID = 1;
                dataLayer.DeleteEmployeeFromSystem(employeeID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteTechnology()
        {
            try
            {
                int technologyID = 1;
                dataLayer.DeleteTechnology(technologyID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteTask()
        {
            try
            {
                int taskID = 1;
                dataLayer.DeleteTask(taskID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteProject()
        {
            try
            {
                int projectID = 1;
                dataLayer.DeleteProject(projectID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
