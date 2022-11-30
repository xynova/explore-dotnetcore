using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DecimalJsonConverter : JsonConverter<Double>
{
    private const string Format = "0.00";

    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
       return Double.Parse(reader.GetString()!, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, Double value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
    
}