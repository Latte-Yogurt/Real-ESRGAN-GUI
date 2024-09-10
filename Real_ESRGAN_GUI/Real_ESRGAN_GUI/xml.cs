using System.Xml.Serialization;

[XmlRoot("AppConfig")]
public class AppConfig
{
    [XmlElement("Setting1")]
    public string Setting1 { get; set; }

    [XmlElement("Setting2")]
    public int Setting2 { get; set; }
}