using RMS_DAL.Interfaces;
using RMS_DAL.Models;
using RMS_DAL.RMSDBContext;
using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public PersonViewModel GetPersonById(int id)
        {
           
            var personModel = _context.People.Where(x => x.PersonId == id).SingleOrDefault();
            var personVM = new PersonViewModel();

            if (personModel != null)
            {
                personVM.PersonId = personModel.PersonId;
                personVM.FirstName = personModel.FirstName;
                personVM.LastName = personModel.LastName;
                personVM.Middlename = personModel.Middlename;
                personVM.Position = personModel.Position;
            }

            return personVM;
        }
    }
}
