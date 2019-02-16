using Cederfelt.se.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cederfelt.se.DataAccess
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private TemperatureContext _context;

        public TemperatureRepository(TemperatureContext context)
        {
            _context = context;
        }

        public async Task<Temperature> GetByIdAsync(int id)
        {
            return await _context.Temperatures.FindAsync(id);
        }

        public async Task<IEnumerable<Temperature>> GetNewerThanDateAsync(DateTime date)
        {
            return await _context.Temperatures.Where(x => x.TimeStamp > date).ToListAsync();
        }

        public async Task<IEnumerable<Temperature>> GetNumberOfMeasurementsAsync(int number)
        {
            return await _context.Temperatures.OrderByDescending(x => x.TimeStamp).Take(number).ToListAsync();
        }

        public async Task<long> GetCountAsync()
        {
            return await _context.Temperatures.CountAsync();
        }

        public async Task DeleteOldest(int numberOfItems)
        {
            var entitiesToDelete = await _context.Temperatures.Take(numberOfItems).ToListAsync();
            _context.RemoveRange(entitiesToDelete);
        }

        public async Task AddTemperatureAsync(Temperature temperature)
        {
            await _context.Temperatures.AddAsync(temperature);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
