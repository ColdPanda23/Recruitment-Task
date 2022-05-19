using AdressBook.Models;

namespace AdressBook.Services
{
    public class AdressRepository
    {
        private readonly List<Adress> _adresses = new List<Adress>();


        public Adress? GetLastAdded()
        {
            return _adresses.LastOrDefault();
        }

        public void Add(Adress adress)
        {
            if (adress is null)
            {
                throw new ArgumentNullException(nameof(adress));
            }
            _adresses.Add(adress);
        }

        public IEnumerable<Adress> GetAdressesIn(string city)
        {
            return _adresses.Where(adress => adress.City == city);
        }

    }
}
