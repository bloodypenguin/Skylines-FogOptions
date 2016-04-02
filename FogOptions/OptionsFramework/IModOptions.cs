using System.Xml.Serialization;

namespace FogOptions.OptionsFramework
{
    public interface IModOptions
    {
        [XmlIgnore]
        string FileName
        {
            get;
        }
    }
}