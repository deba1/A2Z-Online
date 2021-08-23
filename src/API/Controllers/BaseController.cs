using Application.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IApiResponseDTO _apiResponseDTO;
    }
}
