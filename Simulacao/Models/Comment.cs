using SQLite;

namespace Simulacao.Models
{
    [Table("Comment")]
    public class Comment : IBaseModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int POST_ID { get; set; }
        public int COMMENT_ID { get; set; }
        public string COMMENT_NAME { get; set; }
        public string COMMENT_EMAIL { get; set; }
        public string COMMENT_BODY { get; set; }
    }
}
