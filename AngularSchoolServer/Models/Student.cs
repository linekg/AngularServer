namespace AngularSchoolServer.Models
{
    public class Student: Person
    {
        public List<Grade> Grades { get; set; } = new();
    }
}
