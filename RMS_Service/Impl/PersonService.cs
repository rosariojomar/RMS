using RMS_DAL.Interfaces;
using RMS_DAL.Models;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RMS_Service.Impl
{
    public class PersonService : IPersonService
    {
        private readonly RMSContext _context;

        public PersonService(RMSContext context)
        {
            _context = context;
        }
        public int CreatePerson(PersonCreateViewModel vm)
        {
            var personModel = new Person()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Middlename = vm.Middlename,
                Position = vm.Position,
                ZinzaiId = vm.ZinzaiId,
                EmployeeEmail = vm.EmployeeEmail,
                PersonTitle = vm.PersonTitle,
                EmployeeStatus = vm.EmployeeStatus,
                EmployeeTitle = vm.EmployeeTitle,
                EmployeeLocation = vm.EmployeeLocation,
                Grade_Level = vm.Grade_Level,
                JLPTLevel = vm.JLPTLevel,
                EmployeeContractStatus = vm.EmployeeContractStatus,
                DateHired = vm.DateHired,
                RegularizationDate = vm.RegularizationDate,
                EmployeeProjects = vm.EmployeeProjects,
                EmployeeSkills = vm.EmployeeSkills,
                Gender = vm.Gender,
                EndOfEmployment = vm.EndOfEmployment,
                ResignationDate = vm.ResignationDate,
                IsBench = vm.IsBench,
                RBUId = vm.RBUId,
                DepartmentId = vm.DepartmentId,
                DivisionId = vm.DivisionId,
                UnitId = vm.UnitId,
                CreatedByUserId = vm.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsHR = vm.IsHR,
                IsTrainer = vm.IsTrainer,
                IsManager = vm.IsManager,
                IsOperationManager = vm.IsOperationManager,
            };

            _context.Add(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }


        public int UpdatePerson(PersonUpdateViewModel vm)
        {

            var personModel = _context.People.Where(x => x.PersonId == vm.PersonId).SingleOrDefault();

            personModel.FirstName = vm.FirstName;
            personModel.LastName = vm.LastName;
            personModel.Middlename = vm.Middlename;
            personModel.Position = vm.Position;
            personModel.ZinzaiId = vm.ZinzaiId;
            personModel.EmployeeEmail = vm.EmployeeEmail;
            personModel.PersonTitle = vm.PersonTitle;
            personModel.EmployeeStatus = vm.EmployeeStatus;
            personModel.EmployeeTitle = vm.EmployeeTitle;
            personModel.EmployeeLocation = vm.EmployeeLocation;
            personModel.Grade_Level = vm.Grade_Level;
            personModel.JLPTLevel = vm.JLPTLevel;
            personModel.EmployeeContractStatus = vm.EmployeeContractStatus;
            personModel.DateHired = vm.DateHired;
            personModel.RegularizationDate = vm.RegularizationDate;
            personModel.EmployeeProjects = vm.EmployeeProjects;
            personModel.EmployeeSkills = vm.EmployeeSkills;
            personModel.Gender = vm.Gender;
            personModel.EndOfEmployment = vm.EndOfEmployment;
            personModel.ResignationDate = vm.ResignationDate;
            personModel.IsBench = vm.IsBench;
            personModel.RBUId = vm.RBUId;
            personModel.DepartmentId = vm.DepartmentId;
            personModel.DivisionId = vm.DivisionId;
            personModel.UnitId = vm.UnitId;
            personModel.CreatedByUserId = vm.CreatedByUserId;
            personModel.DateCreated = DateTime.Now;
            personModel.IsActive = true;
            personModel.IsHR = vm.IsHR;
            personModel.IsTrainer = vm.IsTrainer;
            personModel.IsManager = vm.IsManager;
            personModel.IsOperationManager = vm.IsOperationManager;

            _context.Update(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }

        public int DeletePerson(int id, int UserAccountId)
        {
            var personModel = _context.People.Where(x => x.PersonId == id).SingleOrDefault();
            personModel.DeletedByUserId = UserAccountId;
            personModel.DateDeleted = DateTime.Now;
            personModel.IsActive = false;


            _context.Update(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }
        public int RestorePerson(int id, int UserAccountId)
        {
            var personModel = _context.People.Where(x => x.PersonId == id).SingleOrDefault();
            personModel.DeletedByUserId = UserAccountId;
            personModel.DateDeleted = DateTime.Now;
            personModel.IsActive = false;


            _context.Update(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }

        public PersonUpdateViewModel GetPersonById(int id)
        {

            var personModel = _context.People.Where(x => x.PersonId == id).Select(x => new PersonUpdateViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Middlename = x.Middlename,
                Position = x.Position,
                ZinzaiId = x.ZinzaiId,
                EmployeeEmail = x.EmployeeEmail,
                PersonTitle = x.PersonTitle,
                EmployeeStatus = x.EmployeeStatus,
                EmployeeTitle = x.EmployeeTitle,
                EmployeeLocation = x.EmployeeLocation,
                Grade_Level = x.Grade_Level,
                JLPTLevel = x.JLPTLevel,
                EmployeeContractStatus = x.EmployeeContractStatus,
                DateHired = (DateTime)x.DateHired,
                RegularizationDate = (DateTime)x.RegularizationDate,
                EmployeeProjects = x.EmployeeProjects,
                EmployeeSkills = x.EmployeeSkills,
                Gender = x.Gender,
                EndOfEmployment = (DateTime)x.EndOfEmployment,
                ResignationDate = (DateTime)x.ResignationDate,
                IsBench = (bool)x.IsBench,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
                DivisionId = x.DivisionId,
                UnitId = x.UnitId,
                CreatedByUserId = x.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsHR = x.IsHR,
                IsTrainer = x.IsTrainer,
                IsManager = (bool)x.IsManager,
                IsOperationManager = (bool)x.IsOperationManager,
            });

            return (PersonUpdateViewModel)personModel;
        }


        public List<PersonViewModel> GetAll()
        {

            var personModel = _context.People.Where(x => x.IsActive == true).Select(x => new PersonViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Middlename = x.Middlename,
                Position = x.Position,
                ZinzaiId = x.ZinzaiId,
                EmployeeEmail = x.EmployeeEmail,
                PersonTitle = x.PersonTitle,
                EmployeeStatus = x.EmployeeStatus,
                EmployeeTitle = x.EmployeeTitle,
                EmployeeLocation = x.EmployeeLocation,
                Grade_Level = x.Grade_Level,
                JLPTLevel = x.JLPTLevel,
                EmployeeContractStatus = x.EmployeeContractStatus,
                DateHired = (DateTime)x.DateHired,
                RegularizationDate = (DateTime)x.RegularizationDate,
                EmployeeProjects = x.EmployeeProjects,
                EmployeeSkills = x.EmployeeSkills,
                Gender = x.Gender,
                EndOfEmployment = (DateTime)x.EndOfEmployment,
                ResignationDate = (DateTime)x.ResignationDate,
                IsBench = (bool)x.IsBench,
                RBUId = x.RBUId,
                DepartmentId = x.DepartmentId,
                DivisionId = x.DivisionId,
                UnitId = x.UnitId,
                CreatedByUserId = x.CreatedByUserId,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsHR = x.IsHR,
                IsTrainer = x.IsTrainer,
                IsManager = (bool)x.IsManager,
                IsOperationManager = (bool)x.IsOperationManager,
            }).ToList();

            return personModel.ToList(); ;
        }
    }
}
