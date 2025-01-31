using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BEnd.Model
{
    [Table("usr")]
    public class User {
        [Column("id")]
        public Guid id { get; set; }

        [Column("uName")]
        public string username { get; set; }

        [Column("b_day")]
        public DateTime bDay { get; set; }

        
        public User(string username, DateTime bDay)
        {
            this.username = username;
            this.bDay = bDay;
        }
    }

    [Table("pshs")]
    public class PassHash {
        [Column("id")]
        public long id { get; set; }
        [Column("user_id")]
        public Guid userId { get; set; }

        [Column("pHash")]
        public String passHash { get; set; }
    }
}