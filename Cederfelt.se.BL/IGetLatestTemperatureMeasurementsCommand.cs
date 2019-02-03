using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cederfelt.se.BL
{
    public interface IGetLatestTemperatureMeasurementsCommand : ICommand
    {
        Task<IEnumerable<TemperatureMeasurement>> ExecuteAsync();
    }
}
