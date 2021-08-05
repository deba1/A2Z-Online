namespace Application.DTOs.ResponseDTOs
{
    public interface IApiResponseDTO
    {
        object SetApiResponse(string message);
    }

    public class ApiResponseDTO : IApiResponseDTO
    {
        public object SetApiResponse(string message)
        {
            return new
            {
                message
            };
        }
    }
}
