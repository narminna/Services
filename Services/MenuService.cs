﻿﻿using System;
using ConsoleApp30.Models;

namespace ConsoleApp30.Services
{
    public class MenuService
    {
        private static ClassroomService classroomService = new ClassroomService();

        public static void MenuShowStudents()
        {
            var students = classroomService.GetStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("No students yet.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id} | Name: {student.Name} | Surname: {student.Surname} | Grade: {student.Grade} | BDay: {student.Birthday}");
            }
        }

        public static void MenuShowTeachers()
        {
            var teachers = classroomService.GetTeachers();

            if (teachers.Count == 0) 
            {
                Console.WriteLine("No teachers yet.");
                return;
            }
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.Id} | Name: {teacher.Name} | Surname:{teacher.Surname} | Salary: {teacher.Salary} | Bday: {teacher.Bday}");
            }
        }

        public static void MenuAddStudent()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter grade:");
                double grade = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter birthday (MM/dd/yyyy):");
                DateTime birthDay = DateTime.Parse(Console.ReadLine());

                classroomService.AddStudent(name, surname, grade, birthDay);

                Console.WriteLine("Added student successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuAddTeacher()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter salary");
                double salary = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Birthday Date:");
                DateTime bday = DateTime.Parse(Console.ReadLine());

                classroomService.AddTeacher(name, surname, salary, bday);
                Console.WriteLine("Teacher added successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Oops, Error {ex.Message}");
            }
        }
        public static void MenuUpdateStudent()
        {
            try
            {
                Console.WriteLine("Enter ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter grade:");
                double grade = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter birthday (MM/dd/yyyy):");
                DateTime birthDay = DateTime.Parse(Console.ReadLine());

                classroomService.UpdateStudent(id, name, surname, grade, birthDay);

                Console.WriteLine("Updated student successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuUpdateTeacher()
        {
            try
            {
                Console.WriteLine("Enter ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter salary:");
                double salary = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter birthday (MM/dd/yyyy):");
                DateTime bday = DateTime.Parse(Console.ReadLine());

                classroomService.UpdateTeacher(id, name, surname, salary, bday);

                Console.WriteLine("Updated teacher successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuRemoveStudent()
        {
            try
            {
                Console.WriteLine("Enter student's ID:");
                int id = int.Parse(Console.ReadLine());

                classroomService.RemoveStudent(id);

                Console.WriteLine("Deleted student successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuRemoveTeacher()
        {
            try
            {
                Console.WriteLine("Enter teacher's ID:");
                int id = int.Parse(Console.ReadLine());

                classroomService.RemoveTeacher(id);

                Console.WriteLine("Deleted teacher successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuFindStudentsByName()
        {
            try
            {
                Console.WriteLine("Enter name for search:");
                string name = Console.ReadLine();

                var foundStudents = classroomService.FindStudentsByName(name);

                if (foundStudents.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;

                }
                foreach (var student in foundStudents)
                {
                    Console.WriteLine($"Id: {student.Id} | Name: {student.Name} | Surname: {student.Surname} | Grade: {student.Grade} | BDay: {student.Birthday}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuFindTeachersByName()
        {
            try
            {
                Console.WriteLine("Enter name for search:");
                string name = Console.ReadLine();

                var foundTeachers = classroomService.FindTeachersByName(name);

                if (foundTeachers.Count == 0)
                {
                    Console.WriteLine("No teachers found.");
                    return;

                }
                foreach (var teacher in foundTeachers)
                {
                    Console.WriteLine($"Id: {teacher.Id} | Name: {teacher.Name} | Surname: {teacher.Surname} | Grade: {teacher.Salary} | BDay: {teacher.Bday}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuSearchStudentsByBday()
        {
            try
            {
                Console.WriteLine("Enter minimum date (MM/dd/yyyy):");
                DateTime minBday = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter maximum date (MM/dd/yyyy):");
                DateTime maxBday = DateTime.Parse(Console.ReadLine());

                var foundStudents = classroomService.SearchStudentsByBday(minBday, maxBday);

                if (foundStudents.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;
                }

                foreach (var student in foundStudents)
                {
                    Console.WriteLine($"Id: {student.Id} | Name: {student.Name} | Surname: {student.Surname} | Grade: {student.Grade} | BDay: {student.Birthday}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }
        public static void MenuSearchTeachersByBday()
        {
            try
            {
                Console.WriteLine("Enter minimum date (MM/dd/yyyy):");
                DateTime minBday = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter maximum date (MM/dd/yyyy):");
                DateTime maxBday = DateTime.Parse(Console.ReadLine());

                var foundTeachers = classroomService.SearchTeachersByBday(minBday, maxBday);

                if (foundTeachers.Count == 0)
                {
                    Console.WriteLine("No teachers found.");
                    return;
                }

                foreach (var teacher in foundTeachers)
                {
                    Console.WriteLine($"Id: {teacher.Id} | Name: {teacher.Name} | Surname: {teacher.Surname} | Grade: {teacher.Salary} | BDay: {teacher.Bday}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }
    }
}
