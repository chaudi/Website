using System.Threading.Tasks;

namespace Cederfelt.se.BL
{
    public interface IAddMeasurementCommand : ICommand
    {
        Task ExecuteAsync(TemperatureMeasurement t);
    }
}
