using AbcLearningHub.Common.Core;
using System.Collections.Generic;
using System.Text;

namespace AbcLearningHub.Common.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmployeeId { get; set; }
        public string DateCreated { get; set; }
        public int? DepartmentId { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
