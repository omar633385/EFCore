using EFCore.Data;
using EFCore.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            #region Topic
            //var topic= new Topic() { Name="programming"};
            //context.Topics.Add(topic);

            //context.SaveChanges();

            //var TopicToFind= context.Topics.FirstOrDefault();//top[1]
            //Console.WriteLine(context.Entry(TopicToFind));//unchanged

            //if (TopicToFind != null) {
            //    TopicToFind.Name = "Programming02";
            //}

            //Console.WriteLine(context.Entry(TopicToFind));//modified
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(TopicToFind));//unchanged


            #endregion

            #region Courses
            //var course = new Course() { Duration = "2 weeks", Name = "EntityFrameWork", Top_Id = 1 };
            //context.Add(course);

            //Console.WriteLine(context.Entry(course).State);// added
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(course).State);// unchanged

            //var CourseToFind = context.Courses.FirstOrDefault();//top[1]
            //Console.WriteLine(context.Entry(CourseToFind));//unchanged

            //if (CourseToFind != null)
            //{
            //    CourseToFind.Name = "EfCore8";
            //}

            //Console.WriteLine(context.Entry(CourseToFind));//modified
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(CourseToFind));//unchanged


            #endregion

            #region Instructor
            //var instructor = new Instructor() { Name = "hamada", Address = "Cairo", Salary = 5000, Bonus = 0, Dept_Id = 1, HourRate = 50 };
            //context.Add(instructor);

            //Console.WriteLine(context.Entry(instructor).State);// added
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(instructor).State);// unchanged

            var instructorToFind = context.Instructors.FirstOrDefault();//top[1]
            Console.WriteLine(context.Entry(instructorToFind));//unchanged

            if (instructorToFind != null)
            {
                instructorToFind.Name = "wael";
            }

            Console.WriteLine(context.Entry(instructorToFind));//modified
            context.SaveChanges();
            Console.WriteLine(context.Entry(instructorToFind));//unchanged

            #endregion

            #region Department

            //var department = new Department() { Name = "HR",HiringDate=new DateOnly(2025,1,1),Ins_Id=1};
            //context.Add(department);

            //Console.WriteLine(context.Entry(department).State);// added
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(department).State);// unchanged

            var departmentToFind = context.Departments.FirstOrDefault();//top[1]
            Console.WriteLine(context.Entry(departmentToFind));//unchanged

            if (departmentToFind != null)
            {
                departmentToFind.Name = "Accounting";
            }

            Console.WriteLine(context.Entry(departmentToFind));//modified
            context.SaveChanges();
            Console.WriteLine(context.Entry(departmentToFind));//unchanged



            #endregion

            #region Student

            var student = new Student() { Address = "Alex", Age = 23, Dept_Id = 1, Fname = "omar",Lname="mohamed"};
            context.Add(student);
            context.SaveChanges();

            var studentToFind = context.Students.FirstOrDefault();//top[1]
            Console.WriteLine(context.Entry(studentToFind));//unchanged

            if (studentToFind != null)
            {
                studentToFind.Age = 24;
            }

            Console.WriteLine(context.Entry(studentToFind));//modified
            context.SaveChanges();
            Console.WriteLine(context.Entry(studentToFind));//unchanged

            #endregion

            #region Course_inst
            var Course_inst = new Course_inst() { Course_Id=1,Inst_Id=1,Evaluate=10};
            context.Add(Course_inst);

            Console.WriteLine(context.Entry(Course_inst).State);// added
            context.SaveChanges();
            Console.WriteLine(context.Entry(Course_inst).State);// unchanged

            var Course_instTo_Find = context.Course_inst.FirstOrDefault();//top[1]
            Console.WriteLine(context.Entry(Course_instTo_Find));//unchanged

            if (Course_instTo_Find != null)
            {
                Course_instTo_Find.Evaluate = 20;
            }

            Console.WriteLine(context.Entry(Course_instTo_Find));//modified
            context.SaveChanges();
            Console.WriteLine(context.Entry(Course_instTo_Find));//unchanged

            #endregion

            #region Stud_course

            var Stud_Course = new Stud_Course() { Course_Id = 1, Stud_Id = 1, Grade = 90 };
            context.Add(Stud_Course);

            Console.WriteLine(context.Entry(Stud_Course).State);// added
            context.SaveChanges();
            Console.WriteLine(context.Entry(Stud_Course).State);// unchanged

            var Stud_Course_ToFind = context.Stud_Courses.FirstOrDefault();//top[1]
            Console.WriteLine(context.Entry(Stud_Course_ToFind));//unchanged

            if (Stud_Course_ToFind != null)
            {
                Stud_Course_ToFind.Grade = 80;
            }

            Console.WriteLine(context.Entry(Stud_Course_ToFind));//modified
            context.SaveChanges();
            Console.WriteLine(context.Entry(Stud_Course_ToFind));//unchanged

            #endregion

        }
    }
}
