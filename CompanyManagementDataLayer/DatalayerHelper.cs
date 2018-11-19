using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementDataLayer
{
    public static class DataLayerHelper
    {
        public static string CheckCompulsoryProjectTaskColumn(Task task)
        {
            if (task.StatusId == 0)
            {
                return CMResources.StatusIDMissing;
            }
            else if (string.IsNullOrEmpty(task.TaskTittle))
            {
                return CMResources.TaskNameMissing;
            }
            else
            {
                return CMResources.AllFieldsPresent;
            }

        }
        public static string CheckCompulsoryProjectColumn(Project project)
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

        public static string CheckCompulsoryTechnologyColumn(TechnologyMaster technology)
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

        public static string CheckCompulsoryEmployeeColumn(Employee employee)
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

        public static string CheckCompulsoryEmployeeProjectColumn(int employeeID, int projectID)
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
        public static string CheckCompulsoryTechnologyTaskColumn(int technologyID, int taskID)
        {

            if (technologyID == 0)
            {
                return CMResources.TechnologyIDMissing;
            }
            else if (taskID == 0)
            {
                return CMResources.TaskIDMissing;
            }
            else
            {
                return CMResources.AllFieldsPresent;
            }
        }
        public static string CheckCompulsoryTechnologyTaskUpdateColumn(List<int> technologyIDs, int taskID)
        {

            if (technologyIDs.Count == 0)
            {
                return CMResources.TechnologyIDMissing;
            }
            else if (taskID == 0)
            {
                return CMResources.TaskIDMissing;
            }
            else
            {
                return CMResources.AllFieldsPresent;
            }
        }
        

    }
}
