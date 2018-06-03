using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Entities.Models;
using FileReader.Interfaces;
using FileReader.ReadModel;

namespace FileReader.Readers
{
    public class XmlReader : IReader
    {
        public List<PowerConsumptionData> Read(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<ReadDataType>), new XmlRootAttribute("PROGNOZIRANI_LOAD"));
            List<ReadDataType> listOfData = new List<ReadDataType>();
            List<PowerConsumptionData> returnList = new List<PowerConsumptionData>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                listOfData = xs.Deserialize(sr) as List<ReadDataType>;
            }

            if (listOfData != null)
            {
                if (listOfData.Count == 24)
                {
                    if (listOfData.GroupBy(data => data.Sat).Select(x => x.First()).ToList().Count == 24)
                    {
                        bool everyHourSet = true;

                        for (int i = 1; i <= 24; i++)
                        {
                            if (listOfData.Any(x => x.Sat != i.ToString()))
                            {
                                everyHourSet = false;
                                break;
                            }
                        }

                        if (everyHourSet)
                        {
                            foreach (ReadDataType data in listOfData)
                            {
                                int hour;
                                Int32.TryParse(data.Sat, out hour);
                                double consumption;
                                Double.TryParse(data.Load, out consumption);
                                returnList.Add(new PowerConsumptionData
                                {
                                    Timestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                        Int32.Parse(data.Sat), DateTime.Now.Minute, DateTime.Now.Second),
                                    Consumption = consumption,
                                    GeoAreaId = data.Oblast,
                                    GeoArea = null
                                });
                            }
                        }
                    }
                }
            }
            return returnList;
        }
    }
}
