namespace Domain.Common
{
    class CommonEntity : BaseEntity
    {
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
