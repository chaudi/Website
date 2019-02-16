using Cederfelt.se.DataAccess;
using Cederfelt.se.DataAccess.Models;
using System.Threading.Tasks;

namespace Cederfelt.se.BL
{
    public class AddMeasurementCommand : IAddMeasurementCommand
    {
        private ITemperatureRepository _temperatureRepository;
        public AddMeasurementCommand(ITemperatureRepository temperatureRepository)
        {
            _temperatureRepository = temperatureRepository;
        }

        public async Task ExecuteAsync(TemperatureMeasurement t)
        {
            var existing = await _temperatureRepository.GetCountAsync();

            if (existing > 1000)
            {
                await _temperatureRepository.DeleteOldest((int)(existing - 1000));
            }

            await _temperatureRepository.AddTemperatureAsync(Convert(t));
            await _temperatureRepository.SaveAsync();
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
