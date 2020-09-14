namespace AbcLearningHub.Common.Models
{
    public class CourseExamModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string ExamName { get; set; }
        public string Description { get; set; }
        public CourseModel Course{ get; set; }
    }
}
