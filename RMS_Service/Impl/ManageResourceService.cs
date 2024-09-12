using Microsoft.EntityFrameworkCore;
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
    public class ManageResourceService : IManageResourceService
    {
        private readonly RMSContext _context;
        public ManageResourceService(RMSContext context)
        {
            _context = context;
        }
        public int CreateResource(ManageResourceCreateViewModel vm)
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
                IsHR = false,
                IsManager = false,
                IsTrainer = false,
                IsOperationManager = false,
            };

            _context.Add(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }
        public int UpdateResource(ManageResourceUpdateViewModel vm)
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

            _context.Update(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }

        public int DeleteResource(int id, int UserAccountId)
        {
            var personModel = _context.People.Where(x => x.PersonId == id).SingleOrDefault();
            personModel.DeletedByUserId = UserAccountId;
            personModel.DateDeleted = DateTime.Now;
            personModel.IsActive = false;


            _context.Update(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }
        public int RestoreResource(int id, int UserAccountId)
        {
            var personModel = _context.People.Where(x => x.PersonId == id).SingleOrDefault();
            personModel.DeletedByUserId = UserAccountId;
            personModel.DateDeleted = DateTime.Now;
            personModel.IsActive = true;


            _context.Update(personModel);
            _context.SaveChanges();

            return personModel.PersonId == 0 ? 0 : 1;
        }

        public List<ManageResourceIndexViewModel> GetAllActive()
        {

            var personModel = _context.People.Where(x => x.IsActive == true).Select(x => new ManageResourceIndexViewModel
            {
                PersonId = x.RBUId,
                EmployeeFullname = x.LastName + ", " + x.FirstName,
                Position = x.Position,
                Skills = x.EmployeeSkills,
                IsActive = x.IsActive,
            });

            return personModel.ToList();
        }

        public List<ManageResourceIndexViewModel> GetAllInactive()
        {
            var personModel = _context.People.Where(x => x.IsActive == false).Select(x => new ManageResourceIndexViewModel
            {
                PersonId = x.RBUId,
                EmployeeFullname = x.LastName + ", " + x.FirstName,
                Position = x.Position,
                Skills = x.EmployeeSkills,
                IsActive = x.IsActive,
            });

            return personModel.ToList();
        }


        public ManageResourceUpdateViewModel GetById(int Id)
        {
            var personModel = _context.People.Where(x => x.PersonId == Id).Select(x => new ManageResourceUpdateViewModel
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
            });

            return (ManageResourceUpdateViewModel)personModel;
        }
    }
}
