namespace EF_Migration.Entites
{
    public class Office
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public String? Location { get; set; }

        // one To one (office to Instructor)
        public Instructor? Instructor { get; set; }
    }
}