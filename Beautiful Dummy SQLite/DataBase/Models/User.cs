using ServiceStack.DataAnnotations;
using System;

namespace Beautiful_Dummy_SQLite.DataBase.Models
{
    [Alias("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [Required, StringLength(30), Unique]
        public string Login { get; set; }

        [Required, StringLength(30)]
        public string Password { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required, StringLength(20)]
        public string Surname { get; set; }

        [Required, StringLength(20), Unique]
        public string Phone { get; set; }

        [Required, StringLength(15)]
        public string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
