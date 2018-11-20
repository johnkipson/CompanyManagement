using CompanyManagementBusinessLayer.Entities;
using CompanyManagementDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBusinessLayer
{
    class BusinessLayerHelper
    {

        public static List<BOProject> ConvertProjectListToBOProjectList(List<Project> Projects)
        {
            List<BOProject> businessProjects = new List<BOProject>();
            foreach (Project project in Projects)
            {
                BOProject boProject = ConvertProjectToBOProject(project);

                businessProjects.Add(boProject);
            }
            return businessProjects;
        }
        public static List<BOTechnology> ConvertTechnologyListToBOTechnologyList(List<TechnologyMaster> technologies)
        {
            List<BOTechnology> businessTechnologies = new List<BOTechnology>();
            foreach (TechnologyMaster technology in technologies)
            {
                BOTechnology boTechnology = ConvertTechnologyToBOTechnology(technology);

                businessTechnologies.Add(boTechnology);
            }
            return businessTechnologies;
        }
        public static List<BOEmployee> ConvertEmployeeListToBOEmployeeList(List<Employee> employees)
        {
            List<BOEmployee> businessEmployees = new List<BOEmployee>();
            foreach (Employee employee in employees)
            {
                BOEmployee boEmployee = ConvertEmployeeToBOEmployee(employee);

                businessEmployees.Add(boEmployee);
            }

            return businessEmployees;
        }
        public static List<BOTask> ConvertTaskListToBOTaskList(List<CompanyManagementDataLayer.Task> tasks)
        {
            List<BOTask> businessTasks = new List<BOTask>();
            foreach (CompanyManagementDataLayer.Task task in tasks)
            {
                BOTask boTask = ConvertTaskToBOTask(task);

                businessTasks.Add(boTask);
            }

            return businessTasks;
        }


        public static BOProject ConvertProjectToBOProject(Project project)
        {
            BOProject boProject = new BOProject();

            boProject.ProjectId = project.ProjectId;
            boProject.ClientId = project.ClientId;
            boProject.DepartmentId = project.DepartmentId;
            boProject.StatusId = project.StatusId;
            boProject.ProjectName = project.ProjectName;
            boProject.ProjectDescription = project.ProjectDescription;
            boProject.StartDate = project.StartDate;
            boProject.EndDate = project.EndDate;

            return boProject;
        }
        public static BOTechnology ConvertTechnologyToBOTechnology(TechnologyMaster technology)
        {
            BOTechnology boTechnology = new BOTechnology();

            boTechnology.TechnologyId = technology.TechnologyId;
            boTechnology.TechnologyName = technology.TechnologyName;

            return boTechnology;
        }
        public static BOEmployee ConvertEmployeeToBOEmployee(Employee employee)
        {
            BOEmployee boEmployee = new BOEmployee();

            boEmployee.EmployeeId = employee.EmployeeId;
            boEmployee.DepartmentId = employee.DepartmentId;
            boEmployee.DesignationId = employee.DesignationId;
            boEmployee.AddressId = employee.AddressId;
            boEmployee.FirstName = employee.FirstName;
            boEmployee.MiddleName = employee.MiddleName;
            boEmployee.LastName = employee.LastName;
            boEmployee.Email = employee.Email;
            boEmployee.Phone = employee.Phone;
            boEmployee.Salary = employee.Salary;
            boEmployee.JoinDate = employee.JoinDate;
            boEmployee.Dob = employee.Dob;

            return boEmployee;
        }
        public static BOTask ConvertTaskToBOTask(CompanyManagementDataLayer.Task task)
        {
            BOTask boTask = new BOTask();

            boTask.TaskId = task.TaskId;
            boTask.StatusId = task.StatusId;
            boTask.TaskTittle = task.TaskTittle;
            boTask.TaskDescription = task.TaskDescription;


            return boTask;
        }
        public static Project ConvertBOProjectToProject(BOProject boProject)
        {
            Project project = new Project();

            project.ProjectId = boProject.ProjectId;
            project.ClientId = boProject.ClientId;
            project.DepartmentId = boProject.DepartmentId;
            project.StatusId = boProject.StatusId;
            project.ProjectName = boProject.ProjectName;
            project.ProjectDescription = boProject.ProjectDescription;
            project.StartDate = boProject.StartDate;
            project.EndDate = boProject.EndDate;

            return project;
        }
        public static TechnologyMaster ConvertBOTechnologyToTechnology(BOTechnology boTechnology)
        {
            TechnologyMaster technology = new TechnologyMaster();

            technology.TechnologyId = boTechnology.TechnologyId;
            technology.TechnologyName = boTechnology.TechnologyName;

            return technology;
        }

        public static Employee ConvertBOEmployeeToEmployee(BOEmployee boEmployee)
        {
            Employee employee = new Employee();

            employee.EmployeeId = boEmployee.EmployeeId;
            employee.DepartmentId = boEmployee.DepartmentId;
            employee.DesignationId = boEmployee.DesignationId;
            employee.AddressId = boEmployee.AddressId;
            employee.FirstName = boEmployee.FirstName;
            employee.MiddleName = boEmployee.MiddleName;
            employee.LastName = boEmployee.LastName;
            employee.Email = boEmployee.Email;
            employee.Phone = boEmployee.Phone;
            employee.Salary = boEmployee.Salary;
            employee.JoinDate = boEmployee.JoinDate;
            employee.Dob = boEmployee.Dob;

            return employee;
        }
        public static CompanyManagementDataLayer.Task ConvertBOTaskToTask(BOTask boTask)
        {
            CompanyManagementDataLayer.Task task = new CompanyManagementDataLayer.Task();

            task.TaskId = boTask.TaskId;
            task.StatusId = boTask.StatusId;
            task.TaskTittle = boTask.TaskTittle;
            task.TaskDescription = boTask.TaskDescription;
            return task;
        }

    }
}
