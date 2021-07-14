namespace Domain.Common
{
    public class CommonEntity : BaseEntity
    {
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
