using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class TransactionLog
    {
        [Key]
        public int logID { get; set; }
        public string logUser { get; set; }
        public string logTimestamp { get; set; }
        public string logAction { get; set; }



    }
}
