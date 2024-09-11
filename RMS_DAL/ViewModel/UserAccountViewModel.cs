using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_DAL.ViewModel
{
    public class UserAccountViewModel
    {

        public int UserAccountId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }

    }


    public class UserAccountCreateViewModel
    {
        public int UserAccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnforcePasswordExpirePolicy { get; set; }
        public DateTime PasswordExpiration { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }

    public class UserAccountUpdateViewModel
    {
        public int UserAccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnforcePasswordExpirePolicy { get; set; }
        public DateTime PasswordExpiration { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
