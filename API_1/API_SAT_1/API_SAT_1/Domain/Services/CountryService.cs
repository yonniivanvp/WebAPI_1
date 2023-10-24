using API_SAT_1.DAL;
using API_SAT_1.DAL.Entities;
using API_SAT_1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_SAT_1.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;

        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync(); //Aquí lo que hago es traerme todos los datos que tengo en mi tabla Countries.
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid(); // Así se asigna automaticamente un ID a un nuevo registro
                country.CreatedDate = DateTime.Now;
                _context.Countries.Add(country); //Aquí estoy creando el objeto Country en el contexto de mi BD
                await _context.SaveChangesAsync(); //Aquí estoy yendo a la BD para hacer el INSERT en la tabla Countries
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                //Esta exception me captura un mensaje cuando el pais ya existe (Duplicados)
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences Notation --> ??
            }
        }
    }
}
