using Microsoft.EntityFrameworkCore;

namespace VP_7
{
    internal static class Program
    {
        private static Context _context;

        static Program() 
        {
            _context = new Context();
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var form = new Form();
            Application.Run(form);
        }

        public static Dictionary<int, string> GetstudentNames() 
        {
            var students = _context.Students
                .Select((student) => new KeyValuePair<int, string>(student.Id, student.PIB));
            return new Dictionary<int, string>(students);
        }

        public static Student Getstudent(int id) 
        {
            var result = _context.Students.Include(student => student.Disciples).FirstOrDefault(student => student.Id == id);
            if (result == null) 
            {
                throw new Exception();
            }
            return result;
        }

        public static Disciple GetDisciple(int id) 
        {
            var result = _context.Disciples.Include(Disciple => Disciple.Lector).Include(Disciple => Disciple.Name).FirstOrDefault(Disciple => Disciple.Id == id);
            if (result == null)
            {
                throw new Exception();
            }
            return result;
        }

        public static List<Student> Getstudents() 
        {
            return _context.Students.ToList();
        }

        public static List<Disciple> GetDisciples()
        {
            return _context.Disciples.ToList();
        }

        public static List<Lector> GetAgencies()
        {
            return _context.Lectors.ToList();
        }

        public static void SaveChanges() 
        {
            _context.SaveChanges();
        }

        public static void Addstudent(Student student) 
        {
            _context.Students.Add(student);
        }

        public static void AddLector(Lector Lector)
        {
            _context.Lectors.Add(Lector);
        }

        public static void AddDisciple(Disciple Disciple)
        {
            _context.Disciples.Add(Disciple);
        }

        public static void Delete(object entry) 
        {
            _context.Remove(entry);
        }
    }
}