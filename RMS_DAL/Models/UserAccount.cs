using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.Models
{
    public class UserAccount : BaseModel
    {
        [Key]
        public int UserAccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool EnforcePasswordExpirePolicy { get; set; }
        public DateTime PasswordExpiration { get; set; }
        public bool IsReference { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }

    }
}
