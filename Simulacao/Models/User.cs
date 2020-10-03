using SQLite;

namespace Simulacao.Models
{
    [Table("User")]
    public class User 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }       
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_EMAIL { get; set; }       
        public string USER_WEBSITE { get; set; }
    }
}
