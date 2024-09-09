using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class Person : BaseModel
    {
        [Key]
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

    }
}
