using System.Xml.Linq;

namespace MultiFormatDataToolkit;

public class XmlRecord : Record
{
    public XElement ToXmlElement()
    {
        return new XElement("Car",
            new XElement("Date", Date),
            new XElement("BrandName", BrandName),
            new XElement("Price", Price)
        );
    }

    public static XmlRecord FromXmlElement(XElement element)
    {
        return new XmlRecord
        {
            Date = element.Element("Date").Value,
            BrandName = element.Element("BrandName").Value,
            Price = int.Parse(element.Element("Price").Value)
        };
    }
}
