

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


        public Student Replace (int id, Student student)
        {
            //We must FIND the student that we are updating
            //and store that student and eventually change it

            Student? existingStudent = _db.Students.Find(id); //If we find something in the database ef core tracks it

            if(existingStudent is null)
            {
                return null;
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Age = student.Age;
            existingStudent.IsVaccinated = student.IsVaccinated;

           // _db.Students.Update(existingStudent); //This is the old way
            _db.SaveChanges();
            // when we pull an entity from our DB it is tracked and ef core knows if changes are being made to it
            // it is not a simple copy of information
            return existingStudent;
        }

          //PATCH changes only the fields the client sent
          //A field the client left out arrives as "" or (blank / null), so blank means leave it alone
        public Student Patch(int id, Student changes)
        {
            Student? existingStudent = _db.Students.Find(id);

            if(existingStudent == null)
            {
                return null;
            }

            //if a field has a blank or white space we do not change it
            //IsNullOrWhiteSpace is true or null, "" and "  "
            if (string.IsNullOrWhiteSpace(changes.FirstName))
            {
                existingStudent.FirstName = changes.FirstName;
            }


            if(string.IsNullOrWhiteSpace(changes.LastName) != true)
            {
                existingStudent.LastName = changes.LastName;
            }

            if (!string.IsNullOrWhiteSpace(changes.Email))
            {
                existingStudent.Email = changes.Email;
            }

            //EF Core tracks our entity automatically

            _db.SaveChanges();

            return existingStudent;
        }
    }
}