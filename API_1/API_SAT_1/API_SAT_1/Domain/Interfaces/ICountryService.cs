using API_SAT_1.DAL.Entities;
using System.Collections;

namespace API_SAT_1.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();// Una firma de metodo asincronico
        Task<Country> CreateCountryAsync(Country country);
    }
}
