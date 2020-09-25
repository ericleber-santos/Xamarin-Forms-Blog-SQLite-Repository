using SQLite;

namespace Simulacao.Models
{
    [Table("Post")]
    public class Post : IBaseModel
    {       
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int POST_USER_ID { get; set; }
       
        public int POST_ID { get; set; }
       
        public string POST_TITLE { get; set; }
       
        public string POST_BODY { get; set; }        
    }   

}
