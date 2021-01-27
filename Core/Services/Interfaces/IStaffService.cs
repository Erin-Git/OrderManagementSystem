using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IStaffService
    {
        List<Staff> StaffList();
        void AddorUpdateStaff(Staff staff);
        Staff GetStaffbyId(int id);
    }
}
