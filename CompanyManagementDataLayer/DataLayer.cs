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

        public object TaskId { get; private set; }

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

        public List<Employee> GetAllEmployeesForProjects(int projectID)
        {
            List<Employee> employees = (from empProject in dataContext.EmployeeProjects
                                                      where empProject.ProjectId == projectID
                                                      select empProject.Employee).ToList();
            return employees;
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
            List<Project> projects = (from empProject in dataContext.EmployeeProjects
                                             where empProject.EmployeeId == employeeID
                                                      select empProject.Project).ToList();
            return projects;
        }
        
        public List<Task> GetAllTasksForEmployee(int employeeID)
        {
            List<Task> tasks = (from empTask in dataContext.EmployeeTasks
                                      where empTask.EmployeeId == employeeID
                                      select empTask.Task).ToList();
            return tasks;
        }
        public List<Task> GetAllTechnologyTasksForEmployee(int technologyID,int employeeID)
        {
            List<int> taskIds = (from empTask in dataContext.EmployeeTasks
                                where empTask.EmployeeId == employeeID
                                select empTask.TaskId).ToList();
           
            List<Task> tasks = (from taskTechnology in dataContext.TaskTechnologies
                                               where taskIds.Contains(taskTechnology.TaskId) && taskTechnology.TechnologyId== technologyID
                                    select taskTechnology.Task).ToList();
            return tasks;
            
        }
        public List<Project> GetAllTechnologyProjects(int technologyID)
        {
            List<Project> projects = (from projectTechnology in dataContext.ProjectTechnologies
                                      where projectTechnology.TechnologyId == technologyID
                                      select projectTechnology.Project).ToList();
            return projects;
        }
        public List<Task> GetAllActiveTasksForProject(int projectID)
        {
            List<Task> tasks = (from projectTask in dataContext.ProjectTasks
                                 where projectTask.ProjectId == projectID && projectTask.Task.StatusId == Convert.ToInt32(CMEnum.Status.Active)
                                 select projectTask.Task).ToList();

            
            return tasks;
        }
        public List<TechnologyMaster> GetAllTechnologiesForEmployee(int employeeID)
        {
            List<int> projectIds = (from empProject in dataContext.EmployeeProjects
                                where empProject.EmployeeId == employeeID
                                select empProject.ProjectId).ToList();
            List<TechnologyMaster> technologies = (from projectTechnology in dataContext.ProjectTechnologies
                                    where projectIds.Contains(projectTechnology.ProjectId)
                                    select projectTechnology.TechnologyMaster).ToList();
            return technologies;
        }
        public int GetProjectCountForEmployee(int employeeID)
        {
            int projectCount = (from empProject in dataContext.EmployeeProjects
                                 where empProject.EmployeeId == employeeID
                                 select empProject).Count();

            return projectCount;
        }
        
        public List<Project> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            List<Project> projects = (from empProject in dataContext.EmployeeProjects
                                where empProject.EmployeeId == employeeID && empProject.Project.StatusId == Convert.ToInt32(CMEnum.Status.Active)
                                select empProject.Project).ToList();


            return projects;
        }
        public List<Task> GetAllDelayedTasksForEmployee(int employeeID)
        {
            List<Task> tasks = (from empTask in dataContext.EmployeeTasks
                                      where empTask.EmployeeId == employeeID && empTask.Task.StatusId == Convert.ToInt32(CMEnum.Status.Delayed)
                                      select empTask.Task).ToList();


            return tasks;
        }
        public void AddProject(Project project)
        {
            string checkCompulsoryFields = DataLayerHelper.CheckCompulsoryProjectColumn(project);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }
            
            dataContext.Projects.InsertOnSubmit(project);
            dataContext.SubmitChanges();
        }

       
       
        public void AddTechnology(TechnologyMaster technology)
        {
            string checkCompulsoryFields = DataLayerHelper.CheckCompulsoryTechnologyColumn(technology);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            dataContext.TechnologyMasters.InsertOnSubmit(technology);
            dataContext.SubmitChanges();
        }

        public void AddEmployee(Employee employee)
        {
            string checkCompulsoryFields = DataLayerHelper.CheckCompulsoryEmployeeColumn(employee);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            dataContext.Employees.InsertOnSubmit(employee);
            dataContext.SubmitChanges();
        }

        public void AssignEmployeeToProject(int employeeID, int projectID)
        {
            string checkCompulsoryFields = DataLayerHelper.CheckCompulsoryEmployeeProjectColumn(employeeID, projectID);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            bool isEmployeeExist = IsEmployeeExist(employeeID);
            if (!isEmployeeExist)
            {
                throw new Exception(CMResources.EmployeeIDNotExist);
            }
            bool isProjectExist = IsProjectExist(projectID);
            if (!isProjectExist)
            {
                throw new Exception(CMResources.ProjectIDNotExist);
            }
            bool isEmployeeProjectExist = IsEmployeeProjectExist(projectID, employeeID);

            if (isEmployeeProjectExist)
            {
                throw new Exception(CMResources.EmployeeAlreadyExistProject);
            }

            EmployeeProject employeeProject = new EmployeeProject();
            employeeProject.EmployeeId = employeeID;
            employeeProject.ProjectId = projectID;
            dataContext.EmployeeProjects.InsertOnSubmit(employeeProject);
            dataContext.SubmitChanges();
        }
        public void CreateTaskInProject(Task task, int projectID)
        {
            string checkCompulsoryFields = DataLayerHelper.CheckCompulsoryProjectTaskColumn(task);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }
            bool isProjectExist = IsProjectExist(projectID);
            if (!isProjectExist)
            {
                throw new Exception(CMResources.ProjectIDNotExist);
            }
            dataContext.Tasks.InsertOnSubmit(task);
            dataContext.SubmitChanges();

            ProjectTask projectTask = new ProjectTask();
            projectTask.TaskId = task.TaskId;
            projectTask.ProjectId = projectID;
            dataContext.ProjectTasks.InsertOnSubmit(projectTask);
            dataContext.SubmitChanges();
        }
        public void AssignTechnologyToTask(int technologyID, int taskID)
        {
            string checkCompulsoryFields = DataLayerHelper.CheckCompulsoryTechnologyTaskColumn(technologyID, taskID);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }

            bool isTechnologyExist = IsTechnologyExist(technologyID);
            if (!isTechnologyExist)
            {
                throw new Exception(CMResources.TechnologyIDNotExist);
            }
            bool isTaskExist = IsTaskExist(taskID);
            if (!isTaskExist)
            {
                throw new Exception(CMResources.TaskIDNotExist);
            }
            bool isTechnologyTaskExist = IsTechnologyTaskExist(technologyID, taskID);

            if (isTechnologyTaskExist)
            {
                throw new Exception(CMResources.TechnologyAlreadyExistTask);
            }

            TaskTechnology taskTechnology = new TaskTechnology();
            taskTechnology.TaskId = taskID;
            taskTechnology.TechnologyId = technologyID;
            dataContext.TaskTechnologies.InsertOnSubmit(taskTechnology);
            dataContext.SubmitChanges();
        }
        
        public void UpdateTechnologiesForTask(List<int> technologyIDs, int taskID)
        {
            string checkCompulsoryFields = DataLayerHelper.CheckCompulsoryTechnologyTaskUpdateColumn(technologyIDs, taskID);
            if (checkCompulsoryFields != CMResources.AllFieldsPresent)
            {
                throw new Exception(checkCompulsoryFields);
            }
           
            bool isTaskExist = IsTaskExist(taskID);
            if (!isTaskExist)
            {
                throw new Exception(CMResources.TaskIDNotExist);
            }

            List<TaskTechnology> taskTechnologies = (from taskTechnology in dataContext.TaskTechnologies
                                         where taskTechnology.TaskId == taskID
                                         select taskTechnology).ToList();

            dataContext.TaskTechnologies.DeleteAllOnSubmit(taskTechnologies);
            dataContext.SubmitChanges();


            foreach (int technologyID in technologyIDs)
            {
                bool isTechnologyExist = IsTechnologyExist(technologyID);
                if (!isTechnologyExist)
                {
                    throw new Exception(CMResources.TechnologyIDNotExist);
                }
            }

            foreach (int technologyID in technologyIDs)
            {
                TaskTechnology taskTechnology = new TaskTechnology();
                taskTechnology.TaskId = taskID;
                taskTechnology.TechnologyId = technologyID;
                dataContext.TaskTechnologies.InsertOnSubmit(taskTechnology);
                dataContext.SubmitChanges();
            }

        }
        
        public void DeleteEmployeeFromSystem(int employeeID)
        {
            List<EmployeeProject> employeeProjects = (from employeeProject in dataContext.EmployeeProjects
                                                      where employeeProject.EmployeeId == employeeID
                                                      select employeeProject).ToList();
            if (employeeProjects.Count > 0)
            {
                dataContext.EmployeeProjects.DeleteAllOnSubmit(employeeProjects);
                dataContext.SubmitChanges();
            }
            List<EmployeeTask> employeeTasks = (from employeeTask in dataContext.EmployeeTasks
                                                      where employeeTask.EmployeeId == employeeID
                                                      select employeeTask).ToList();
            if (employeeTasks.Count > 0)
            {
                dataContext.EmployeeTasks.DeleteAllOnSubmit(employeeTasks);
                dataContext.SubmitChanges();
            }

            Employee employee = (from employer in dataContext.Employees
                                       where employer.EmployeeId == employeeID
                                       select employer).FirstOrDefault();
            if (employee != null)
            {
                dataContext.Employees.DeleteOnSubmit(employee);
                dataContext.SubmitChanges();
            }
        }
        public void DeleteTechnology(int technologyID)
        {
            List<ProjectTechnology> projectTechnologies = (from projectTech in dataContext.ProjectTechnologies
                                                      where projectTech.TechnologyId == technologyID
                                                         select projectTech).ToList();
            if (projectTechnologies.Count > 0)
            {
                dataContext.ProjectTechnologies.DeleteAllOnSubmit(projectTechnologies);
                dataContext.SubmitChanges();
            }
            List<TaskTechnology> taskTechnology = (from taskTech in dataContext.TaskTechnologies
                                                where taskTech.TechnologyId == technologyID
                                                   select taskTech).ToList();
            if (taskTechnology.Count > 0)
            {
                dataContext.TaskTechnologies.DeleteAllOnSubmit(taskTechnology);
                dataContext.SubmitChanges();
            }

            TechnologyMaster technology = (from tech in dataContext.TechnologyMasters
                                 where tech.TechnologyId == technologyID
                                 select tech).FirstOrDefault();
            if (technology != null)
            {
                dataContext.TechnologyMasters.DeleteOnSubmit(technology);
                dataContext.SubmitChanges();
            }
        }
        public void DeleteTask(int taskID)
        {
            List<EmployeeTask> employeeTasks = (from employeeTask in dataContext.EmployeeTasks
                                                           where employeeTask.TaskId == taskID
                                                select employeeTask).ToList();
            if (employeeTasks.Count > 0)
            {
                dataContext.EmployeeTasks.DeleteAllOnSubmit(employeeTasks);
                dataContext.SubmitChanges();
            }
            List<ProjectTask> projectTasks = (from projectTask in dataContext.ProjectTasks
                                                   where projectTask.TaskId == taskID
                                              select projectTask).ToList();
            if (projectTasks.Count > 0)
            {
                dataContext.ProjectTasks.DeleteAllOnSubmit(projectTasks);
                dataContext.SubmitChanges();
            }
            List<TaskTechnology> taskTechnologies = (from taskTechnology in dataContext.TaskTechnologies
                                              where taskTechnology.TaskId == taskID
                                              select taskTechnology).ToList();
            if (taskTechnologies.Count > 0)
            {
                dataContext.TaskTechnologies.DeleteAllOnSubmit(taskTechnologies);
                dataContext.SubmitChanges();
            }

            Task task = (from tsk in dataContext.Tasks
                                           where tsk.TaskId == taskID
                                           select tsk).FirstOrDefault();
            if (task != null)
            {
                dataContext.Tasks.DeleteOnSubmit(task);
                dataContext.SubmitChanges();
            }
        }
        public void DeleteProject(int projectID)
        {
            List<EmployeeProject> employeeProjects = (from employeeProject in dataContext.EmployeeProjects
                                                where employeeProject.ProjectId == projectID
                                                      select employeeProject).ToList();
            if (employeeProjects.Count > 0)
            {
                dataContext.EmployeeProjects.DeleteAllOnSubmit(employeeProjects);
                dataContext.SubmitChanges();
            }
            List<ProjectTask> projectTasks = (from projectTask in dataContext.ProjectTasks
                                              where projectTask.ProjectId == projectID
                                              select projectTask).ToList();
            if (projectTasks.Count > 0)
            {
                dataContext.ProjectTasks.DeleteAllOnSubmit(projectTasks);
                dataContext.SubmitChanges();
            }
            List<ProjectTechnology> projectTechnologies = (from projectTechnology in dataContext.ProjectTechnologies
                                                     where projectTechnology.ProjectId == projectID
                                                           select projectTechnology).ToList();
            if (projectTechnologies.Count > 0)
            {
                dataContext.ProjectTechnologies.DeleteAllOnSubmit(projectTechnologies);
                dataContext.SubmitChanges();
            }

            Project project = (from pro in dataContext.Projects
                          where pro.ProjectId == projectID
                                select pro).FirstOrDefault();
            if (project != null)
            {
                dataContext.Projects.DeleteOnSubmit(project);
                dataContext.SubmitChanges();
            }
        }
        private bool IsEmployeeExist(int employeeId)
        {
            bool isExist = (from employee in dataContext.Employees
                                 where employee.EmployeeId == employeeId
                                 select employee).Any();            
            return isExist;
        }
        private bool IsProjectExist(int projectID)
        {
            bool isExist = (from project in dataContext.Projects
                            where project.ProjectId == projectID
                            select project).Any();
            return isExist;
        }
        private bool IsTechnologyExist(int technologyID)
        {
            bool isExist = (from technology in dataContext.TechnologyMasters
                            where technology.TechnologyId == technologyID
                            select technology).Any();
            return isExist;
        }
        private bool IsTaskExist(int taskID)
        {
            bool isExist = (from task in dataContext.Tasks
                            where task.TaskId == taskID
                            select task).Any();
            return isExist;
        }

        private bool IsEmployeeProjectExist(int projectID, int employeeID)
        {
            bool isExist = (from empProject in dataContext.EmployeeProjects
                                 where empProject.ProjectId == projectID && empProject.EmployeeId == employeeID
                                 select empProject).Any();
            return isExist;
        }
        private bool IsTechnologyTaskExist(int technologyID, int taskID)
        {
            bool isExist = (from taskTechnology in dataContext.TaskTechnologies
                            where taskTechnology.TechnologyId == technologyID && taskTechnology.TaskId == taskID
                            select taskTechnology).Any();
            return isExist;
        }
        
    }
}
