
using Combine_Day_Thirteen_API_DB.Models;

namespace Combine_Day_Thirteen_API_DB.Services
{
    public interface IStudentServices
    {
        // 2 Methods. A method that gets all students, and a method that creates a student


        List<Student> GetAll();

        Student AddStudent(Student newstudent); //parameters are just placeholders for information

        Student Replace (int id, Student student);

        Student Patch (int id, Student changes);
    }
}