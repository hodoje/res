using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using FileReader.Interfaces;

namespace FileReader.Readers
{
    public class CsvReader : IReader
    {
        public List<PowerConsumptionData> Read(string fileName, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
