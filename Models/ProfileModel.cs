using System.ComponentModel.DataAnnotations;

namespace latihan.Models
{
    public class ProfileModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? AboutMe { get; set; }
        public string? Skills { get; set; }
    }
}