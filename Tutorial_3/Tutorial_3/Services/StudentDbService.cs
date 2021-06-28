using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_3.Models;

namespace Tutorial_3.Services
{
    public interface IStudentDbService
    {
        Student GetStudent(string Index);
        Student AddStudent(Student student);
        Student UpdateStudent(string Index,Student student);
        string DeleteStudent(string Index);
    }
    public class StudentDbService : IStudentDbService
    {
        public static List<Student> students = new List<Student>();

        public void SaveChanges()
        {
            var streamWriter = new StreamWriter(Program.filePath);
            foreach (var st in students)
            {
                streamWriter.WriteLine(st);
            }      
        }
        public Student AddStudent(Student student)
        {
            var checkStudent = students.FirstOrDefault(x => x.Index == student.Index);
            if(checkStudent != null)
            {
                return null;
            }

            Student stud = new Student
            {
                FirstName = student.FirstName,
                Surname = student.Surname,
                Index = student.Index,
                Birthdate = student.Birthdate,
                Email = student.Email,
                Study = student.Study,
                Mode = student.Mode,
                MotherName = student.MotherName,
                FatherName = student.FatherName
            };
            students.Add(stud);

            SaveChanges();

            return stud;
        }

        public string DeleteStudent(string Index)
        {
            var result = students.FirstOrDefault(x => x.Index == Index);
            students.Remove(result);
            SaveChanges();
            return Index;
        }

        public Student GetStudent(string Index)
        {
            return students.FirstOrDefault(x => x.Index == Index);   
        }

        public Student UpdateStudent(string Index, Student student)
        {
            var result = students.FirstOrDefault(x => x.Index == Index);

            result.FirstName = student.FirstName;
            result.Surname = student.Surname;
            result.Birthdate = student.Birthdate;
            result.Study = student.Study;
            result.Mode = student.Mode;
            result.FatherName = student.FatherName;
            result.MotherName = student.MotherName;
            result.Email = student.Email;

            SaveChanges();

            return result;
        }
    }
}
