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
    public class TrainingService : ITrainingService
    {
        private readonly RMSContext _context;

        public TrainingService(RMSContext context)
        {
            _context = context;
        }
        public int CreateTraining(TrainingCreateViewModel vm)
        {
            var trainingModel = new Training()
            {
                TrainingCode = vm.TrainingCode,
                TrainingName = vm.TrainingName,
                TrainingDescription = vm.TrainingDescription,
                TrainingStartDate = vm.TrainingStartDate,
                TrainingEndDate = vm.TrainingEndDate,
                TrainingDurationInDays = vm.TrainingDurationInDays,
                CreatedByUserId = vm.CreatedByUserId,
                DateCreated = DateTime.Now,
                TrainerId = vm.TrainerId,
                IsActive = vm.IsActive,
            };
            _context.Add(trainingModel);

            foreach (var item in vm.Trainees)
            {
                var traineesModel = new TrainingTransact()
                {
                    TrainingId = trainingModel.TrainingId,
                    PersonId = item.PersonId,
                    GradingInPercentage = item.GradingInPercentage,
                    TraineeActivitiesLink = item.TraineeActivitiesLink,
                    IsActive = true,
                };
                _context.Add(traineesModel);
            }

            _context.SaveChanges();

            return trainingModel.TrainingId == 0 ? 0 : 1;
        }

        public int UpdateTraining(TrainingUpdateViewModel vm)
        {
            var trainingModel = _context.Trainings.Where(x => x.TrainingId == vm.TrainingId).SingleOrDefault();
            trainingModel.TrainingCode = vm.TrainingCode;
            trainingModel.TrainingName = vm.TrainingName;
            trainingModel.TrainingDescription = vm.TrainingDescription;
            trainingModel.TrainerId = vm.TrainerId;
            trainingModel.UpdatedByUserId = vm.UpdatedByUserId;
            trainingModel.DateUpdated = DateTime.Now;
            trainingModel.IsActive = vm.IsActive;
            _context.Update(trainingModel);

            foreach (var item in vm.Trainees)
            {
                var traineesModel = _context.TrainingTransacts.Where(x => x.TrainingTransactId == item.TrainingTransactId).SingleOrDefault();
                traineesModel.TrainingId = trainingModel.TrainingId;
                traineesModel.PersonId = item.PersonId;
                traineesModel.GradingInPercentage = item.GradingInPercentage;
                traineesModel.TraineeActivitiesLink = item.TraineeActivitiesLink;
                traineesModel.UpdatedByUserId = vm.UpdatedByUserId;
                traineesModel.DateUpdated = DateTime.Now;
                traineesModel.IsActive = vm.IsActive;

                _context.Update(traineesModel);
            }

            _context.SaveChanges();

            return trainingModel.TrainingId == 0 ? 0 : 1;
        }


        public int DeleteTraining(int id, int UserAccountId)
        {
            var trainingModel = _context.Trainings.Where(x => x.TrainingId == id).SingleOrDefault();
            trainingModel.DeletedByUserId = UserAccountId;
            trainingModel.DateDeleted = DateTime.Now;
            trainingModel.IsActive = false;

            _context.Update(trainingModel);
            _context.SaveChanges();

            return trainingModel.TrainingId == 0 ? 0 : 1;
        }

        public List<TrainingViewModel> GetAllActive()
        {
            var trainingModel = _context.Trainings.Where(x => x.IsActive == true).Select(x => new TrainingViewModel
            {
                TrainingId = x.TrainingId,
                TrainingCode = x.TrainingCode,
                TrainingName = x.TrainingName,
                TrainingDescription = x.TrainingDescription,
                TrainerFullname = _context.People.Where(z => z.PersonId == x.TrainerId).SingleOrDefault().LastName + ", " + _context.People.Where(z => z.PersonId == x.TrainerId).SingleOrDefault().FirstName,
                TrainingStartDate = x.TrainingStartDate,
                TrainingEndDate = x.TrainingEndDate,
                TrainingDurationInDays = x.TrainingDurationInDays,
                
            });

            return trainingModel.ToList();
        }

        public List<TrainingViewModel> GetAllInactive()
        {
            var trainingModel = _context.Trainings.Where(x => x.IsActive == false).Select(x => new TrainingViewModel
            {
                TrainingId = x.TrainingId,
                TrainingCode = x.TrainingCode,
                TrainingName = x.TrainingName,
                TrainingDescription = x.TrainingDescription,
                TrainerFullname = _context.People.Where(x => x.PersonId == x.PersonId).SingleOrDefault().LastName + ", " + _context.People.Where(x => x.PersonId == x.PersonId).SingleOrDefault().LastName,
                TrainingStartDate = x.TrainingStartDate,
                TrainingEndDate = x.TrainingEndDate,
                TrainingDurationInDays = x.TrainingDurationInDays,

            });

            return trainingModel.ToList();
        }

        public int RestoreTraining(int id, int UserAccountId)
        {
            var trainingModel = _context.Trainings.Where(x => x.TrainingId == id).SingleOrDefault();
            trainingModel.RestoredByUserId = UserAccountId;
            trainingModel.DateRestore = DateTime.Now;
            trainingModel.IsActive = true;

            _context.Update(trainingModel);
            _context.SaveChanges();

            return trainingModel.TrainingId == 0 ? 0 : 1;
        }

        public List<TraineeSelectionViewModel> GetAllTraineeSelectionList()
        {
            var traineeViewModel = _context.People.Where(x => x.IsActive == true && x.IsBench == true).Select(x => new TraineeSelectionViewModel
            {
                ZinzaiId = x.ZinzaiId,
                PersonId = x.PersonId,
                TraineeFullname = x.LastName + ' ' + x.FirstName,
                Position = x.EmployeeTitle,
                Skills = x.EmployeeSkills
            });

            return traineeViewModel.ToList();
        }

        public List<TrainerSelectionViewModel> GetAllTrainerSelectionList()
        {
            var trainerViewModel = _context.People.Where(x => x.IsActive == true && x.IsTrainer == true).Select(x => new TrainerSelectionViewModel
            {
                PersonId = x.PersonId,
                fullname = x.LastName + ' ' + x.FirstName,
            });

            return trainerViewModel.ToList();
        }


        public TrainingUpdateViewModel GetById(int Id)
        {
            var trainingModel = _context.Trainings.Where(x => x.TrainingId == Id).Select(x => new TrainingUpdateViewModel
            {
                TrainingId = x.TrainingId,
                TrainingCode = x.TrainingCode,
                TrainingName = x.TrainingName,
                TrainingDescription = x.TrainingDescription,
                TrainerId = x.TrainerId,
                UpdatedByUserId = x.UpdatedByUserId,
                DateUpdated = DateTime.Now,
                IsActive = x.IsActive,
                Trainees = _context.TrainingTransacts.Where(xy => xy.TrainingId == x.TrainingId).Select(xy => new TraineeViewModel
                {
                    TrainingTransactId = xy.TrainingTransactId,
                    TrainingId = xy.TrainingId,
                    PersonId = xy.PersonId,
                    GradingInPercentage = xy.GradingInPercentage,
                    TraineeActivitiesLink = xy.TraineeActivitiesLink,
                    IsActive = xy.IsActive,
                }).ToList(),

            });


            return (TrainingUpdateViewModel)trainingModel;
        }

    }
}
