﻿using System;
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

        public List<EmployeeProject> GetAllEmployeesForProjects(int projectID)
        {
            List<EmployeeProject> employeeProjects = (from empProject in dataContext.EmployeeProjects
                                                      where empProject.ProjectId == projectID
                                                      select empProject).ToList();
            return employeeProjects;
        }
        public List<Project> GetAllDelayedProjects()
        {
            List<Project> delayedProjects = (from project in dataContext.Projects
                                                      where project.StatusId == Convert.ToInt32(CMEnum.Status.Delayed)
                                                      select project).ToList();
            return delayedProjects;
        }
        public List<Project> GetAllProjectsForEmployees(int employeeID)
        {
            List<Project> employeeProjects = (from empProject in dataContext.EmployeeProjects
                                             where empProject.EmployeeId == employeeID
                                                      select empProject.Project).ToList();
            return employeeProjects;
        }
       public void AddProject(Project project)
        {
            string checkCompulsoryFields = CheckCompulsoryProjectColumn(project);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }
            
            dataContext.Projects.InsertOnSubmit(project);
            dataContext.SubmitChanges();
        }

       
       
        public void AddTechnology(TechnologyMaster technology)
        {
            string checkCompulsoryFields = CheckCompulsoryTechnologyColumn(technology);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            dataContext.TechnologyMasters.InsertOnSubmit(technology);
            dataContext.SubmitChanges();
        }

        public void AddEmployee(Employee employee)
        {
            string checkCompulsoryFields = CheckCompulsoryEmployeeColumn(employee);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            dataContext.Employees.InsertOnSubmit(employee);
            dataContext.SubmitChanges();
        }

        public void AssignEmployeeToProject(int employeeID, int projectID)
        {
            string checkCompulsoryFields = CheckCompulsoryEmployeeProjectColumn(employeeID, projectID);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            int employeeCount = (from empProject in dataContext.EmployeeProjects
                                 where empProject.ProjectId == projectID && empProject.EmployeeId == employeeID
                                 select empProject).Count();

            if (employeeCount > 0)
            {
                throw new Exception(CMResources.EmployeeAlreadyExistProject);
            }

            EmployeeProject employeeProject = new EmployeeProject();
            employeeProject.EmployeeId = employeeID;
            employeeProject.ProjectId = projectID;
            dataContext.EmployeeProjects.InsertOnSubmit(employeeProject);
            dataContext.SubmitChanges();
        }
        
        private string CheckCompulsoryProjectColumn(Project project)
        {
            if (project.ClientId == 0)
            {
                return CMResources.ClientIDMissing;
            }
            else if (project.DepartmentId == 0)
            {
                return CMResources.DepartmentIDMissing;
            }
            else if (project.StatusId == 0)
            {
                return CMResources.StatusIDMissing;
            }
            else if (string.IsNullOrEmpty(project.ProjectName))
            {
                return CMResources.ProjectNameMissing;
            }
            else
            {
                return CMResources.AllFieldsPresent;
            }
        }

        private string CheckCompulsoryTechnologyColumn(TechnologyMaster technology)
        {
            if (string.IsNullOrEmpty(technology.TechnologyName))
            {
                return CMResources.TechnologyNameMissing;
            }
            else
            {
                return CMResources.AllFieldsPresent;
            }

        }             

        private string CheckCompulsoryEmployeeColumn(Employee employee)
        {
            if (employee.DepartmentId == 0)
            {
                return CMResources.DepartmentIDMissing;
            }
            else if (employee.DesignationId == 0)
            {
                return CMResources.DesignationIDMissing;
            }
            else if (employee.AddressId == 0)
            {
                return CMResources.AddressIDMissing;
            }
            if (string.IsNullOrEmpty(employee.FirstName))
            {
                return CMResources.FirstNameMissing;
            }
            else if (string.IsNullOrEmpty(employee.LastName))
            {
                return CMResources.LastNameMissing;
            }           
            else
            {
                return CMResources.AllFieldsPresent;
            }
        }
               
        private string CheckCompulsoryEmployeeProjectColumn(int employeeID, int projectID)
        {

            if (employeeID == 0)
            {
                return CMResources.EmployeeIDMissing;
            }
            else if (projectID == 0)
            {
                return CMResources.ProjectIDMissing;
            }
            else
            {
                return CMResources.AllFieldsPresent;
            }
        }        
    }
}
