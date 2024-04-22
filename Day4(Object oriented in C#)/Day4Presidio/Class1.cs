using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


namespace Day4Presidio
{
  
    // Teacher class representing a teacher
    public class Teacher
    {
        public string Name { get; set; }
        public List<Course> CoursesTaught { get; set; }

        public Teacher(string name)
        {
            Name = name;
            CoursesTaught = new List<Course>();
        }
    }

    // Course class representing a course
    public class Course
    {
        public string Title { get; set; }
        public Teacher Instructor { get; set; }

        public Course(string title, Teacher instructor)
        {
            Title = title;
            Instructor = instructor;
        }
    }

    // Student class representing a student
    public class Student
    {
        public string Name { get; set; }
        public List<Course> CoursesAttended { get; set; }

        public Student(string name)
        {
            Name = name;
            CoursesAttended = new List<Course>();
        }
    }

    public class Class1
    {
        static void Main(string[] args)
        {
            // Creating instances of Teacher and Student
            Teacher teacher1 = new Teacher("John Doe");
            Student student1 = new Student("Alice");

            // Creating instances of courses
            Course course1 = new Course("Mathematics", teacher1);
            Course course2 = new Course("Science", teacher1);

            // Associate courses with students and teachers
            teacher1.CoursesTaught.Add(course1);
            teacher1.CoursesTaught.Add(course2);
            student1.CoursesAttended.Add(course1);

            // Output information
            Console.WriteLine("Teacher: " + teacher1.Name);
            Console.WriteLine("Courses Taught by " + teacher1.Name + ":");
            foreach (var course in teacher1.CoursesTaught)
            {
                Console.WriteLine("- " + course.Title);
            }

            Console.WriteLine("\nStudent: " + student1.Name);
            Console.WriteLine("Courses Attended by " + student1.Name + ":");
            foreach (var course in student1.CoursesAttended)
            {
                Console.WriteLine("- " + course.Title);
            }
        }
    }

}
