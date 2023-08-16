namespace MultiFormatDataToolkit;

public static class FileFormatConverterFactory
{
    public static IFileFormatConverter<T> Create<T>(string format) where T : Record
    {
        return format switch
        {
            "xml" => new XmlConverter() as IFileFormatConverter<T>,
            "json" => new JsonConverter() as IFileFormatConverter<T>,
            _ => throw new NotSupportedException("Unsupported format: " + format)
        };
    }
}