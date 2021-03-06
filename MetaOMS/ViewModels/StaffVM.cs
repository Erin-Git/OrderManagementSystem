﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MetaOMS.ViewModels
{
    public class StaffVM
    {
        public int SerialNo { get; set; }
        public int StaffVMId { get; set; }
        [DisplayName("Name of the staff")]
        [Required(ErrorMessage = "This Field is required !")]
        public string StaffVMName { get; set; }
        [DisplayName("Contact No. of the staff")]
        [Required(ErrorMessage = "This Field is required !")]
        public string ContactVMNo { get; set; }
        [DisplayName("Email address of the staff")]
        [Required(ErrorMessage = "This Field is required !")]
        [EmailAddress]
        public string EmailVMAddress { get; set; }
        public int UserVMId { get; set; }
        public int CurrentPage { get; set; }
    }
}
