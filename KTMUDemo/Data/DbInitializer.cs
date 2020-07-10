using System;
using System.Linq;
using KTMUDemo.Models;

namespace KTMUDemo.Data
{
    public class DbInitializer
    {
        public static void Initialize(UniversityContext context)
        {
            context.Database.EnsureCreated();
            
            if(context.Students.Any()) return;
            
            var students = new Student[]
            {
                new Student{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new Student{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new Student{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new Student{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (var student in students) context.Students.Add(student);
            context.SaveChanges();
            
            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            foreach (var instructor in instructors) context.Instructors.Add(instructor);
            context.SaveChanges();
            
            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single(i => i.LastName == "Abercrombie").Id },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single(i => i.LastName == "Fakhouri").Id },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Harui").Id },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Kapoor").Id }
            };
            foreach (var d in departments) context.Departments.Add(d);
            context.SaveChanges();
            
            var courses = new Course[]
            {
                new Course {Id = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Engineering").Id
                },
                new Course {Id = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Economics").Id
                },
                new Course {Id = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Economics").Id
                },
                new Course {Id = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics").Id
                },
                new Course {Id = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Mathematics").Id
                },
                new Course {Id = 2021, Title = "Composition",    Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "English").Id
                },
                new Course {Id = 2042, Title = "Literature",     Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "English").Id
                },
            };
            foreach (var course in courses) context.Courses.Add(course);
            context.SaveChanges();
            
            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Fakhouri").Id,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Harui").Id,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Kapoor").Id,
                    Location = "Thompson 304" },
            };
            foreach (var o in officeAssignments) context.OfficeAssignments.Add(o);
            context.SaveChanges();
            
            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Kapoor").Id
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Harui").Id
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Microeconomics" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Zheng").Id
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Macroeconomics" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Zheng").Id
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Calculus" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Fakhouri").Id
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Trigonometry" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Harui").Id
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Composition" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Abercrombie").Id
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Literature" ).Id,
                    InstructorId = instructors.Single(i => i.LastName == "Abercrombie").Id
                    },
            };
            foreach (var ci in courseInstructors) context.CourseAssignments.Add(ci);
            context.SaveChanges();
            
            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alexander").Id,
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).Id,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alexander").Id,
                    CourseId = courses.Single(c => c.Title == "Microeconomics" ).Id,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alexander").Id,
                    CourseId = courses.Single(c => c.Title == "Macroeconomics" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentId = students.Single(s => s.LastName == "Alonso").Id,
                    CourseId = courses.Single(c => c.Title == "Calculus" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentId = students.Single(s => s.LastName == "Alonso").Id,
                    CourseId = courses.Single(c => c.Title == "Trigonometry" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Alonso").Id,
                    CourseId = courses.Single(c => c.Title == "Composition" ).Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Anand").Id,
                    CourseId = courses.Single(c => c.Title == "Chemistry" ).Id
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Anand").Id,
                    CourseId = courses.Single(c => c.Title == "Microeconomics").Id,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Barzdukas").Id,
                    CourseId = courses.Single(c => c.Title == "Chemistry").Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Li").Id,
                    CourseId = courses.Single(c => c.Title == "Composition").Id,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Justice").Id,
                    CourseId = courses.Single(c => c.Title == "Literature").Id,
                    Grade = Grade.B
                    }
            };
            foreach (var e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments
                    .SingleOrDefault(s => s.Student.Id == e.StudentId &&
                                          s.Course.Id == e.CourseId);
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}