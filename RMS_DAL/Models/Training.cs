using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class Training : BaseModel
    {
        [Key]
        public int TrainingId { get; set; }
        public string TrainingCode { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
        public int TrainingDurationInDays { get; set; }
        public int TrainerId { get; set; }

    }
}
