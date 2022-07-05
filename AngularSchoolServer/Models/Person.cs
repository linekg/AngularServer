namespace AngularSchoolServer.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
