namespace EF_Migration.Entites
{
    public class Section
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int ScheduleId { get; set; }

        public Schedule? schedule { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // one to many ( Course, Section ) 

        public int CourseId { get; set; }
        public Course course { get; set; }

        // one to many ( Instructor, Section ) 

        public int InstructorId { get; set; }
        public Instructor instructor { get; set; }


        //public ICollection<Schedule> schedules { get; set; } = new List<Schedule>();

        //public ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();


        public ICollection<Student> students { get; set; } = new List<Student>();
    }
}
