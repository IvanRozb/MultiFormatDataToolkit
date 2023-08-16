namespace MultiFormatDataToolkit;

public interface IFileFormatConverter<T> where T : Record
{
    List<T> Read(string filePath);
    void Write(List<T> data, string filePath);
}