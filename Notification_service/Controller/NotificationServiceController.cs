using Microsoft.AspNetCore.Mvc;

namespace Message_service.Controller;
[ApiController]
[Route("notification-controller")]
public class NotificationServiceController
{
    [HttpGet]
    [Route("health")]
    public string IsAlive()
    {
        return "Service is online";
    }
    
}