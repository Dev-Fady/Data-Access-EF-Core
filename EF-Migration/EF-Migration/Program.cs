using EF_Migration.Data;
using EF_Migration.Entites;
using Microsoft.EntityFrameworkCore;

namespace EF_Migration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using(var con=new AppDbContext())
            //{
            //    foreach (var item in con.Sections.Include(c=>c.course))
            //    {
            //        Console.WriteLine($" Section : {item.Name}  " +
            //            $"Course {item.course.Name} ");
            //    }
            //}

            //using (var context = new AppDbContext())
            //{

            //    var sections = context.Sections
            //        .Include(x => x.course)
            //        .Include(x => x.instructor)
            //        .Include(x => x.schedules)
            //        .Include(x => x.SectionSchedules);

            //    Console.WriteLine("| Id |  Course      | Section | Instructor           | Schedule       | Time Slot     | SUN | MON | TUE | WED | THU | FRI | SAT |");
            //    Console.WriteLine("|----|--------------|---------|----------------------|----------------|---------------|-----|-----|-----|-----|-----|-----|-----|");

            //    foreach (var section in sections)
            //    {
            //        string sunday = section.schedules.Any(s=>s.SUN) ? " x" : "";
            //        string monday = section.schedules.Any(s => s.MON) ? " x" : "";
            //        string tuesday = section.schedules.Any(s => s.WED) ? " x" : "";
            //        string wednesday = section.schedules.Any(s => s.TUE) ? " x" : "";
            //        string thursday = section.schedules.Any(s => s.THU) ? " x" : "";
            //        string friday = section.schedules.Any(s => s.FRI) ? " x" : "";
            //        string saturday = section.schedules.Any(s => s.SAT) ? " x" : "";

            //        Console.WriteLine($"| {section.Id.ToString().PadLeft(2, '0')} | {section.course.Name,-12} | {section.Name,-7} | {(section.instructor?.Name + " "),-20}" +
            //            $" | {section.SectionSchedules.FirstOrDefault().StartTime,-14} | {section.SectionSchedules.FirstOrDefault().EndTime,-9} |" +
            //            $" {sunday,-3} | {monday,-3} | {tuesday,-3} | {wednesday,-3} | {thursday,-3} | {friday,-3} | {saturday,-3} |");
            //    }
            //}

            using (var context = new AppDbContext())
            {

                var sections = context.Sections
                    .Include(x => x.course)
                    .Include(x => x.instructor)
                    .Include(x => x.schedule);

                Console.WriteLine("| Id |  Course      | Section | Instructor           | Schedule       | Time Slot     | SUN | MON | TUE | WED | THU | FRI | SAT |");
                Console.WriteLine("|----|--------------|---------|----------------------|----------------|---------------|-----|-----|-----|-----|-----|-----|-----|");

                foreach (var section in sections)
                {
                    string sunday = section.schedule.SUN ? " x" : "";
                    string monday = section.schedule.MON ? " x" : "";
                    string tuesday = section.schedule.TUE ? " x" : "";
                    string wednesday = section.schedule.WED ? " x" : "";
                    string thursday = section.schedule.THU ? " x" : "";
                    string friday = section.schedule.FRI ? " x" : "";
                    string saturday = section.schedule.SAT ? " x" : "";

                    Console.WriteLine($"| {section.Id.ToString().PadLeft(2, '0')} | {section.course.Name,-12} " +
                        $"| {section.Name,-7} | {(section.instructor?.Name + " ", -20)} " +
                        $"| {section.schedule.Title,-14} " +
                        $"| {section.StartTime,-9} " +
                        $"| {sunday,-3} | {monday,-3} | {tuesday,-3} | {wednesday,-3} | {thursday,-3} | {friday,-3} | {saturday,-3} |");
                }
            }


        }
    }
}
