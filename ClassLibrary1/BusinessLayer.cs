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
            try
            {
                List<Project> projects = dataLayer.GetAllProjects();
                List<BOProject> businessProjects = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
                return businessProjects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOTechnology> GetAllTechnologies()
        {
            try
            {
                List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
                List<BOTechnology> businessTechnologies = BusinessLayerHelper.ConvertTechnologyListToBOTechnologyList(technologies);
                return businessTechnologies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetEmployeeCountForProject(int ProjectID)
        {
            try
            {
                int employeeCount = dataLayer.GetEmployeeCountForProject(ProjectID);
                return employeeCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOEmployee> GetAllEmployeesForProjects(int projectID)
        {
            try
            {
                List<Employee> employees = dataLayer.GetAllEmployeesForProjects(projectID);
                List<BOEmployee> businessEmployees = BusinessLayerHelper.ConvertEmployeeListToBOEmployeeList(employees);
                return businessEmployees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOProject> GetAllDelayedProjects()
        {
            try
            {
                int delayedStatus = Convert.ToInt32(CMEnum.Status.Delayed);
                List<Project> projects = dataLayer.GetAllDelayedProjects(delayedStatus);
                List<BOProject> businessProjectsDelayed = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
                return businessProjectsDelayed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOProject> GetAllProjectsForEmployees(int employeeID)
        {
            try
            {
                List<Project> projects = dataLayer.GetAllProjectsForEmployees(employeeID);
                List<BOProject> businessProjectsForEmployee = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
                return businessProjectsForEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOTask> GetAllTasksForEmployee(int employeeID)
        {
            try
            {
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTasksForEmployee(employeeID);
                List<BOTask> businessTasksForEmployee = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
                return businessTasksForEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public List<BOTask> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            try
            {
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllTechnologyTasksForEmployee(technologyID, employeeID);
                List<BOTask> businessTechnologyTasksForEmployee = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
                return businessTechnologyTasksForEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOProject> GetAllTechnologyProjects(int technologyID)
        {
            try
            {
                List<Project> projects = dataLayer.GetAllTechnologyProjects(technologyID);
                List<BOProject> businessTechnologyProjects = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
                return businessTechnologyProjects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOTask> GetAllActiveTasksForProject(int projectID)
        {
            try
            {
                int activeStatus = Convert.ToInt32(CMEnum.Status.Active);
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllActiveTasksForProject(projectID, activeStatus);
                List<BOTask> businessTaskForProjects = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
                return businessTaskForProjects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOTechnology> GetAllTechnologiesForEmployee(int employeeID)
        {
            try
            {
                List<TechnologyMaster> technologies = dataLayer.GetAllTechnologiesForEmployee(employeeID);
                List<BOTechnology> businessTaskForProjects = BusinessLayerHelper.ConvertTechnologyListToBOTechnologyList(technologies);
                return businessTaskForProjects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetProjectCountForEmployee(int employeeID)
        {
            try
            {
                int projectCount = dataLayer.GetProjectCountForEmployee(employeeID);
                return projectCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOProject> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            try
            {
                int activeStatus = Convert.ToInt32(CMEnum.Status.Active);
                List<Project> projects = dataLayer.GetAllActiveProjectsManagedByEmployee(employeeID, activeStatus);
                List<BOProject> businessActiveProjectsForEmployee = BusinessLayerHelper.ConvertProjectListToBOProjectList(projects);
                return businessActiveProjectsForEmployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BOTask> GetAllDelayedTasksForEmployee(int employeeID)
        {
            try
            {
                int delayedStatus = Convert.ToInt32(CMEnum.Status.Delayed);
                List<CompanyManagementDataLayer.Task> tasks = dataLayer.GetAllDelayedTasksForEmployee(employeeID, delayedStatus);
                List<BOTask> businessDelayedTaskForemployee = BusinessLayerHelper.ConvertTaskListToBOTaskList(tasks);
                return businessDelayedTaskForemployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddProject(BOProject boProject)
        {
            try
            {
                Project project = BusinessLayerHelper.ConvertBOProjectToProject(boProject);
                dataLayer.AddProject(project);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddTechnology(BOTechnology boTechnology)
        {
            try
            {
                TechnologyMaster technology = BusinessLayerHelper.ConvertBOTechnologyToTechnology(boTechnology);
                dataLayer.AddTechnology(technology);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddEmployee(BOEmployee boEmployee)
        {
            try
            {
                Employee employee = BusinessLayerHelper.ConvertBOEmployeeToEmployee(boEmployee);
                dataLayer.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AssignEmployeeToProject(int employeeID,int projectID)
        {
            try
            {
                dataLayer.AssignEmployeeToProject(employeeID, projectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CreateTaskInProject(BOTask boTask, int projectID)
        {
            try
            {
                CompanyManagementDataLayer.Task task = BusinessLayerHelper.ConvertBOTaskToTask(boTask);
                dataLayer.CreateTaskInProject(task, projectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AssignTechnologyToTask(int technologyID, int taskID)
        {
            try
            {
                bool isTechnologyExist = dataLayer.IsTechnologyExistInTasksProject(technologyID, taskID);
                if (isTechnologyExist)
                {
                    dataLayer.AssignTechnologyToTask(technologyID, taskID);
                }
                else
                {
                    throw new Exception(CMBusinessResources.TechnologyNotAssigned);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateTechnologiesForTask(List<int> technologyID, int taskID)
        {
            try
            {
                dataLayer.UpdateTechnologiesForTask(technologyID, taskID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            try
            {
                dataLayer.DeleteEmployeeFromSystem(employeeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteTechnology(int technologyID)
        {
            try
            {
                int technologyCountInProjects = dataLayer.GetProjectCountForTechnology(technologyID);
                if (technologyCountInProjects >= Convert.ToInt32(CMBusinessResources.MaxNumberOfProjects))
                {
                    dataLayer.DeleteTechnology(technologyID);
                }
                else
                {
                    throw new Exception("Cannot delete technology used in more than" + Convert.ToInt32(CMBusinessResources.MaxNumberOfProjects) + "projects");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteTask(int taskID)
        {
            try
            {
                int status = Convert.ToInt32(CMEnum.Status.NotStarted);
                bool isStarted = dataLayer.IsTaskAlreadyStarted(status, taskID);
                if (!isStarted)
                {
                    dataLayer.DeleteTask(taskID);
                }
                else
                {
                    throw new Exception(CMBusinessResources.AlreadyStartedTaskNotDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteProject(int projectID)
        {
            try
            {
                dataLayer.DeleteProject(projectID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
