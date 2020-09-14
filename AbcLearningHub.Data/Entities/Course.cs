using System;

namespace AbcLearningHub.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public decimal PassMark { get; set; }
        public int DurationInMinutes { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public Author Author { get; set; }
    }
}
