using System;
using System.Xml.Serialization;

namespace HomeWorkConsoleApp8
{
    [XmlRoot("Person")]
    [Serializable]
    public struct StructUser
    {
        [XmlAttribute]
        public string name;
        public StructAdress Address { set; get; }
        public StructPhone Phones { set; get; }
    }
}
