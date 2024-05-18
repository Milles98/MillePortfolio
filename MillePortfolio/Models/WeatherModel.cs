namespace MillePortfolio.Models
{
    public class WeatherModel
    {
        public string Location { get; set; }
        public string Temperature { get; set; }
        public string ConditionText { get; set; }
        public string ConditionIcon { get; set; }
        public double WindSpeed { get; set; }
        public double Precipitation { get; set; }
    }
}
