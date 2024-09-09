using RMS_DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Interfaces
{
    public interface ITrainingService 
    {
        int CreateTraining(TrainingCreateViewModel vm);
        int UpdateTraining(TrainingUpdateViewModel vm);
        int DeleteTraining(int id, int UserAccountId);
        int RestoreTraining(int id, int UserAccountId);
        List<TrainingViewModel> GetAllActive();
        List<TrainingViewModel> GetAllInactive();
    }
}
