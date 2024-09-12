using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class TrainingTransact : BaseModel
    {
        [Key]
        public int TrainingTransactId { get; set; }
        public int TrainingId { get; set; }
        public int PersonId { get; set; }
        public int GradingInPercentage { get; set; }
        public string TraineeActivitiesLink { get; set; }


    }
}
