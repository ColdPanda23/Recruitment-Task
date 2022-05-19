using AdressBook.Models;
using AdressBook.Services;
using Microsoft.AspNetCore.Mvc;


namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdressesController : ControllerBase
    {
        private readonly static AdressRepository _adressRepository = new AdressRepository();


        private readonly ILogger<AdressesController> _logger;

        public AdressesController(ILogger<AdressesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Adress? GetLastAddedAdress()
        {
            _logger.LogInformation("Getting last address");
            return _adressRepository.GetLastAdded();
        }

        [HttpGet("/{city}")]
        public IEnumerable<Adress> GetByCity(string city)
        {
            _logger.LogInformation("Getting filtered address");
            return _adressRepository.GetAdressesIn(city);
        }

        [HttpPost]
        public void AddAdress(Adress adress)
        {
            _logger.LogInformation("Adding address");
            _adressRepository.Add(adress);
        }

    }
}