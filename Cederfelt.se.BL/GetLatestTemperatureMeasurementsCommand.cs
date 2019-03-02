using Cederfelt.se.DataAccess;
using Cederfelt.se.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cederfelt.se.BL
{
    public class GetLatestTemperatureMeasurementsCommand : IGetLatestTemperatureMeasurementsCommand
    {
        private ITemperatureRepository _repository;

        public GetLatestTemperatureMeasurementsCommand(ITemperatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TemperatureMeasurement>> ExecuteAsync()
        {
            var tm = await _repository.GetNumberOfMeasurementsAsync(30);

            return tm.Select(x => Convert(x));
        }

        private TemperatureMeasurement Convert(Temperature temp)
        {
            return new TemperatureMeasurement
            {
                Degrees = temp.Measurement,
                Humidity = temp.Humidity,
                Id = temp.TemperatureId,
                TimeStamp = temp.TimeStamp
            };
        }
    }
}
