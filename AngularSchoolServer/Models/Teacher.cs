namespace AngularSchoolServer.Models
{
    public class Teacher: Person
    {
        public List<Lesson>? Lessons { get; set; } = new();
    }
}
