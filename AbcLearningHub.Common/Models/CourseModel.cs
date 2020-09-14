using System;
using Microsoft.VisualBasic;

namespace AbcLearningHub.Common.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public decimal PassMark { get; set; }
        public int DurationInMinutes { get; set; }
        public AuthorModel Author { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
