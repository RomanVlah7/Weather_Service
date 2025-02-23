using Microsoft.AspNetCore.Mvc;

namespace Weather_service.Controllers;
[ApiController]
[Route("api/weather")]
public class WeatherController: ControllerBase
{
    [Route("getForecast")]
    public async Task<String> GetWeatherForecast(string location = "Comrat", string aqi = "no")
    {
        string requestUrl = "http://api.weatherapi.com/v1/current.json?key=a0d3235b801c4ac19d6215134250802&q=" +
                            location + "&aqi=" + aqi;
       HttpClient client = new HttpClient();
        var responseMessage = await client.GetAsync(requestUrl);
        string responseBody = await responseMessage.Content.ReadAsStringAsync();
        return responseBody;
    }
}