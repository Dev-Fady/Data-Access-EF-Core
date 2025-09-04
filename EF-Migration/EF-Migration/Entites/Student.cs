namespace EF_Migration.Entites
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Section> sections { get; set; } = new List<Section>();

    }
}
