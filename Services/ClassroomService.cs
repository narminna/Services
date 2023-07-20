﻿using System;
using System.Collections.Generic;
using ConsoleApp30.Models;
using System.Linq;

namespace ConsoleApp30.Services
{
    public class ClassroomService
    {
        private List<Teacher> teachers;
        private List<Student> students;

        public ClassroomService()
        {
            students = new List<Student>();
            teachers = new List<Teacher>();
        }
        public List<Teacher> GetTeachers()
        {
            return teachers;
        }
        public List<Student> GetStudents()
        {
            return students;
        }

        public void AddStudent(string name, string surname, double grade, DateTime birthDay)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can't be empty!");

            if (grade < 0) throw new ArgumentOutOfRangeException("Grade can't be negative!");

            var student = new Student(name, surname, grade, birthDay);

            students.Add(student);
        }

        public void AddTeacher(string name, string surname,  double salary, DateTime bday)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception("Name can't be empty!");
            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can't be empty!");
            if (salary < 0) throw new ArgumentOutOfRangeException("Salary can't be less than 0!");
            var teacher = new Teacher(name, surname, salary, bday);
            teachers.Add(teacher);
        }

        public void RemoveStudent(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");

            var existingStudent = students.FirstOrDefault(x => x.Id == id);

            if (existingStudent == null) throw new Exception("Not found!");

            students = students.Where(x => x.Id != id).ToList();
        }

        public void RemoveTeacher(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("ID can't be negative!");
            var existingTeacher = teachers.FirstOrDefault(x => x.Id == id);
            if (existingTeacher == null) throw new Exception("Not found!");
            teachers = teachers.Where(x => x.Id != id).ToList();
        }

        public List<Student> FindStudentsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            var foundStudents = students.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).ToList();

            return foundStudents;
        }

        public List<Teacher> FindTeachersByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            var foundTeacher = teachers.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).ToList();
            return foundTeacher;
        }

        public void UpdateStudent(int id, string name, string surname, double grade, DateTime birthDay)        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can't be empty!");
            if (grade < 0) throw new ArgumentOutOfRangeException("Grade can't be negative!");
            var existingStudent = students.FirstOrDefault(x => x.Id == id);
            if (existingStudent == null) throw new Exception("Student not found!");
            existingStudent.Name = name;
            existingStudent.Surname = surname;
            existingStudent.Grade = grade;
            existingStudent.Birthday = birthDay;
        }
        public void UpdateTeacher(int id, string name, string surname, double salary, DateTime bday)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");
            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname can't be empty!");
            if (salary < 0) throw new ArgumentOutOfRangeException("Salary can't be negative!");
            var existingTeacher = teachers.FirstOrDefault(x => x.Id == id);
            if (existingTeacher == null) throw new Exception("Teacher not found!");

            existingTeacher.Name = name;
            existingTeacher.Surname = surname;
            existingTeacher.Salary = salary;
            existingTeacher.Bday = bday;
        }

        public List<Student> SearchStudentsByBday(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate) throw new Exception("Min date can't be more than Max date!");

            return students.Where(x => x.Birthday >= minDate && x.Birthday <= maxDate).ToList();
        }

        public List<Teacher> SearchTeachersByBday(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate) throw new Exception("Min date can't be more than Max date!");
            return teachers.Where(x=>x.Bday >= minDate && x.Bday <= maxDate).ToList();
        }
    }
}
