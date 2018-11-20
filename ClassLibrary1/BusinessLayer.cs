using CompanyManagementBusinessLayer.Entities;
using CompanyManagementDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementBusinessLayer
{
    public class BusinessLayer
    {
        DataLayer dataLayer = new DataLayer();

        public List<BOProject> GetAllProjects()
        {
            List<Project> projects = dataLayer.GetAllProjects();
            List<BOProject> businessProjects = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
            return businessProjects;
        }
        public List<BOTechnology> GetAllTechnologies()
        {
            List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
            List<BOTechnology> businessTechnologies = BusinessLayerHelper.ConvertTechnologyListToBOTechnologyList(technologies);
            return businessTechnologies;
        }
        public int GetEmployeeCountForProject(int ProjectID)
        {
            int employeeCount = dataLayer.GetEmployeeCountForProject(ProjectID);
            return employeeCount;
        }
        public List<BOEmployee> GetAllEmployeesForProjects(int projectID)
        {
            List<Employee> employees = dataLayer.GetAllEmployeesForProjects(projectID);
            List<BOEmployee> businessEmployees = BusinessLayerHelper.ConvertEmployeeListToBOEmployeeList(employees);
            return businessEmployees;
        }
        public List<BOProject> GetAllDelayedProjects()
        {
            int delayedStatus = Convert.ToInt32(CMEnum.Status.Delayed);
            List<Project> projects = dataLayer.GetAllDelayedProjects(delayedStatus);
            List<BOProject> businessProjectsDelayed = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
            return businessProjectsDelayed;
        }
        public List<BOProject> GetAllProjectsForEmployees(int employeeID)
        {
            List<Project> projects = dataLayer.GetAllProjectsForEmployees(employeeID);
            List<BOProject> businessProjectsForEmployee = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
            return businessProjectsForEmployee;
        }
        public List<BOTask> GetAllTasksForEmployee(int employeeID)
        {
            List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTasksForEmployee(employeeID);
            List<BOTask> businessTasksForEmployee = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
            return businessTasksForEmployee;
        }
        public List<BOTask> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTechnologyTasksForEmployee(technologyID, employeeID);
            List<BOTask> businessTechnologyTasksForEmployee = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
            return businessTechnologyTasksForEmployee;
        }
        public List<BOProject> GetAllTechnologyProjects(int technologyID)
        {
            List<Project> projects = dataLayer.GetAllTechnologyProjects(technologyID);
            List<BOProject> businessTechnologyProjects = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
            return businessTechnologyProjects;
        }
        public List<BOTask> GetAllActiveTasksForProject(int projectID)
        {
            int activeStatus = Convert.ToInt32(CMEnum.Status.Active);
            List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllActiveTasksForProject(projectID, activeStatus);
            List<BOTask> businessTaskForProjects = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
            return businessTaskForProjects;
        }
        public List<BOTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            List<TechnologyMaster> technologies = dataLayer.GetAllTechnologiesForEmployee(employeeID);
            List<BOTechnology> businessTaskForProjects = BusinessLayerHelper.ConvertTechnologyListToBOTechnologyList(technologies);
            return businessTaskForProjects;
        }
        public int GetProjectCountForEmployee(int employeeID)
        {
            int projectCount = dataLayer.GetProjectCountForEmployee(employeeID);
            return projectCount;
        }
        public List<BOProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            int activeStatus = Convert.ToInt32(CMEnum.Status.Active);
            List<Project> projects = dataLayer.GetAllActiveProjectsManagedByEmployee(employeeID, activeStatus);
            List<BOProject> businessActiveProjectsForEmployee = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
            return businessActiveProjectsForEmployee;
        }
        public List<BOTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            int delayedStatus = Convert.ToInt32(CMEnum.Status.Delayed);
            List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllDelayedTasksForEmployee(employeeID, delayedStatus);
            List<BOTask> businessDelayedTaskForemployee = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
            return businessDelayedTaskForemployee;
        }
        public void AddProject(BOProject boProject)
        {
            Project project = BusinessLayerHelper.ConvertBOProjectToProject(boProject);
            dataLayer.AddProject(project);
        }
        public void AddTechnology(BOTechnology boTechnology)
        {
            TechnologyMaster technology = BusinessLayerHelper.ConvertBOTechnologyToTechnology(boTechnology);
            dataLayer.AddTechnology(technology);
        }
        public void AddEmployee(BOEmployee boEmployee)
        {
            Employee employee = BusinessLayerHelper.ConvertBOEmployeeToEmployee(boEmployee);
            dataLayer.AddEmployee(employee);
        }
        public void AssignEmployeeToProject(int employeeID,int projectID)
        {
            dataLayer.AssignEmployeeToProject(employeeID, projectID);
        }
        public void CreateTaskInProject(BOTask boTask, int projectID)
        {
            CompanyManagementDataLayer.Task task = BusinessLayerHelper.ConvertBOTaskToTask(boTask);
            dataLayer.CreateTaskInProject(task, projectID);
        }
        public void AssignTechnologyToTask(int technologyID, int taskID)
        {
            dataLayer.AssignTechnologyToTask(technologyID, taskID);
        }
        public void UpdateTechnologiesForTask(List<int> technologyID, int taskID)
        {
            dataLayer.UpdateTechnologiesForTask(technologyID, taskID);
        }
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            dataLayer.DeleteEmployeeFromSystem(employeeID);
        }
        public void DeleteTechnology(int technologyID)
        {
            dataLayer.DeleteTechnology(technologyID);
        }
        public void DeleteTask(int taskID)
        {
            dataLayer.DeleteTask(taskID);
        }
        public void DeleteProject(int projectID)
        {
            dataLayer.DeleteProject(projectID);
        }
    }
}
