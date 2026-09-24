

using Combine_Day_Thirteen_API_DB.Data;
using Combine_Day_Thirteen_API_DB.Models;

namespace Combine_Day_Thirteen_API_DB.Services
{
    public class StudentServices : IStudentServices
    {
        private AppDbContext _db;

        public StudentServices(AppDbContext db)    //Constructor must have same name as class
        {
            _db = db;
            //when our StudentServices Class is called
            //
        }


        public List<Student> GetAll()
        {
            return _db.Students.ToList();
        }

        public Student AddStudent(Student newStudent)
        {
            //The Database Assigns the Id, so we can ignore any id the client sent
            newStudent.Id = 0;

            _db.Students.Add(newStudent); //Stages the add
            _db.SaveChanges(); // Actually writes it to our students.db

            return newStudent;
        }
    }
}