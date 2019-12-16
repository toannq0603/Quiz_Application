using System.ComponentModel.DataAnnotations;

namespace QuizApplication.Logic.Model
{
    public class PersonModel
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }        
        [Required]
        public int Time { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
    }
}
