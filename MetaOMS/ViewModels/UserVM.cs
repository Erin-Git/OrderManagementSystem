using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class UserVM
    {
        public int UserVMId { get; set; }
        [Required(ErrorMessage = "This Field is required !")]
        public string UserVMName { get; set; }
        public int UserRoleVMId { get; set; }
        [Required(ErrorMessage = "This Field is required !")]
        public string PasswordVM { get; set; }
        public int SerialNo { get; set; }
    }
}
