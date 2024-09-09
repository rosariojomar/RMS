using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class TrainingViewModel : BaseViewModel
    {
        public int TrainingId { get; set; }
        public string TrainingCode { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        public int TrainingDurationInDays { get; set; }
        public int NoOfTrainees { get; set; }
        public int TrainerId { get; set; }
        public string TrainerFullname { get; set; }


    }
    public class TrainingCreateViewModel : BaseViewModel
    {
        public int TrainingId { get; set; }
        public string TrainingCode { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        public int TrainingDurationInDays { get; set; }
        public List<TraineeViewModel> Trainees { get; set; }
        public int TrainerId { get; set; }


    }

    public class TrainingUpdateViewModel : BaseViewModel
    {
        public int TrainingId { get; set; }
        public string TrainingCode { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        public int TrainingDurationInDays { get; set; }
        public List<TraineeViewModel> Trainees { get; set; }
        public int TrainerId { get; set; }

    }






}
