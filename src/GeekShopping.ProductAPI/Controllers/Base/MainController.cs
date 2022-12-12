using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers.Base
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
    }
}
