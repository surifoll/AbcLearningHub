using AbcLearningHub.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcLearningHub.Data.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DateCreated { get; set; }
        public int? DepartmentId { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
