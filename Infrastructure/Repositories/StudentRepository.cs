using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        // This list acts as an in-memory storage for demo purposes.
        private readonly List<Student> _students = new List<Student>();

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.Find(student => student.Id == id);
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var existingStudent = GetById(student.Id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                // Update other properties as needed
            }
        }

        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}
