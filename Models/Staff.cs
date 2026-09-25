

namespace Combine_Day_Thirteen_API_DB.Models
{
    public class Staff : BaseEntity
    {
        // variables first letters must be capitol letters
        

        public string FullName {get;set;} = string.Empty;

        public string Job {get;set;} = string.Empty;

        public bool HasComputer {get;set;} = false;  //we can assign values to our properties
    }
}