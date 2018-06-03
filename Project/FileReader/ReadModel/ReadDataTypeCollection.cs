using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileReader.ReadModel
{
    [XmlRoot("PROGNOZIRANI_LOAD")]
    public class ReadDataTypeCollection
    {
        [XmlElement("PROGNOZIRANI_LOAD")]
        public ReadDataType[] Data { get; set; }
    }
}
