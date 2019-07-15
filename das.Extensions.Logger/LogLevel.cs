using System.Xml.Serialization;

namespace das.Extensions.Logger
{
    public enum LogLevel
    {
        [XmlEnum("d")]
        Debug,
        [XmlEnum("i")]
        Info,
        [XmlEnum("w")]
        Warning,
        [XmlEnum("e")]
        Error
    }
}