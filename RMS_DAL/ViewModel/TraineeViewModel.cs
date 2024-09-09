using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class TraineeViewModel : BaseViewModel
    {
        public int TrainingTransactId { get; set; }
        public int TrainingId { get; set; }
        public int PersonId { get; set; }
        public string ZinzaiId { get; set; }
        public string TraineeFullname { get; set; }
        public string  Position { get; set; }
        public string Skills { get; set; }
        public int GradingInPercentage { get; set; }
        public string TraineeActivitiesLink { get; set; }

    }
}
