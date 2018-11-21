using CompanyManagementBusinessLayer;
using CompanyManagementBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMConsole
{
    class Program
    {

       BusinessLayer businessLayer = new BusinessLayer();
        static void Main(string[] args)
        {
            
            Program program = new Program();
            program.GetAllProjects();
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
            //program.DeleteProject();


            Console.Read();
        }



        public void GetAllProjects()
        {
            try
            {
             
                List<BOProject> projects  = businessLayer.GetAllProjects();

                foreach (BOProject project in projects)
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
                List<BOTechnology> technologies = businessLayer.GetAllTechnologies();
                foreach (BOTechnology technology in technologies)
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
                int employeeCount = businessLayer.GetEmployeeCountForProject(projectID);
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
                List<BOEmployee> employees = businessLayer.GetAllEmployeesForProjects(projectID);
                foreach (BOEmployee employee in employees)
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
                List<BOProject> projects = businessLayer.GetAllDelayedProjects();
                foreach (BOProject project in projects)
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
                List<BOProject> projects = businessLayer.GetAllProjectsForEmployees(employeeID);
                foreach (BOProject project in projects)
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
                List<BOTask> tasks = businessLayer.GetAllTasksForEmployee(employeeID);
                foreach (BOTask task in tasks)
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
                List<BOTask> tasks = businessLayer.GetAllTechnologyTasksForEmployee(technologyID, employeeID);
                foreach (BOTask task in tasks)
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
                List<BOProject> projects = businessLayer.GetAllTechnologyProjects(technologyID);
                foreach (BOProject project in projects)
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
                List<BOTask> tasks = businessLayer.GetAllActiveTasksForProject(projectID);
                foreach (BOTask task in tasks)
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
                List<BOTechnology> technologies = businessLayer.GetAllTechnologiesForEmployee(employeeID);
                foreach (BOTechnology technology in technologies)
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
                int projectCount = businessLayer.GetProjectCountForEmployee(employeeID);
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
                List<BOProject> projects = businessLayer.GetAllActiveProjectsManagedByEmployee(employeeID);
                foreach (BOProject project in projects)
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
                List<BOTask> tasks = businessLayer.GetAllDelayedTasksForEmployee(employeeID);
                foreach (BOTask task in tasks)
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
                BOProject boProject = new BOProject();
                boProject.ClientId = 1;
                boProject.DepartmentId = 1;
                boProject.StatusId = Convert.ToInt32(CMEnum.Status.Active);
                boProject.ProjectName = ".Java";
                boProject.StartDate = DateTime.Now;

                businessLayer.AddProject(boProject);
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
                BOTechnology boTechnology = new BOTechnology();
                boTechnology.TechnologyName = "C#";

                businessLayer.AddTechnology(boTechnology);
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
                BOEmployee boEmployee = new BOEmployee();
                boEmployee.DepartmentId = 1;
                boEmployee.DesignationId = Convert.ToInt32(CMEnum.Designation.DepartmentHead);
                boEmployee.AddressId = 3;
                boEmployee.FirstName = "John";
                boEmployee.LastName = "kipson";
                businessLayer.AddEmployee(boEmployee);
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

                businessLayer.AssignEmployeeToProject(employeeID, projectID);
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
                BOTask task = new BOTask();
                task.TaskTittle = "ABC";
                task.StatusId = Convert.ToInt32(CMEnum.Status.Active);
                int projectID = 1;

                businessLayer.CreateTaskInProject(task, projectID);
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

                businessLayer.AssignTechnologyToTask(technologyID, taskID);
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

                businessLayer.UpdateTechnologiesForTask(technologyIDs, taskID);
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
                businessLayer.DeleteEmployeeFromSystem(employeeID);
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
                businessLayer.DeleteTechnology(technologyID);
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
                businessLayer.DeleteTask(taskID);
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
                businessLayer.DeleteProject(projectID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
