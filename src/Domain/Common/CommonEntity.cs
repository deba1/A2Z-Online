namespace Domain.Common
{
    public abstract class CommonEntity : BaseEntity
    {
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
