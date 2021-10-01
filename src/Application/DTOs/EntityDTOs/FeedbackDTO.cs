namespace Application.DTOs.EntityDTOs
{
    public class FeedbackDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
