﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class ReferenceTable :BaseModel
    {
        [Key]
        public int ReferenceTableId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }

    }
}
