using Cederfelt.se.DataAccess;
using Cederfelt.se.DataAccess.Models;
using System.Threading.Tasks;

namespace Cederfelt.se.BL
{
    public class AddTemperatureDataPointCommand : IAddTemperatureDataPointCommand
    {
        public ITemperatureRepository _repository;

        public AddTemperatureDataPointCommand(ITemperatureRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(TemperatureMeasurement tempM)
        {
            var t = Convert(tempM);
            await _repository.InsertTemperatureAsync(t);
            await _repository.SaveAsync();
        }

        private Temperature Convert(TemperatureMeasurement tm)
        {
            return new Temperature
            {
                Measurement = tm.Degrees,
                TimeStamp = tm.TimeStamp
            };
        }
    }
}
