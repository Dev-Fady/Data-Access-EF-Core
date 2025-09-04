namespace EF_Migration.Entites
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // one To one (office to Instructor)

        public int? OfficeId { get; set; }
        public Office? office { get; set; }

        // one to many ( Section , Instructor ) 
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
