using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class ManageResourceViewModel : BaseViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Middlename { get; set; }
        public string Position { get; set; }
        public string ZinzaiId { get; set; }
        public string EmployeeEmail { get; set; }
        //Mr., Ms., Mrs.
        public string PersonTitle { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeLocation { get; set; }
        public string Grade_Level { get; set; }
        public string FJLevel { get; set; }
        public string JLPTLevel { get; set; }
        //Probationary, Regular
        public string EmployeeContractStatus { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime RegularizationDate { get; set; }
        public string? EmployeeProjects { get; set; }
        public string? EmployeeSkills { get; set; }
        public string? Gender { get; set; }
        public DateTime EndOfEmployment { get; set; }
        public DateTime ResignationDate { get; set; }
        public bool IsBench { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public int UnitId { get; set; }
        public bool IsReference { get; set; }
        public bool IsManager { get; set; }
        public bool IsOperationManager { get; set; }
        public bool IsHR { get; set; }
        public bool IsTrainer { get; set; }
    }

    public class ManageResourceCreateViewModel : BaseViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Middlename { get; set; }
        public string Position { get; set; }
        public string ZinzaiId { get; set; }
        public string EmployeeEmail { get; set; }
        //Mr., Ms., Mrs.
        public string PersonTitle { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeLocation { get; set; }
        public string Grade_Level { get; set; }
        public string FJLevel { get; set; }
        public string JLPTLevel { get; set; }
        //Probationary, Regular
        public string EmployeeContractStatus { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime RegularizationDate { get; set; }
        public string? EmployeeProjects { get; set; }
        public string? EmployeeSkills { get; set; }
        public string? Gender { get; set; }
        public DateTime EndOfEmployment { get; set; }
        public DateTime ResignationDate { get; set; }
        public bool IsBench { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public int UnitId { get; set; }
        public bool IsReference { get; set; }
        public bool IsManager { get; set; }
        public bool IsOperationManager { get; set; }
        public bool IsHR { get; set; }
        public bool IsTrainer { get; set; }
    }


    public class ManageResourceUpdateViewModel : BaseViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Middlename { get; set; }
        public string Position { get; set; }
        public string ZinzaiId { get; set; }
        public string EmployeeEmail { get; set; }
        //Mr., Ms., Mrs.
        public string PersonTitle { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeLocation { get; set; }
        public string Grade_Level { get; set; }
        public string FJLevel { get; set; }
        public string JLPTLevel { get; set; }
        //Probationary, Regular
        public string EmployeeContractStatus { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime RegularizationDate { get; set; }
        public string? EmployeeProjects { get; set; }
        public string? EmployeeSkills { get; set; }
        public string? Gender { get; set; }
        public DateTime EndOfEmployment { get; set; }
        public DateTime ResignationDate { get; set; }
        public bool IsBench { get; set; }
        public int RBUId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public int UnitId { get; set; }
        public bool IsReference { get; set; }
        public bool IsManager { get; set; }
        public bool IsOperationManager { get; set; }
        public bool IsHR { get; set; }
        public bool IsTrainer { get; set; }
    }

    public class ManageResourceIndexViewModel : BaseViewModel
    {
        public int PersonId { get; set; }
        public string EmployeeFullname { get; set; }
        public string ZinzaiId { get; set; }
        public string Position { get; set; }
        public string Skills { get; set; }
    }
}
