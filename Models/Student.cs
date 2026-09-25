namespace Combine_Day_Thirteen_API_DB.Models
{
    public class Student : BaseEntity
    {
        public string FirstName {get;set;}

        public string LastName {get;set;}

        public string Email {get;set;}

    }
}



//Student student = new Student();
//student.FirstName = "Isaiah" {this is the set}
//we would also be able to Console.WriteLine