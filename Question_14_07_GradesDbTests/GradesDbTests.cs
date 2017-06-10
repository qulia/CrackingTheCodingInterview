using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question_14_07_GradesDb;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_14_07_GradesDb.Tests
{
    [TestClass()]
    public class GradesDbTests
    {
        public class StudentGPAResult
        {
            public string Name { get; set; }
            public double GPA { get; set; }
        }

        [TestMethod()]
        public void GetTop10StudentsTest()
        {
            using (var gradesDb = new GradesDbDataModelContainer())
            {
                PopulateDb(gradesDb);

                var result = gradesDb.Database.SqlQuery<StudentGPAResult>("EXEC sp_GetTop10PercentPerformingStudents");

                Trace.WriteLine(string.Format("Count: {0}", result.Count<StudentGPAResult>()));
                foreach (var studentGPA in result)
                {
                    Trace.WriteLine(string.Format("{0} {1}", studentGPA.Name, studentGPA.GPA));
                }
            }
        }

        private static void PopulateDb(GradesDbDataModelContainer gradesDb)
        {
            gradesDb.Database.ExecuteSqlCommand("EXEC sp_Purge");

            for (int i = 0; i < 3; i++)
            {
                var course = new Course();
                course.Name = "course" + i.ToString();
                var proffesor = new Professor();
                proffesor.Name = "professor" + i.ToString();
                course.Professor = proffesor;

                gradesDb.Professors.Add(proffesor);
                gradesDb.Courses.Add(course);
            }

            gradesDb.SaveChanges();
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var student = new Student();
                student.Name = "student" + i.ToString();
                gradesDb.Students.Add(student);

                foreach (var course in gradesDb.Courses)
                {
                    if (random.Next(0, 2) == 1)
                    {
                        var enrollment = new Enrollment();
                        enrollment.Grade = Math.Ceiling(random.NextDouble() * 100);
                        enrollment.Term = random.Next(0, 4);
                        enrollment.Student = student;
                        enrollment.Course = course;

                        gradesDb.Enrollments.Add(enrollment);
                    }
                }
            }

            try
            {
                gradesDb.SaveChanges();
            }
            catch (DbEntityValidationException validationError)
            {
                foreach (var error in validationError.EntityValidationErrors)
                {
                    foreach (var error2 in error.ValidationErrors)
                    {
                        Trace.WriteLine(error2.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}