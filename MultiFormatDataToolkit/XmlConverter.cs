using System.Xml.Linq;

namespace MultiFormatDataToolkit;

public class XmlConverter : IFileFormatConverter<XmlRecord>
{
    public List<XmlRecord> Read(string filePath)
    {
        var doc = XDocument.Load(filePath);

        return doc.Descendants("Car")
            .Select(carElem 
                => new XmlRecord
                {
                    Date = carElem.Element("Date").Value, 
                    BrandName = carElem.Element("BrandName").Value, 
                    Price = int.Parse(carElem.Element("Price").Value)
                }).ToList();
    }

    public void Write(List<XmlRecord> data, string filePath)
    {
        var doc = new XDocument(new XElement("Document"));

        foreach (var carElem in data.Select(record => new XElement("Car",
                     new XElement("Date", record.Date),
                     new XElement("BrandName", record.BrandName),
                     new XElement("Price", record.Price)
                 )))
        {
            doc.Root.Add(carElem);
        }

        doc.Save(filePath);
    }
}