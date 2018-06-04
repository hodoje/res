using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entities.Models;
using FileReader.Interfaces;

namespace FileReader.Writers
{
    public class DatabaseWriter : IWriter
    {
        private IUnitOfWork _unitOfWork;

        public DatabaseWriter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Write(List<PowerConsumptionData> data)
        {
            if (data.Count > 0)
            {
                _unitOfWork.PowerConsumptionDataRepository.AddRange(data);
                _unitOfWork.Complete();
            }
        }
    }
}