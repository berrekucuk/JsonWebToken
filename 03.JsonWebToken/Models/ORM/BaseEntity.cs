namespace _03.JsonWebToken.Models.ORM
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
