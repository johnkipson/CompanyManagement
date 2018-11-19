﻿using CompanyManagementDataLayer;
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
            program.GetAllTechnologyTasksForEmployee();
            //program.AddProject();
            //program.AddTechnology();
            //program.AddEmployee();
            //program.AssignEmployeeToProject();


            Console.Read();
        }



        public void GetAllProjects()
        {
            List<Project> projects = dataLayer.GetAllProjects();

            foreach (Project project in projects)
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
        public void GetEmployeeCountForProject()
        {
            int projectID = 1;
            int employeeCount = dataLayer.GetEmployeeCountForProject(projectID);
            Console.WriteLine("Employee Count" + employeeCount);

        }
        public void GetAllEmployeesForProject()
        {
            int projectID = 1;
            List<Employee> employees = dataLayer.GetAllEmployeesForProjects(projectID);
            foreach (Employee employee in employees)
            {
                Console.WriteLine("Employee Name is : " +employee.FirstName);
            }
        }
        public void GetAllDelayedProjects()
        {
            List<Project> projects = dataLayer.GetAllDelayedProjects();
            foreach (Project project in projects)
            {
                Console.WriteLine("Delayed Project Name is : " + project.ProjectName);
            }
        }
        public void GetAllProjectsForEmployee()
        {
            int employeeID = 1;
            List<Project> projects = dataLayer.GetAllProjectsForEmployees(employeeID);
            foreach (Project project in projects)
            {
                Console.WriteLine("Project Name is : " + project.ProjectName);
            }
        }
        public void GetAllTasksForEmployee()
        {
            int employeeID = 1;
            List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTasksForEmployee(employeeID);
            foreach (CompanyManagementDataLayer.Task task in tasks)
            {
                Console.WriteLine("Task Title is : " + task.TaskTittle);
            }
        }
        public void GetAllTechnologyTasksForEmployee()
        {
            int technologyID = 1;
            int employeeID = 1;
            List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTechnologyTasksForEmployee(technologyID,employeeID);
            foreach (CompanyManagementDataLayer.Task task in tasks)
            {
                Console.WriteLine("Task Title is : " + task.TaskTittle);
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
    }
}
