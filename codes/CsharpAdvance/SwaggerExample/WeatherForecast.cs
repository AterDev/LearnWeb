namespace SwaggerExample;

/// <summary>
/// 天气预报
/// </summary>
public class WeatherForecast
{
    public DateOnly Date { get; set; }
    /// <summary>
    ///  温度
    /// </summary>

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
