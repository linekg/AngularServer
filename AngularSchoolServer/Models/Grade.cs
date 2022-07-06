namespace AngularSchoolServer.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public string? Comment { get; set; }
        public int LessonID { get; set; }
        public Lesson? Lesson { get; set; }
        public int StudentID { get; set; }
        public Student? Student { get; set; }
    }
}
