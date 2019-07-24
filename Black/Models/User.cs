using System;
using SQLite;

namespace Black.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public long Id { set; get; }
        [MaxLength(60)]
        public string Name { set; get; }
        [MaxLength(140)]
        public string Profile { set; get; }
        public string Icon { set; get; }
        public string HeaderIcon { set; get; }
    }
}
