using Combine_Day_Thirteen_API_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Combine_Day_Thirteen_API_DB.Data
{
    public class AppDbContext : DbContext // Db Context is our connection
    {
        //Constructor runs automatically when class is called



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

         //This is the Students table, as far as our C# code is Concerned
        public DbSet<Student> Students {get;set;}
    }
}