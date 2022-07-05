namespace AngularSchoolServer.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? TeacherID { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Grade>? Grades { get; set; } = new();
    }
}
