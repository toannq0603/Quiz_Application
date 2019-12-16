
using QuizApplication.Logic.Model;
using System.Data.Entity;

namespace QuizApplication.Logic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("QuizApp")
        {

        }

        public DbSet<PersonModel> Person { get; set; }
    }
}
