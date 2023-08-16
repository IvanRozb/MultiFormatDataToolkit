using Newtonsoft.Json;

namespace MultiFormatDataToolkit;

public class JsonConverter : IFileFormatConverter<JsonRecord>
{
    public List<JsonRecord> Read(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var records = JsonConvert.DeserializeObject<List<JsonRecord>>(jsonData);
        return records;
    }

    public void Write(List<JsonRecord> data, string filePath)
    {
        var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }
}