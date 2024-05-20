using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MillePortfolio.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace MillePortfolio.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryCache _cache;

        public WeatherViewComponent(IHttpClientFactory clientFactory, IMemoryCache cache)
        {
            _clientFactory = clientFactory;
            _cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_cache.TryGetValue("Weather", out WeatherModel weatherData))
            {
                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri("http://api.weatherapi.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/v1/current.json?key=abe8320defb74b72adf111532242504&q=Sweden");

                weatherData = new WeatherModel();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponseJson = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(apiResponseJson);
                    weatherData.Location = apiResponse.location.name;
                    weatherData.Temperature = apiResponse.current.temp_c.ToString();
                    weatherData.ConditionText = apiResponse.current.condition.text;
                    weatherData.ConditionIcon = apiResponse.current.condition.icon;
                    weatherData.WindSpeed = apiResponse.current.wind_kph;
                    weatherData.Precipitation = apiResponse.current.precip_mm;
                    _cache.Set("Weather", weatherData, TimeSpan.FromMinutes(15));
                }
                else
                {
                    weatherData.Location = "Weather";
                    weatherData.Temperature = "Unavailable";
                }
            }

            return View(weatherData);
        }
    }
}
