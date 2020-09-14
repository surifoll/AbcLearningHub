namespace AbcLearningHub.Common.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName}{LastName}";
        public string Address { get; set; }
    }
}