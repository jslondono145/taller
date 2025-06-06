using ShoppingAPI_2025.DAL.Entities;

namespace ShoppingAPI_2025.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _databaseContext;

        public SeederDB(DataBaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }        public async Task SeederAsync()
        {
            await _databaseContext.Database.EnsureCreatedAsync();
            await PopulateCountriesWithStatesAsync();
            await _databaseContext.SaveChangesAsync();
        }

        #region Private Methods
        private Task PopulateCountriesWithStatesAsync()
        {
            if (!_databaseContext.Countries.Any())
            {
                _databaseContext.Countries.Add(new Country
                {
                    CreationDate = DateTime.Now,
                    CountryName = "Colombia",
                    StatesList = new List<State>()
                    {
                        new State
                        {
                            CreationDate = DateTime.Now,
                            StateName = "Antioquia"
                        },
                        new State
                        {
                            CreationDate = DateTime.Now,
                            StateName = "Cundinamarca"
                        }
                    }
                });

                _databaseContext.Countries.Add(new Country
                {
                    CreationDate = DateTime.Now,
                    CountryName = "Argentina",
                    StatesList = new List<State>()
                    {
                        new State
                        {
                            CreationDate = DateTime.Now,
                            StateName = "Buenos Aires"
                        }
                    }
                });
            }

            return Task.CompletedTask;
        }
        #endregion
    }
}
