using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_7
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Disciple> Disciples { get; set; }
        public DbSet<DiscipleStudent> DSs { get; set; }
        public DbSet<Lector> Lectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer("data source=DESKTOP-9QFPCKG;initial catalog=VP7;trusted_connection=true");
            }
        }
    }

    public class Student 
    {

        public int Id { get; set; }
        public string? PIB { get; set; }
        public string? photo { get; set; }
        public string? RTFText { get; set; }
        public string? Group { get; set; }
        public string? speciality { get; set; }
        public string? House { get; set; }
        public string? Adress { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? EnrollDate { get; set; }
        public int? rating { get; set; }
        public int? stip { get; set; }
        public List<Disciple>? Disciples { get; set; }
        public int? smark100 { get; set; }
        public int? smark5 { get; set; }
    }

    public class Disciple 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Lector? Lector { get; set; }
    }

    public class DiscipleStudent
    {
        public int Id { get; set; }
        public Student? Student { get; set; }
        public Disciple? Disciple { get; set; }
        public int? res1 { get; set; }
        public int? res2 { get; set; }
        public string? type { get; set; }
        public string? semestr { get; set; }
    }

    public class Lector 
    {
        public int Id { get; set; }
        public string? PIB { get; set; }
        public string? Address { get; set; }
    }
}
