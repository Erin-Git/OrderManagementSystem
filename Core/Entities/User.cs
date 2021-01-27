using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserRoleId { get; set; }
        public string Password { get; set; }
    }
}
