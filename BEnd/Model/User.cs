
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("usr")]
    public class User {
        [Key]
        [Column("id")]
        public Guid id {get; set;}

        [Required]
        [Column("username")]
        public string username {get; set;}
        
        [Required]
        [Column("pass")]
        public string pass {get; set;}
    }
}