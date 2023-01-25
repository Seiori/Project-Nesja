using Newtonsoft.Json.Linq;

public class Roles
{
    public JObject? Top { get; set; }
    public JObject? Jungle { get; set; }
    public JObject? Mid { get; set; }
    public JObject? ADC { get; set; }
    public JObject? Support { get; set; }
    public JObject? All { get; set; }
}