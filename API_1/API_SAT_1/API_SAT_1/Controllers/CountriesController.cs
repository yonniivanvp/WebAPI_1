using API_SAT_1.DAL.Entities;
using API_SAT_1.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_SAT_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //Esta es la primera parte de la URL de esta API: URL= api/countries
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        //En un controlador los metodos cambian de nombre y realmente se llaman acciones, si es una API se denomina ENDPOINT
        //Todo Endpoint retorna un ActionResult, significa que retorna el resultado de una ACCION

        [HttpGet, ActionName("Get")]
        [Route("Get")] //Aquí concateno la URL inicial: URL = api/countries/get
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        { 
            var countries = await _countryService.GetCountriesAsync(); //Aquí estoy llendo a mi capa de Domain para traerme la lista de paises 

            if (countries == null || !countries.Any()) //El metodo Any() significa si hay al menos un elemento
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(countries); // OK = 200 Http Status Code
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCountryAsync(Country country) 
        {
            try
            {
                var createdCountry = await _countryService.CreateCountryAsync(country);
                if (createdCountry == null) //El metodo Any() significa si hay al menos un elemento
                {
                    return NotFound(); //NotFound = 404 Http Status Code
                }

                return Ok(createdCountry);//Retorne un 200 y el objeto Country
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate")) 
                {
                    return Conflict (String.Format("El país {0} ya existe.", country.Name)); // Conflict = 409 Http Status Code Error
                }

                return Conflict(ex.Message);
            }
        }
    }
}
