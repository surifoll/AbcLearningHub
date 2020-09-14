namespace AbcLearningHub.Data.Entities
{
    public class CourseExam
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string ExamName { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }
}
