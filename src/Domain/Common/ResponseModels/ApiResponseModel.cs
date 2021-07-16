namespace Domain.Common.ResponseModels
{
    /// <summary>
    /// API response model to send api response
    /// </summary>
    public class ApiResponseModel
    {
        public string Message { get; set; }
        public object Content { get; set; }
        public int Status { get; set; } // Status 0 for failure and 1 for success.
    }
}
