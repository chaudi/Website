using Cederfelt.se.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cederfelt.se.DataAccess
{
    public interface ITemperatureRepository
    {
        Task<Temperature> GetByIdAsync(int id);

        Task<IEnumerable<Temperature>> GetNewerThanDateAsync(DateTime date);

        Task<IEnumerable<Temperature>> GetNumberOfMeasurementsAsync(int number);

        Task InsertTemperatureAsync(Temperature temperature);

        Task SaveAsync();
    }
}
