using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDatabase
{
    // Öğrenci sınıfı
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
    }

    // Sınıf sınıfı
    class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Örnek sınıf verileri
            var classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Fizik" },
                new Class { ClassId = 3, ClassName = "Kimya" }
            };

            // Örnek öğrenci verileri
            var students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ahmet", ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Mehmet", ClassId = 1 },
                new Student { StudentId = 3, StudentName = "Ayşe", ClassId = 2 },
                new Student { StudentId = 4, StudentName = "Fatma", ClassId = 2 },
                new Student { StudentId = 5, StudentName = "Ali", ClassId = 3 }
            };

            // LINQ GroupJoin işlemi
            var groupJoinQuery = from c in classes
                                 join s in students on c.ClassId equals s.ClassId into studentGroup
                                 select new
                                 {
                                     ClassName = c.ClassName,
                                     Students = studentGroup
                                 };

            // Sonuçları ekrana yazdırma
            foreach (var classGroup in groupJoinQuery)
            {
                Console.WriteLine($"Sınıf: {classGroup.ClassName}");
                foreach (var student in classGroup.Students)
                {
                    Console.WriteLine($"  Öğrenci: {student.StudentName}");
                }
                Console.WriteLine();
            }
        }
    }
}
